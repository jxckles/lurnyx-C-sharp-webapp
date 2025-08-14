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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Trainings, aligned with the generic repository pattern.
    /// </summary>
    public class TrainingService : ServiceBase, ITrainingService
    {
        private readonly ITrainingRepository _repository;
        private readonly ITrainingCategoryRepository _trainingCategoryRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly ITrainingRatingService _trainingRatingService;
        private readonly IUserTrainingProgressService _userTrainingProgressService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingService(
            ITrainingRepository repository,
            ITrainingCategoryRepository trainingCategoryRepository,
            IFileStorageService fileStorageService,
            ITopicRepository topicRepository,
            ITrainingRatingService trainingRatingService,
            IUserTrainingProgressService userTrainingProgressService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory
            ) : base(httpContextAccessor, loggerFactory)
        {
            _repository = repository;
            _trainingCategoryRepository = trainingCategoryRepository;
            _topicRepository = topicRepository;
            _fileStorageService = fileStorageService;
            _trainingRatingService = trainingRatingService;
            _userTrainingProgressService = userTrainingProgressService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create

        public async Task AddTrainingAsync(TrainingDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var searchTitle = model.Title.ToUpper();
            if (await _repository.ExistsAsync(t => t.Title.ToUpper() == searchTitle))
            {
                throw new InvalidDataException(Resources.Messages.Errors.TrainingDoesExist);
            }

            var training = _mapper.Map<Training>(model);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageUrl = await _fileStorageService.UploadImageAsync(
                    model.ImageFile,
                    Enums.FolderName.TrainingCoverImages.GetDescription());
                training.CoverImageUrl = imageUrl;
            }

            await _repository.AddAsync(training, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Read

        public async Task<PaginatedList<TrainingDto>> GetPaginatedTrainingsAsync(int pageNumber, int pageSize, string searchQuery, int? categoryId, int? rating)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var paginatedData = await _repository.GetPaginatedAndFilteredWithDetailsAsync(pageNumber, pageSize, searchQuery, categoryId, rating);
            var viewModels = _mapper.Map<List<TrainingDto>>(paginatedData.Items);
            foreach (var viewModel in viewModels)
            {
                var ratingSummary = await _trainingRatingService.GetRatingSummaryForTrainingAsync(viewModel.Id);
                viewModel.AverageRating = ratingSummary.AverageRating;
                viewModel.RatingCount = ratingSummary.RatingCount;
                viewModel.UserRating = ratingSummary.UserRating;
                var ratingProgress = await _userTrainingProgressService.GetTrainingProgressAsync(currentUserId, viewModel.Id);
                if (ratingProgress != null)
                {
                    viewModel.UserTrainingProgress = ratingProgress;
                }
            }
            return new PaginatedList<TrainingDto>(viewModels, paginatedData.TotalCount, paginatedData.PageNumber, pageSize);
        }

        public async Task<TrainingDto> GetTrainingByIdAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var training = await _repository.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<TrainingDto>(training);

            var ratingSummary = await _trainingRatingService.GetRatingSummaryForTrainingAsync(id);

            viewModel.AverageRating = ratingSummary.AverageRating;
            viewModel.RatingCount = ratingSummary.RatingCount;
            viewModel.UserRating = ratingSummary.UserRating;
            viewModel.UserTrainingProgress = await _userTrainingProgressService.GetTrainingProgressAsync(currentUserId, viewModel.Id);
            viewModel.CategoryList = _mapper.Map<List<TrainingCategoryDto>>(await _trainingCategoryRepository.GetAllAsync());

            return viewModel;
        }

        public async Task<TrainingDto> GetCreateViewModelAsync()
        {
            var categories = await _trainingCategoryRepository.GetAllAsync();
            return new TrainingDto
            {
                CategoryList = _mapper.Map<List<TrainingCategoryDto>>(categories)
            };
        }

        public async Task<SelectList> GetTrainingCategoriesAsSelectListAsync(int? selectedId = null)
        {
            var categories = await _trainingCategoryRepository.GetAllAsync();
            return new SelectList(categories, "Id", "Name", selectedId);
        }

        public async Task<SelectList> GetTrainingsAsSelectListAsync(int? selectedId = null, int? categoryId = null)
        {
            var trainings = await _repository.GetAllAsync();
             if (categoryId.HasValue)
            {
                trainings = trainings.Where(t => t.TrainingCategoryId == categoryId.Value).ToList();
            }
            
            return new SelectList(trainings, "Id", "Title", selectedId);
        }

        public async Task<IEnumerable<TrainingDto>> GetTrainingsByCategoryAsync(int? categoryId)
        {
            var trainings = await _repository.GetTrainingsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<TrainingDto>>(trainings);
        }

        #endregion

        #region Update

        public async Task UpdateTrainingAsync(TrainingDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var training = await _repository.GetByIdAsync(model.Id);
            var oldImageUrl = training.CoverImageUrl;

            _mapper.Map(model, training);

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var newImageUrl = await _fileStorageService.UploadImageAsync(
                    model.ImageFile,
                    Enums.FolderName.TrainingCoverImages.GetDescription());
                training.CoverImageUrl = newImageUrl;
            }

            _repository.Update(training, currentUserId);
            await _unitOfWork.SaveChangesAsync();

            if (!string.IsNullOrEmpty(oldImageUrl) && oldImageUrl != training.CoverImageUrl)
            {
                await _fileStorageService.DeleteImageAsync(oldImageUrl);
            }
        }

        public async Task IncrementViewCountAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            await _repository.IncrementViewCountAsync(trainingId, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Delete

        public async Task DeleteTrainingAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var training = await _repository.GetByIdWithDetailsAsync(id);

            if (training == null) return;

            var imageUrlToDelete = training.CoverImageUrl;

            if (training.Topics != null && training.Topics.Any())
            {
                foreach (var topic in training.Topics.ToList())
                {
                    await _topicRepository.DeleteAsync(topic.Id, currentUserId);
                }
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