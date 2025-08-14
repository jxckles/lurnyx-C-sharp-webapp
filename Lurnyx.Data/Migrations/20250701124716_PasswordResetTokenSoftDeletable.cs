using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class PasswordResetTokenSoftDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PasswordResetToken",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "PasswordResetToken",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "$2a$12$YGAnB6p3SSSmX0qP9f0kJe1iy6zHSiVkcVcS7O6vIoGHzg0sJKmcK", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "$2a$12$zYfYrk0XdNS5N1P6pGt6EeL.AHwJ1w8cXc/Tx3qb4zXkOs1rzec/y", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "$2a$12$6WlpTr/KftpEmDKC/8ZrfORiKaG9dF0W2LGUj1AzhklNe7xEez1Em", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "$2a$12$2OUUt6xPaM30jF7m7z4T2.IKAaOePsS5G5DiciDYWt2RMrlC2a9e6", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243), "$2a$12$JTvstgwWvVHBUQcqrFNYf.DZGTos7CBUhKRuRuX0rqbHMitapCq3e", new DateTime(2025, 7, 1, 12, 47, 14, 388, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetToken_DeletedBy",
                table: "PasswordResetToken",
                column: "DeletedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordResetToken_User_DeletedBy",
                table: "PasswordResetToken",
                column: "DeletedBy",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordResetToken_User_DeletedBy",
                table: "PasswordResetToken");

            migrationBuilder.DropIndex(
                name: "IX_PasswordResetToken_DeletedBy",
                table: "PasswordResetToken");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PasswordResetToken");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PasswordResetToken");

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481), new DateTime(2025, 6, 27, 6, 14, 2, 179, DateTimeKind.Utc).AddTicks(481) });

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
    }
}
