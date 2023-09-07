using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnlineCourseTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student_UserId",
                table: "User",
                column: "UserId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Student_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Student",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
