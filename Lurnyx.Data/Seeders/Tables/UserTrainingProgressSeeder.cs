using Lurnyx.Data.Models;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data
{
    public static class UserTrainingProgressSeeder
    {
        public static List<UserTrainingProgress> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            var userId = 3; // Corresponds to user@lurnyx.com

            var progressList = new List<UserTrainingProgress>
            {
                // Most Viewed Training: (TrainingId = 1)
                new UserTrainingProgress
                {
                    Id = 1,
                    Status = TrainingProgressStatusValue.COMPLETED,
                    StartedAt = now.AddDays(-20),
                    CompletedAt = now.AddDays(-18),
                    LastAccessedAt = now.AddDays(-18),
                    TrainingId = 1,
                    ViewCount = 10,
                    CreatedBy = userId,
                    UpdatedBy = userId,
                    CreatedAt = now.AddDays(-20),
                    UpdatedAt = now.AddDays(-18)
                },
                // Recent Activity: (TrainingId = 4)
                new UserTrainingProgress
                {
                    Id = 2,
                    Status = TrainingProgressStatusValue.STARTED,
                    StartedAt = now.AddDays(-3),
                    CompletedAt = null,
                    LastAccessedAt = now.AddDays(-3),
                    TrainingId = 4,
                    ViewCount = 5,
                    CreatedBy = userId,
                    UpdatedBy = userId,
                    CreatedAt = now.AddDays(-3),
                    UpdatedAt = now.AddDays(-3)
                },
                // Recent Activity: (TrainingId = 5)
                new UserTrainingProgress
                {
                    Id = 3,
                    Status = TrainingProgressStatusValue.COMPLETED,
                    StartedAt = now.AddDays(-8),
                    CompletedAt = now.AddDays(-7),
                    LastAccessedAt = now.AddDays(-7),
                    TrainingId = 5,
                    ViewCount = 3,
                    CreatedBy = userId,
                    UpdatedBy = userId,
                    CreatedAt = now.AddDays(-8),
                    UpdatedAt = now.AddDays(-7)
                },
                // Additional completed trainings to achieve ~87% completion rate (7/8)
                new UserTrainingProgress { Id = 4, Status = TrainingProgressStatusValue.COMPLETED, StartedAt = now.AddDays(-2), CompletedAt = now.AddDays(-1), LastAccessedAt = now.AddDays(-1), TrainingId = 6, ViewCount = 1, CreatedBy = userId, UpdatedBy = userId, CreatedAt = now.AddDays(-2), UpdatedAt = now.AddDays(-1) },
                new UserTrainingProgress { Id = 5, Status = TrainingProgressStatusValue.COMPLETED, StartedAt = now.AddDays(-3), CompletedAt = now.AddDays(-2), LastAccessedAt = now.AddDays(-2), TrainingId = 7, ViewCount = 1, CreatedBy = userId, UpdatedBy = userId, CreatedAt = now.AddDays(-3), UpdatedAt = now.AddDays(-2) },
                new UserTrainingProgress { Id = 6, Status = TrainingProgressStatusValue.COMPLETED, StartedAt = now.AddDays(-5), CompletedAt = now.AddDays(-4), LastAccessedAt = now.AddDays(-4), TrainingId = 8, ViewCount = 1, CreatedBy = userId, UpdatedBy = userId, CreatedAt = now.AddDays(-5), UpdatedAt = now.AddDays(-4) },
                new UserTrainingProgress { Id = 7, Status = TrainingProgressStatusValue.COMPLETED, StartedAt = now.AddDays(-6), CompletedAt = now.AddDays(-5), LastAccessedAt = now.AddDays(-5), TrainingId = 9, ViewCount = 1, CreatedBy = userId, UpdatedBy = userId, CreatedAt = now.AddDays(-6), UpdatedAt = now.AddDays(-5) },
                new UserTrainingProgress { Id = 8, Status = TrainingProgressStatusValue.COMPLETED, StartedAt = now.AddDays(-7), CompletedAt = now.AddDays(-6), LastAccessedAt = now.AddDays(-6), TrainingId = 10, ViewCount = 1, CreatedBy = userId, UpdatedBy = userId, CreatedAt = now.AddDays(-7), UpdatedAt = now.AddDays(-6) },
            };

            return progressList;
        }
    }
}
