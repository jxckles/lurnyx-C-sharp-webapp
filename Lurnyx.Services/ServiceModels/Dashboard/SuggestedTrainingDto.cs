
namespace Lurnyx.Services.ServiceModels
{
    /// <summary>
    /// DTO for a single suggested training card.
    /// </summary>
    public class SuggestedTrainingDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
