using AutoMapper;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Lurnyx.Resources.Constants;
using Lurnyx.Resources.Helpers;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Training Categories.
    /// Implements asynchronous operations and leverages the generic repository pattern.
    /// </summary>
    public class TrainingCategoryService : ServiceBase, ITrainingCategoryService
    {
        private readonly ITrainingCategoryRepository _repository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public TrainingCategoryService(
            ITrainingCategoryRepository repository,
            ITrainingRepository trainingRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IFileStorageService fileStorageService,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _repository = repository;
            _trainingRepository = trainingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        #region Create
        
        public async Task AddTrainingCategoryAsync(TrainingCategoryDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var searchName = model.Name.ToUpper();
            if (await _repository.ExistsAsync(tc => tc.Name.ToUpper() == searchName))
            {
                throw new InvalidDataException(Resources.Messages.Errors.TrainingCategoryExist);
            }

            var trainingCategory = _mapper.Map<TrainingCategory>(model);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageUrl = await _fileStorageService.UploadImageAsync(model.ImageFile, Enums.FolderName.TrainingCategoryImages.GetDescription());
                trainingCategory.CoverImageUrl = imageUrl;
            }

            await _repository.AddAsync(trainingCategory, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Read
        
        public async Task<PaginatedList<TrainingCategoryDto>> GetPaginatedTrainingCategoriesAsync(int pageNumber, int pageSize, string searchQuery)
        {
            var paginatedData = await _repository.GetPaginatedWithDetailsAsync(pageNumber, pageSize, searchQuery);

            var viewModels = _mapper.Map<List<TrainingCategoryDto>>(paginatedData.Items);

            foreach (var vm in viewModels)
            {
                var originalCategory = paginatedData.Items.First(c => c.Id == vm.Id);
                
                vm.TrainingCount = originalCategory.Trainings?.Count ?? 0;

                vm.TopicCount = originalCategory.Trainings?.Sum(t => t.Topics?.Count ?? 0) ?? 0;
            }
            
            return new PaginatedList<TrainingCategoryDto>(viewModels, paginatedData.TotalCount, paginatedData.PageNumber, pageSize);
        }
        
        
        public async Task<TrainingCategoryDto> GetTrainingCategoryByIdAsync(int id)
        {
            var trainingCategory = await _repository.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<TrainingCategoryDto>(trainingCategory);

            viewModel.TrainingCount = trainingCategory.Trainings?.Count ?? 0;
            viewModel.TopicCount = trainingCategory.Trainings?.Sum(t => t.Topics?.Count ?? 0) ?? 0;

            return viewModel;
        }
        #endregion

       #region Update
        
        public async Task UpdateTrainingCategoryAsync(TrainingCategoryDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var trainingCategory = await _repository.GetByIdAsync(model.Id);

            if (trainingCategory == null)
            {
                throw new KeyNotFoundException(Resources.Messages.Errors.TrainingCategoryDoesNotExist);
            }

            var oldImageUrl = trainingCategory.CoverImageUrl;

            _mapper.Map(model, trainingCategory);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var newImageUrl = await _fileStorageService.UploadImageAsync(model.ImageFile, Enums.FolderName.TrainingCategoryImages.GetDescription());
                trainingCategory.CoverImageUrl = newImageUrl;
            }

            if (oldImageUrl != trainingCategory.CoverImageUrl && !string.IsNullOrEmpty(oldImageUrl))
            {
                await _fileStorageService.DeleteImageAsync(oldImageUrl);
            }

            _repository.Update(trainingCategory, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteTrainingCategoryAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);
            
            var trainingCategory = await _repository.GetByIdWithDetailsAsync(id);

            if (trainingCategory == null)
            {
                throw new KeyNotFoundException(Resources.Messages.Errors.TrainingCategoryDoesNotExist);
            }

            var imageUrlToDelete = trainingCategory.CoverImageUrl;

            foreach (var training in trainingCategory.Trainings)
            {
                training.TrainingCategoryId = null;
                training.TrainingCategory = null; 
                _trainingRepository.Update(training, currentUserId);
            }

            await _repository.DeleteAsync(id, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            if (!string.IsNullOrEmpty(imageUrlToDelete))
            {
                await _fileStorageService.DeleteImageAsync(imageUrlToDelete);
            }
        }
        #endregion
    }
}
