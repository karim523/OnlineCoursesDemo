using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnlineCourseTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItem_Career_CareerId",
                table: "CareerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CareerItem_Course_CourseId",
                table: "CareerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Module_ModuleId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Student_StudentId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Student_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_StudentId",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "DateOfWatchingOfLect",
                table: "WatchedLecture",
                newName: "WatchingData");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "Subscription",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Module",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "Lecture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Course",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CareerItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CareerId",
                table: "CareerItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Career",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Article",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubscriptions_SubscriptionsId",
                table: "StudentsSubscriptions",
                column: "SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItem_Career_CareerId",
                table: "CareerItem",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItem_Course_CourseId",
                table: "CareerItem",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Module_ModuleId",
                table: "Lecture",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                table: "Subscription",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student_UserId",
                table: "User",
                column: "UserId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItem_Career_CareerId",
                table: "CareerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CareerItem_Course_CourseId",
                table: "CareerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Module_ModuleId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Student_UserId",
                table: "User");

            migrationBuilder.DropTable(
                name: "StudentsSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "WatchingData",
                table: "WatchedLecture",
                newName: "DateOfWatchingOfLect");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                table: "Subscription",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Subscription",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Module",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "Lecture",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Course",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CareerItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CareerId",
                table: "CareerItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Career",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Article",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_StudentId",
                table: "Subscription",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItem_Career_CareerId",
                table: "CareerItem",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItem_Course_CourseId",
                table: "CareerItem",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Module_ModuleId",
                table: "Lecture",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                table: "Subscription",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Student_StudentId",
                table: "Subscription",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Student_UserId",
                table: "User",
                column: "UserId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
