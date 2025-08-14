
namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// DTO for the user's learning progress metrics.
    /// </summary>
    public class LearningProgressDto
    {
        public int CompletionRate { get; set; }
        public int TotalCompletedTrainings { get; set; }
        public int TotalTrainings { get; set; }
        public int StudyStreak { get; set; }
        public double AverageRating { get; set; }
    }
}
