using Lurnyx.Services.ServiceModels;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.WebApp.Models
{
    public class TrainingProgressDetailViewModel
    {
        public TrainingDto Training { get; set; }
        public UserTrainingProgressViewModel Progress { get; set; }
    }

    public class UserTrainingProgressViewModel
    {
        public TrainingProgressStatusValue? Status { get; set; }
        public bool IsStarted { get; set; }
        public bool IsEnrolled { get; set; }
        public bool IsCompleted { get; set; }
    }
}