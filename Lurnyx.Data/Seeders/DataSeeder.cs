using Lurnyx.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lurnyx.Data {
    /// <summary>
    /// A static class to provide initial data for the database.
    /// </summary>
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(UserSeeder.Seed());

            // Trainings
            modelBuilder.Entity<TrainingCategory>().HasData(TrainingCategorySeeder.Seed());
            modelBuilder.Entity<Training>().HasData(TrainingSeeder.Seed());
            modelBuilder.Entity<Topic>().HasData(TopicSeeder.Seed());
            modelBuilder.Entity<ResourceMaterial>().HasData(ResourceMaterialSeeder.Seed());
            
            // KJA: Removed these seeder data as to to avoid data inconsistencies upon testing.
            // modelBuilder.Entity<TrainingRating>().HasData(TrainingRatingSeeder.Seed());

            // User Activity
            // modelBuilder.Entity<UserTrainingProgress>().HasData(UserTrainingProgressSeeder.Seed());
            // modelBuilder.Entity<UserTopicProgress>().HasData(UserTopicProgressSeeder.Seed());
            // modelBuilder.Entity<UserResourceDownload>().HasData(UserResourceDownloadSeeder.Seed());
        }
    }
}