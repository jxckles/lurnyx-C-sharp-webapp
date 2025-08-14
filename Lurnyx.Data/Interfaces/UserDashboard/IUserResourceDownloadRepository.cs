using Lurnyx.Data.Models;

namespace Lurnyx.Data.Interfaces.Users
{
    /// <summary>
    /// Defines the contract for a repository that handles data operations for UserResourceDownload entities.
    /// This entity is not soft-deletable.
    /// </summary>
    public interface IUserResourceDownloadRepository
    {
        /// <summary>
        /// Adds a new UserResourceDownload record to the database.
        /// </summary>
        /// <param name="download">The download entity to add.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        Task AddAsync(UserResourceDownload download, int currentUserId);

        /// <summary>
        /// Gets a user's specific resource download record.
        /// </summary>
        Task<UserResourceDownload?> GetResourceDownloadAsync(int userId, int resourceMaterialId);

        /// <summary>
        /// Gets all resource download records for a specific user.
        /// </summary>
        Task<List<UserResourceDownload>> GetAllResourceDownloadsAsync(int userId);

        /// <summary>
        /// Gets a list of the most recent resource download records for a user.
        /// </summary>
        Task<List<UserResourceDownload>> GetRecentResourceDownloadsAsync(int userId, int count);

        /// <summary>
        /// Gets a list of all dates a user downloaded resources.
        /// </summary>
        Task<List<DateTime>> GetDownloadActivityDatesAsync(int userId);

        /// <summary>
        /// Retrieves all resource download records for a specific user and topic.
        /// </summary>
        /// <param name="userId">The ID of the user whose download records are being retrieved.</param>
        /// <param name="topicId">The ID of the topic to filter download records by.</param>
        /// <returns>A list of resource downloads associated with the specified user and topic.</returns>
        Task<List<UserResourceDownload>> GetDownloadsForTopicAsync(int userId, int topicId);
        
        /// <summary>
        /// Updates an existing UserResourceDownload record in the database.
        /// </summary>
        /// <param name="download">The download entity to update.</param>
        /// <param name="currentUserId">The ID of the user performing the action.</param>
        void Update(UserResourceDownload download, int currentUserId);
    }
}
