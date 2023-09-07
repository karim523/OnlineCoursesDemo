using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WatchedLectureTable0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_Id",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_Id",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture");

            migrationBuilder.DropTable(
                name: "StudentsSubscriptions");

            migrationBuilder.RenameColumn(
                name: "WatchedData",
                table: "WatchedLecture",
                newName: "WatchedDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LectureId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "StudentSubscription",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubscription", x => new { x.StudentId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_StudentSubscription_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubscription_Subscription_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubscription_SubscriptionsId",
                table: "StudentSubscription",
                column: "SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture");

            migrationBuilder.DropTable(
                name: "StudentSubscription");

            migrationBuilder.RenameColumn(
                name: "WatchedDate",
                table: "WatchedLecture",
                newName: "WatchedData");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LectureId",
                table: "WatchedLecture",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudentsSubscriptions",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubscriptions", x => new { x.StudentId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_StudentsSubscriptions_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubscriptions_Subscription_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubscriptions_SubscriptionsId",
                table: "StudentsSubscriptions",
                column: "SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_Id",
                table: "WatchedLecture",
                column: "Id",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Lecture_LectureId",
                table: "WatchedLecture",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_Id",
                table: "WatchedLecture",
                column: "Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchedLecture_Student_StudentId",
                table: "WatchedLecture",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
