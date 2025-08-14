using AutoMapper;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Resources.Helpers;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.Interfaces.Users;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Topics, aligned with the generic repository pattern.
    /// </summary>
    public class TopicService : ServiceBase, ITopicService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITopicRepository _topicRepository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IResourceMaterialService _resourceMaterialService;
        private readonly IUserResourceDownloadService _userResourceDownloadService;

        public TopicService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ITopicRepository topicRepository,
            ITrainingRepository trainingRepository,
            IFileStorageService fileStorageService,
            IResourceMaterialService resourceMaterialService,
            IUserResourceDownloadService userResourceDownloadService,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _mapper = mapper ;
            _unitOfWork = unitOfWork;
            _topicRepository = topicRepository ;
            _trainingRepository = trainingRepository ;
            _fileStorageService = fileStorageService;
            _resourceMaterialService = resourceMaterialService;
            _userResourceDownloadService = userResourceDownloadService;
        }

        #region Create
        
        public async Task AddTopicAsync(TopicDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            if (await TopicExistsAsync(model.Title, model.TrainingId))
            {
                throw new InvalidDataException(Resources.Messages.Errors.TopicExist);
            }

            var topic = _mapper.Map<Topic>(model);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageUrl = await _fileStorageService.UploadImageAsync(model.ImageFile, Enums.FolderName.TopicCoverImages.GetDescription());
                topic.CoverImageUrl = imageUrl;
            }

            await _topicRepository.AddAsync(topic, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            if (model.NewResources != null && model.NewResources.Any())
            {
                var filesToUpload = model.NewResources
                    .Where(r => r.File != null && r.File.Length > 0)
                    .Select(r => new ResourceMaterialDto
                    {
                        TopicId = topic.Id,
                        File = r.File,
                        Metadata = r.Metadata
                    }).ToList();

                if (filesToUpload.Any())
                {
                    await _resourceMaterialService.AddMultipleResourceMaterialsAsync(filesToUpload);
                }

                var urlsToAdd = model.NewResources
                    .Where(r => !string.IsNullOrEmpty(r.FileAccessUrl))
                    .ToList();

                if (urlsToAdd.Any())
                {
                    await _resourceMaterialService.AddMultipleResourceUrlsAsync(topic.Id, urlsToAdd);
                }

                await _unitOfWork.SaveChangesAsync();
            }
        }

        #endregion

        #region Read

        public async Task<PaginatedList<TopicDto>> GetPaginatedTopicsAsync(int pageNumber, int pageSize, string searchQuery, int? trainingCategoryId, int? trainingId)
        {
            var paginatedData = await _topicRepository.GetPaginatedWithDetailsAsync(pageNumber, pageSize, searchQuery, trainingCategoryId, trainingId);
            var viewModels = _mapper.Map<List<TopicDto>>(paginatedData.Items);
            return new PaginatedList<TopicDto>(viewModels, paginatedData.TotalCount, paginatedData.PageNumber, pageSize);
        }
        public async Task<TopicDto> GetTopicByIdAsync(int id)
        {
            var topic = await _topicRepository.GetByIdWithDetailsAsync(id);
            var vm = _mapper.Map<TopicDto>(topic);

            if (vm.ResourceMaterials != null && vm.ResourceMaterials.Any())
            {
                foreach (var resource in vm.ResourceMaterials)
                {
                    resource.IsDownloaded = await _userResourceDownloadService.IsDownloaded(resource.Id);
                }
            }

            var trainings = await _trainingRepository.GetAllAsync();
            vm.TrainingList = _mapper.Map<List<TrainingDto>>(trainings);
            

            return vm;
        }

        public async Task<TopicDto> GetCreateViewModelAsync(int trainingId)
        {
            var allTrainings = await _trainingRepository.GetAllAsync();
            var trainingList = _mapper.Map<List<TrainingDto>>(allTrainings);

            var viewModel = new TopicDto
            {
                TrainingList = trainingList,
                TrainingId = trainingId
            };

            if (trainingId > 0)
            {
                var selectedTraining = allTrainings.FirstOrDefault(t => t.Id == trainingId);
                viewModel.Training = _mapper.Map<TrainingDto>(selectedTraining);
            }
            
            return viewModel;
        }

        public async Task<bool> TopicExistsAsync(string title, int trainingId)
        {
            var searchTitle = title.ToUpper();
            return await _topicRepository.ExistsAsync(t => t.Title.ToUpper() == searchTitle && t.TrainingId == trainingId);
        }
        #endregion

        #region Update
        
        public async Task UpdateTopicAndResourcesAsync(TopicDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var topic = await _topicRepository.GetByIdAsync(model.Id);
            if (topic == null)
            {
                throw new KeyNotFoundException(Resources.Messages.Errors.TopicDoesNotExist);
            }
            
            var oldImageUrl = topic.CoverImageUrl;
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var newImageUrl = await _fileStorageService.UploadImageAsync(model.ImageFile, Enums.FolderName.TopicCoverImages.GetDescription());
                topic.CoverImageUrl = newImageUrl;
            }

            _mapper.Map(model, topic);
            _topicRepository.Update(topic, currentUserId);

            var idsToDelete = model.ResourceMaterials?
                                .Where(r => r.IsMarkedForDeletion)
                                .Select(r => r.Id)
                                .ToList();

            if (idsToDelete != null && idsToDelete.Any())
            {
                await _resourceMaterialService.DeleteMultipleResourceMaterialsAsync(idsToDelete);
            }

            if (model.NewResources != null && model.NewResources.Any())
            {
                var filesToUpload = model.NewResources
                    .Where(r => r.File != null && r.File.Length > 0)
                    .Select(r => new ResourceMaterialDto
                    {
                        TopicId = model.Id,
                        File = r.File,
                        Metadata = r.Metadata
                    }).ToList();

                if (filesToUpload.Any())
                {
                    await _resourceMaterialService.AddMultipleResourceMaterialsAsync(filesToUpload);
                }

                var urlsToAdd = model.NewResources
                    .Where(r => !string.IsNullOrEmpty(r.FileAccessUrl))
                    .ToList();

                if (urlsToAdd.Any())
                {
                    await _resourceMaterialService.AddMultipleResourceUrlsAsync(model.Id, urlsToAdd);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            if (!string.IsNullOrEmpty(oldImageUrl) && oldImageUrl != topic.CoverImageUrl)
            {
                await _fileStorageService.DeleteImageAsync(oldImageUrl);
            }
        }

         public async Task IncrementViewCountAsync(int topicId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            await _topicRepository.IncrementViewCountAsync(topicId, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Delete
        
        public async Task DeleteTopicAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var topic = await _topicRepository.GetByIdWithDetailsAsync(id);
            var imageUrlToDelete = topic.CoverImageUrl;

            if (topic == null)
            {
                throw new KeyNotFoundException(Resources.Messages.Errors.TopicDoesNotExist);
            }

            if (topic.ResourceMaterials != null && topic.ResourceMaterials.Any())
            {
                var resourceIdsToDelete = topic.ResourceMaterials.Select(m => m.Id).ToList();

                await _resourceMaterialService.DeleteMultipleResourceMaterialsAsync(resourceIdsToDelete);
            }

            await _topicRepository.DeleteAsync(id, currentUserId);

            await _unitOfWork.SaveChangesAsync();

            if (!string.IsNullOrEmpty(imageUrlToDelete))
            {
                await _fileStorageService.DeleteImageAsync(imageUrlToDelete);
            }
        }
        #endregion
    }
}
