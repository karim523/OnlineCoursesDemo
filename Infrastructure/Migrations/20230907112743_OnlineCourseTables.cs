using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnlineCourseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId1",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_StudentId1",
                table: "WatchedLecture");

            migrationBuilder.DropIndex(
                name: "IX_WatchedLecture_LectureId1",
                table: "WatchedLecture");

            migrationBuilder.DropIndex(
                name: "IX_WatchedLecture_StudentId1",
                table: "WatchedLecture");

            migrationBuilder.DropColumn(
                name: "LectureId1",
                table: "WatchedLecture");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "WatchedLecture");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_Id",
                table: "WatchedLecture",
                column: "Id",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_Id",
                table: "WatchedLecture",
                column: "Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_Id",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_Id",
                table: "WatchedLecture");

            migrationBuilder.AddColumn<Guid>(
                name: "LectureId1",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId1",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchedLecture_LectureId1",
                table: "WatchedLecture",
                column: "LectureId1");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedLecture_StudentId1",
                table: "WatchedLecture",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId1",
                table: "WatchedLecture",
                column: "LectureId1",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_StudentId1",
                table: "WatchedLecture",
                column: "StudentId1",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
