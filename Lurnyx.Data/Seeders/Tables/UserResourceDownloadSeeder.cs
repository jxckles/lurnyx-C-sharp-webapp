using Lurnyx.Data.Models;

namespace Lurnyx.Data
{
    public static class UserResourceDownloadSeeder
    {
        public static List<UserResourceDownload> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            var userId = 3; // Corresponds to user@lurnyx.com

            var downloads = new List<UserResourceDownload>
            {
                new UserResourceDownload
                {
                    Id = 1,
                    DownloadCount = 1,
                    FirstDownloadedAt = now.AddHours(-2),
                    LastDownloadedAt = now.AddHours(-2),
                    ResourceMaterialId = 4, 
                    CreatedBy = userId,
                    UpdatedBy = userId,
                    CreatedAt = now.AddHours(-2),
                    UpdatedAt = now.AddHours(-2)
                }
            };

            return downloads;
        }
    }
}
