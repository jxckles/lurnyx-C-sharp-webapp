using Lurnyx.Data.Models;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data
{
    public static class UserTopicProgressSeeder
    {
        public static List<UserTopicProgress> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            var userId = 3; // Corresponds to user@lurnyx.com

            var progressList = new List<UserTopicProgress>
            {
                new UserTopicProgress 
                { 
                    Id = 1, 
                    Status = TopicProgressStatusValue.STARTED, 
                    StartedAt = now, 
                    CompletedAt = null,
                    LastAccessedAt = now, 
                    TopicId = 1, 
                    ViewCount = 2, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now, 
                    UpdatedAt = now 
                },
                new UserTopicProgress 
                { 
                    Id = 2, 
                    Status = TopicProgressStatusValue.COMPLETED, 
                    StartedAt = now.AddDays(-8), 
                    CompletedAt = now.AddDays(-8), 
                    LastAccessedAt = now.AddDays(-8), 
                    TopicId = 2, 
                    ViewCount = 1, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now.AddDays(-8), 
                    UpdatedAt = now.AddDays(-8) 
                },
                new UserTopicProgress 
                { 
                    Id = 3, 
                    Status = TopicProgressStatusValue.COMPLETED, 
                    StartedAt = now.AddDays(-9), 
                    CompletedAt = now.AddDays(-9), 
                    LastAccessedAt = now.AddDays(-9), 
                    TopicId = 6, 
                    ViewCount = 1, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now.AddDays(-9), 
                    UpdatedAt = now.AddDays(-9) 
                },
                new UserTopicProgress 
                { 
                    Id = 4, 
                    Status = TopicProgressStatusValue.COMPLETED, 
                    StartedAt = now.AddDays(-10), 
                    CompletedAt = now.AddDays(-10), 
                    LastAccessedAt = now.AddDays(-10), 
                    TopicId = 9, 
                    ViewCount = 1, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now.AddDays(-10), 
                    UpdatedAt = now.AddDays(-10) 
                },
                new UserTopicProgress 
                { 
                    Id = 5, 
                    Status = TopicProgressStatusValue.COMPLETED, 
                    StartedAt = now.AddDays(-11), 
                    CompletedAt = now.AddDays(-11), 
                    LastAccessedAt = now.AddDays(-11), 
                    TopicId = 13, 
                    ViewCount = 1, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now.AddDays(-11), 
                    UpdatedAt = now.AddDays(-11) 
                },
                new UserTopicProgress 
                { 
                    Id = 6, 
                    Status = TopicProgressStatusValue.COMPLETED, 
                    StartedAt = now.AddDays(-12), 
                    CompletedAt = now.AddDays(-12), 
                    LastAccessedAt = now.AddDays(-12), 
                    TopicId = 17, 
                    ViewCount = 1, 
                    CreatedBy = userId, 
                    UpdatedBy = userId, 
                    CreatedAt = now.AddDays(-12), 
                    UpdatedAt = now.AddDays(-12) 
                },
            };

            return progressList;
        }
    }
}
