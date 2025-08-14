namespace Lurnyx.Services.ServiceModels
{
    public class TrainingRatingDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int ExistingRating { get; set; }
        public string ExistingComments { get; set; }
        public bool HasExistingRating { get; set; }

        #region Navigation Properties
        public int TrainingId { get; set; }
        public virtual TrainingDto Training { get; set; }

        #endregion

        #region Auditable Fields
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}