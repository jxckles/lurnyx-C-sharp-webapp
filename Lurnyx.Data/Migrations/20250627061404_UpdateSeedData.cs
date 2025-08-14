using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TrainingCategoryId",
                table: "Training",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Metadata",
                table: "ResourceMaterial",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "ResourceMaterial",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FileAccessUrl",
                table: "ResourceMaterial",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/dummy.pdf", 13264, "1 page", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/png.png", 7347, "1 diagram", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "https://gxedokotpvohancdflmb.supabase.co/storage/v1/object/public/lurnyx-files/seeder-files/sample1.pptx", 34789, "PPTX", "1 slide", "Sample PowerPoint Presentation", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/344x242/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { "https://placehold.co/600x300/png", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "$2a$12$LGWs/59DfMfKrTH/cy/JGOJGvnqdvhgYEjT/95/Vny0Fpy55Dmg8q", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "$2a$12$iEP7oK0Zf2NRg4zz/CwhKeNTf1m1RNtE1nqEHvDcWno2olc.QaTBm", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "$2a$12$qTBaOMNwrvr2KmSrvN1GLu87xziwK28rJduager8v.pkXeSyPSxE6", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "$2a$12$dm2nQgpcm6dZfxPTr82u8.in9ptPBCZw0UHrCFh8dUCowSAyvP5KW", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), "$2a$12$sXezXLa4khYO5QwKc.hsWuiFrUT1QISqWLv4jqabIfdoio1zQiq6.", new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TrainingCategoryId",
                table: "Training",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Metadata",
                table: "ResourceMaterial",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "ResourceMaterial",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "FileAccessUrl",
                table: "ResourceMaterial",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "/downloads/setup-guide.pdf", 1024, null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "Metadata", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "https://placehold.co/600x400/png", 256, null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "FileAccessUrl", "FileSize", "FileType", "Metadata", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "/downloads/sample-project.zip", 5120, "ZIP", null, "Sample Project", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CoverImageUrl", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$1qH47CzzLgZsCqnT1WOL9.GSEbcXMnhDSt6B2GgqVMEJzWEo2BE82", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$cDYVwMnEg40mLAfku91bzuP4dCDkjESZkaWUxDedX..PiG1nKaOGq", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$BYHDdagUzAXy57XJwWsWcuFEAn0nGAaAHZR0jDC2kuZazCla/roWe", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$QlcY6xkuYoApQ24bJVFeV.0NIjQUowkr7qSsXf3o34RwtpCXvo3US", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$1TgO95lh/CXrSFgBWnjWj.Lm7QWdQwvVgASvNO0jjzISkB1IWNwpW", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });
        }
    }
}
