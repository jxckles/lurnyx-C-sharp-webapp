namespace Lurnyx.Services.ServiceModels
{
    public class TrainingRatingSummaryDto
    {
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public TrainingRatingDto UserRating { get; set; }
    }
}