using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1, null, null, "superadmin@lurnyx.com", "Super", "Admin", "$2a$15$HE1QcaPGyjDQKmXyUrJWjuDX0fKoIka2i35x7pHY2UKiUEs0I9Q/u", null, "SUPER_ADMIN", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "admin@lurnyx.com", "Admin", "User", "$2a$15$wI.p3t2bh4fR54pvXjEwXu7GHtt5JIDY27VjxbGsAhLmnrMpIBGhO", null, "ADMIN", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 3, null, null, "user@lurnyx.com", "Generic", "User", "$2a$15$cvwSHvFnhs1CLgc0JkjlluHqB4slWNO9IpHuE3sU.NhBJm7AGe6P.", null, "USER", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 3 });

            migrationBuilder.InsertData(
                table: "TrainingCategory",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "https://placehold.co/600x400/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Learn programming languages", "Programming", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 2, "https://placehold.co/600x400/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Explore data science concepts", "Data Science", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 3, "https://placehold.co/600x400/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Build modern web applications", "Web Development", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 4, "https://placehold.co/600x400/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Create mobile applications", "Mobile Development", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 5, "https://placehold.co/600x400/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Learn machine learning techniques", "Machine Learning", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FirstName", "LastName", "Password", "ProfileImageUrl", "Role", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1, null, null, "john.doe@lurnyx.com", "John", "Doe", "$2a$15$E703lH1WB/tb4YSa4rtM7.B9wgOI9r35FBgyQnosmCn6WPckttOsy", null, "USER", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1 },
                    { 5, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1, null, null, "jane.smith@lurnyx.com", "Jane", "Smith", "$2a$15$gXxVb36zpCVezSI5hV.voeJo/1ybp3DAHpuuzkwotiG.8e/G/k5kS", null, "USER", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 1 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "https://placehold.co/600x300/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Learn the basics of programming.", "BEGINNER", true, "Introduction to Programming", 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 2, "https://placehold.co/600x300/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Deep dive into data science techniques.", "ADVANCED", true, "Advanced Data Science", 2, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, "https://placehold.co/600x300/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Build modern web applications.", "INTERMEDIATE", "Web Development Essentials", 3, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, "https://placehold.co/600x300/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Create mobile applications for Android and iOS.", "INTERMEDIATE", true, "Mobile App Development", 4, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 5, "https://placehold.co/600x300/png", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Learn the fundamentals of machine learning.", "BEGINNER", "Machine Learning Basics", 5, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Difficulty", "IsFeatured", "Title", "TrainingCategoryId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 6, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Build modern web apps with .NET.", "BEGINNER", true, "Introduction to ASP.NET Core", 3, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "DurationInMinutes", "Order", "Title", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "An overview of programming concepts.", 25, 1, "What is Programming?", 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 2, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Understanding how to store information.", 45, 2, "Variables and Data Types", 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 3, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Setting up your development environment.", 30, 1, "Getting Started", 6, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 4, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "The Model-View-Controller pattern.", 60, 2, "Understanding MVC", 6, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 },
                    { 5, null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "Using Entity Framework Core.", 90, 3, "Working with Data", 6, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 }
                });

            migrationBuilder.InsertData(
                table: "TrainingRating",
                columns: new[] { "Id", "Comments", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Rating", "TrainingId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Excellent course for beginners!", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 4, null, null, 5, 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 4 },
                    { 2, "Good content, but could use more examples.", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 5, null, null, 4, 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 5 },
                    { 3, "Very detailed and informative.", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 4, null, null, 5, 2, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 4 },
                    { 4, "Great introduction to .NET!", new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 5, null, null, 5, 6, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 5 }
                });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "/downloads/setup-guide.pdf", 1024, "PDF", null, "Setup Guide", 3, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "https://placehold.co/600x400/png", 256, "PNG", null, "MVC Diagram", 4, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });

            migrationBuilder.InsertData(
                table: "ResourceMaterial",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "TopicId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2, null, null, "/downloads/sample-project.zip", 5120, "ZIP", null, "Sample Project", 5, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
