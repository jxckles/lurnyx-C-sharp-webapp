using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lurnyx.Data.Migrations
{
    public partial class AddPasswordResetTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordResetToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetToken_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PasswordResetToken_User_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

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
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$1qH47CzzLgZsCqnT1WOL9.GSEbcXMnhDSt6B2GgqVMEJzWEo2BE82", "https://placehold.co/400x400/png", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$cDYVwMnEg40mLAfku91bzuP4dCDkjESZkaWUxDedX..PiG1nKaOGq", "https://placehold.co/400x400/png", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$BYHDdagUzAXy57XJwWsWcuFEAn0nGAaAHZR0jDC2kuZazCla/roWe", "https://placehold.co/400x400/png", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$QlcY6xkuYoApQ24bJVFeV.0NIjQUowkr7qSsXf3o34RwtpCXvo3US", "https://placehold.co/400x400/png", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993), "$2a$12$1TgO95lh/CXrSFgBWnjWj.Lm7QWdQwvVgASvNO0jjzISkB1IWNwpW", "https://placehold.co/400x400/png", new DateTime(2025, 6, 24, 5, 15, 48, 448, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetToken_CreatedBy",
                table: "PasswordResetToken",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetToken_Token",
                table: "PasswordResetToken",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetToken_UpdatedBy",
                table: "PasswordResetToken",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordResetToken");

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "ResourceMaterial",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "TrainingRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), "$2a$15$HE1QcaPGyjDQKmXyUrJWjuDX0fKoIka2i35x7pHY2UKiUEs0I9Q/u", null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), "$2a$15$wI.p3t2bh4fR54pvXjEwXu7GHtt5JIDY27VjxbGsAhLmnrMpIBGhO", null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), "$2a$15$cvwSHvFnhs1CLgc0JkjlluHqB4slWNO9IpHuE3sU.NhBJm7AGe6P.", null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), "$2a$15$E703lH1WB/tb4YSa4rtM7.B9wgOI9r35FBgyQnosmCn6WPckttOsy", null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "ProfileImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875), "$2a$15$gXxVb36zpCVezSI5hV.voeJo/1ybp3DAHpuuzkwotiG.8e/G/k5kS", null, new DateTime(2025, 6, 17, 7, 48, 39, 917, DateTimeKind.Utc).AddTicks(1875) });
        }
    }
}
