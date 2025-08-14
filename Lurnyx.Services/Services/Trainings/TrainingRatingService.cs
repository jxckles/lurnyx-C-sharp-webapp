using AutoMapper;
using Lurnyx.Data.Interfaces;
using Lurnyx.Data.Interfaces.Trainings;
using Lurnyx.Data.Models;
using Lurnyx.Services.Interfaces;
using Lurnyx.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lurnyx.Services.Services
{
    /// <summary>
    /// Service for managing Training Ratings, aligned with the generic repository pattern.
    /// </summary>
    public class TrainingRatingService : ServiceBase, ITrainingRatingService
    {
        private readonly ITrainingRatingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingRatingService(
            ITrainingRatingRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILoggerFactory loggerFactory) : base(httpContextAccessor, loggerFactory)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create / Update

        public async Task SubmitRatingAsync(int trainingId, int rating, string comment)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var existingRating = await _repository.FindByUserAndTrainingAsync(currentUserId, trainingId);

            if (existingRating != null)
            {
                existingRating.Rating = rating;
                existingRating.Comments = comment;

                _repository.Update(existingRating, currentUserId);
            }
            else
            {
                var newRating = new TrainingRating
                {
                    TrainingId = trainingId,
                    Rating = rating,
                    Comments = comment
                };

                await _repository.AddAsync(newRating, currentUserId);
            }

            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Read

        public async Task<PaginatedList<TrainingRatingDto>> GetPaginatedAndFilteredWithDetailsAsync(
            int pageNumber, int pageSize, string searchQuery, string ratingFilter, string categoryFilter)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var paginatedRatings = await _repository.GetPaginatedAndFilteredWithDetailsAsync(
                pageNumber, pageSize, searchQuery, ratingFilter, categoryFilter, currentUserId);

            var trainingRatingViewModels = _mapper.Map<List<TrainingRatingDto>>(paginatedRatings.Items);

            return new PaginatedList<TrainingRatingDto>(
                trainingRatingViewModels,
                paginatedRatings.TotalCount,
                paginatedRatings.PageNumber,
                pageSize);
        }

        public async Task<TrainingRatingDto> GetTrainingRatingByIdAsync(int id)
        {
            var trainingRating = await _repository.GetByIdWithDetailsAsync(id);

            return _mapper.Map<TrainingRatingDto>(trainingRating);
        }

        public async Task<TrainingRatingSummaryDto> GetRatingSummaryForTrainingAsync(int trainingId)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var summary = new TrainingRatingSummaryDto();

            var ratings = await _repository.GetAllByTrainingIdAsync(trainingId);

            if (ratings != null && ratings.Any())
            {
                summary.AverageRating = ratings.Average(r => r.Rating);
                summary.RatingCount = ratings.Count;

                var userRatingEntity = ratings.FirstOrDefault(r => r.CreatedBy == currentUserId);
                if (userRatingEntity != null)
                {
                    summary.UserRating = _mapper.Map<TrainingRatingDto>(userRatingEntity);
                    summary.UserRating.HasExistingRating = true;
                }
            }

            summary.UserRating ??= new TrainingRatingDto { HasExistingRating = false, TrainingId = trainingId };

            return summary;
        }

        #endregion

        #region Update

        public async Task UpdateTrainingRatingAsync(TrainingRatingDto model)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var trainingRating = await _repository.GetByIdAsync(model.Id);

            if (trainingRating == null)
            {
                throw new KeyNotFoundException(Resources.Messages.Errors.RatingDoesNotExist);
            }

            if (trainingRating.CreatedBy != currentUserId)
            {
                throw new UnauthorizedAccessException("You can only update your own ratings.");
            }

            trainingRating.Rating = model.Rating;
            trainingRating.Comments = model.Comments;

            _repository.Update(trainingRating, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Delete

        public async Task DeleteTrainingRatingAsync(int id)
        {
            var currentUserId = GetCurrentUserId();
            EnsureUserIsAuthenticated(currentUserId);

            var ratingToDelete = await _repository.GetByIdAsync(id);

            if (ratingToDelete.CreatedBy != currentUserId)
            {
                throw new UnauthorizedAccessException("You can only delete your own ratings.");
            }

            await _repository.DeleteAsync(id, currentUserId);
            await _unitOfWork.SaveChangesAsync();
        }
        
        #endregion
    }
}