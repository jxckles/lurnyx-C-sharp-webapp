using Lurnyx.Data.Models;
using static Lurnyx.Resources.Constants.Enums;

namespace Lurnyx.Data
{
    public static class UserSeeder
    {
        public static List<User> Seed()
        {
            var now = DateTime.Parse("2025-07-10T12:55:00Z").ToUniversalTime();
            int workFactor = 12;

            var users = new List<User> {
                new User {
                    Id = 1,
                    FirstName = "SuperAdmin",
                    LastName = "Account",
                    Email = "superadmin@lurnyx.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("superadmin", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.SUPER_ADMIN,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Account",
                    Email = "admin@lurnyx.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.ADMIN,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 3,
                    FirstName = "User",
                    LastName = "Account",
                    Email = "user@lurnyx.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("user", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 4,
                    FirstName = "Michael",
                    LastName = "Thompson",
                    Email = "michael.t@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 5,
                    FirstName = "Sarah",
                    LastName = "Martinez",
                    Email = "sarah_martinez@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 6,
                    FirstName = "David",
                    LastName = "Lee",
                    Email = "davidlee88@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 7,
                    FirstName = "Jessica",
                    LastName = "Harris",
                    Email = "jessharris@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 8,
                    FirstName = "Daniel",
                    LastName = "Nelson",
                    Email = "dan.nelson@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 9,
                    FirstName = "Olivia",
                    LastName = "Carter",
                    Email = "olivia.carterwork@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 10,
                    FirstName = "Robert",
                    LastName = "Baker",
                    Email = "robertbaker@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 11,
                    FirstName = "Sophia",
                    LastName = "Green",
                    Email = "sophia.green2023@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 12,
                    FirstName = "William",
                    LastName = "Adams",
                    Email = "will.adams@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 13,
                    FirstName = "Ava",
                    LastName = "Hall",
                    Email = "ava.hall5@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 14,
                    FirstName = "Christopher",
                    LastName = "Young",
                    Email = "cyoung@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 15,
                    FirstName = "Mia",
                    LastName = "Allen",
                    Email = "mia_allen@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 16,
                    FirstName = "Matthew",
                    LastName = "King",
                    Email = "matthewking@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 17,
                    FirstName = "Charlotte",
                    LastName = "Scott",
                    Email = "charlotte.scott@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 18,
                    FirstName = "Andrew",
                    LastName = "Wright",
                    Email = "andrew_wright@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 19,
                    FirstName = "Amelia",
                    LastName = "Torres",
                    Email = "amtorres@outlook.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 20,
                    FirstName = "Ethan",
                    LastName = "Nguyen",
                    Email = "ethan.nguyen@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new User {
                    Id = 21,
                    FirstName = "Harper",
                    LastName = "Evans",
                    Email = "harper.evans99@yahoo.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("@deFaultPass12", workFactor),
                    ProfileImageUrl = null,
                    Role = UserRole.USER,
                    CreatedAt = now,
                    UpdatedAt = now,
                    CreatedBy = 1,
                    UpdatedBy = 1
                }
            };
            return users;
        }
    }
}
