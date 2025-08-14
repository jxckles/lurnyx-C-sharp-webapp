using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class FullDomainModelSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__1788CC4D5F4A160F",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TrainingCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCategory_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCategory_User_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCategory_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrainingCategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_TrainingCategory_TrainingCategoryId",
                        column: x => x.TrainingCategoryId,
                        principalTable: "TrainingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_User_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topic_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_User_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingRating_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingRating_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingRating_User_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingRating_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTrainingProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainingProgress_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrainingProgress_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTrainingProgress_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResourceMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FileAccessUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceMaterial_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceMaterial_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceMaterial_User_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResourceMaterial_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTopicProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopicProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTopicProgress_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopicProgress_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTopicProgress_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserResourceDownload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FirstDownloadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDownloadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResourceMaterialId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResourceDownload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResourceDownload_ResourceMaterial_ResourceMaterialId",
                        column: x => x.ResourceMaterialId,
                        principalTable: "ResourceMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResourceDownload_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserResourceDownload_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedBy",
                table: "User",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_DeletedBy",
                table: "User",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedBy",
                table: "User",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_resource_topic",
                table: "ResourceMaterial",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceMaterial_CreatedBy",
                table: "ResourceMaterial",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceMaterial_DeletedBy",
                table: "ResourceMaterial",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceMaterial_UpdatedBy",
                table: "ResourceMaterial",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_topic_training",
                table: "Topic",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_CreatedBy",
                table: "Topic",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_DeletedBy",
                table: "Topic",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_UpdatedBy",
                table: "Topic",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_training_category",
                table: "Training",
                column: "TrainingCategoryId");

            migrationBuilder.CreateIndex(
                name: "idx_training_title",
                table: "Training",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Training_CreatedBy",
                table: "Training",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Training_DeletedBy",
                table: "Training",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UpdatedBy",
                table: "Training",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_CreatedBy",
                table: "TrainingCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_DeletedBy",
                table: "TrainingCategory",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_Name",
                table: "TrainingCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_UpdatedBy",
                table: "TrainingCategory",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_rating_training",
                table: "TrainingRating",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "idx_training_rating_user",
                table: "TrainingRating",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRating_DeletedBy",
                table: "TrainingRating",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRating_UpdatedBy",
                table: "TrainingRating",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_download_time",
                table: "UserResourceDownload",
                column: "LastDownloadedAt");

            migrationBuilder.CreateIndex(
                name: "idx_download_user",
                table: "UserResourceDownload",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserResourceDownload_ResourceMaterialId",
                table: "UserResourceDownload",
                column: "ResourceMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResourceDownload_UpdatedBy",
                table: "UserResourceDownload",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_topic_access_time",
                table: "UserTopicProgress",
                column: "LastAccessedAt");

            migrationBuilder.CreateIndex(
                name: "idx_topic_progress_status",
                table: "UserTopicProgress",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicProgress_CreatedBy_TopicId",
                table: "UserTopicProgress",
                columns: new[] { "CreatedBy", "TopicId" },
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicProgress_TopicId",
                table: "UserTopicProgress",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicProgress_UpdatedBy",
                table: "UserTopicProgress",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "idx_training_access_time",
                table: "UserTrainingProgress",
                column: "LastAccessedAt");

            migrationBuilder.CreateIndex(
                name: "idx_training_progress_status",
                table: "UserTrainingProgress",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingProgress_CreatedBy_TrainingId",
                table: "UserTrainingProgress",
                columns: new[] { "CreatedBy", "TrainingId" },
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingProgress_TrainingId",
                table: "UserTrainingProgress",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingProgress_UpdatedBy",
                table: "UserTrainingProgress",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedBy",
                table: "User",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_DeletedBy",
                table: "User",
                column: "DeletedBy",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UpdatedBy",
                table: "User",
                column: "UpdatedBy",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedBy",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_DeletedBy",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UpdatedBy",
                table: "User");

            migrationBuilder.DropTable(
                name: "TrainingRating");

            migrationBuilder.DropTable(
                name: "UserResourceDownload");

            migrationBuilder.DropTable(
                name: "UserTopicProgress");

            migrationBuilder.DropTable(
                name: "UserTrainingProgress");

            migrationBuilder.DropTable(
                name: "ResourceMaterial");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "TrainingCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedBy",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DeletedBy",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__1788CC4D5F4A160F",
                table: "Users",
                column: "UserId",
                unique: true);
        }
    }
}
