using System.ComponentModel;

namespace Lurnyx.Resources.Constants
{
    /// <summary>
    /// Class for enumerated values
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// API Result Status
        /// </summary>
        public enum Status
        {
            Success,
            Error,
            CustomErr,
        }

        /// <summary>
        /// Login Result
        /// </summary>
        public enum LoginResult
        {
            Success = 0,
            Failed = 1,
        }

        public enum UserRole
        {
            [Description("Primarily given to developers.")]
            SUPER_ADMIN,
            [Description("Training creator or Instructor.")]
            ADMIN,
            [Description("Generic student.")]
            USER
        }

        /// <summary>
        /// User -> Training Only
        /// </summary>
        public enum TrainingProgressStatusValue
        {
            [Description("User at least clicked or viewed the training.")]
            VIEWED,
            [Description("User subscribed to a training.")]
            ENROLLED,
            [Description("User accessed at least one (1) topic.")]
            STARTED,
            [Description("User completed all the topic.")]
            COMPLETED
        }

        /// <summary>
        /// User -> Topic Only
        /// </summary>
        public enum TopicProgressStatusValue
        {
            [Description("User at least clicked or viewed the topic.")]
            VIEWED,
            [Description("User has officially started the topic.")]
            STARTED,
            [Description("User has completed the requirements of the topic.")]
            COMPLETED
        }

        public enum TrainingDifficulty
        {
            BEGINNER,
            INTERMEDIATE,
            ADVANCED
        }

        /// <summary>
        /// Defines the folder names used in cloud storage.
        /// Using an enum prevents typos and centralizes storage paths.
        /// </summary>
        public enum FolderName
        {
            [Description("user-profile-images")]
            UserProfileImages,

            [Description("training-category-images")]
            TrainingCategoryImages,

            [Description("training-cover-images")]
            TrainingCoverImages,

            [Description("topic-cover-images")]
            TopicCoverImages,

            [Description("resource-materials")]
            ResourceMaterials
        }
    }
}