using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WatchedLectureTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture");

            migrationBuilder.DropIndex(
                name: "IX_WatchedLecture_LectureId",
                table: "WatchedLecture");

            migrationBuilder.DropIndex(
                name: "IX_WatchedLecture_StudentId",
                table: "WatchedLecture");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "WatchedLecture");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "WatchedLecture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LectureId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchedLecture_LectureId",
                table: "WatchedLecture",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedLecture_StudentId",
                table: "WatchedLecture",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
