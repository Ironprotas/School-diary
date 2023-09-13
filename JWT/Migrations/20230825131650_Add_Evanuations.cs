using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JWT.Migrations
{
    /// <inheritdoc />
    public partial class Add_Evanuations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Cabinet",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "EndLesson",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StartLesson",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "AspNetUsers",
                newName: "ParentId");

            migrationBuilder.AddColumn<int>(
                name: "SettingsLessonId",
                table: "ScheduleLessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    Evaluaton = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingsLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cabinet = table.Column<int>(type: "integer", nullable: false),
                    StartLesson = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndLesson = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TeacherId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingsLessons_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLessons_SettingsLessonId",
                table: "ScheduleLessons",
                column: "SettingsLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_LessonId",
                table: "Evaluations",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_UserId",
                table: "Evaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsLessons_TeacherId",
                table: "SettingsLessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleLessons_SettingsLessons_SettingsLessonId",
                table: "ScheduleLessons",
                column: "SettingsLessonId",
                principalTable: "SettingsLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleLessons_SettingsLessons_SettingsLessonId",
                table: "ScheduleLessons");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "SettingsLessons");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleLessons_SettingsLessonId",
                table: "ScheduleLessons");

            migrationBuilder.DropColumn(
                name: "SettingsLessonId",
                table: "ScheduleLessons");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "AspNetUsers",
                newName: "StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Cabinet",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndLesson",
                table: "Lessons",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartLesson",
                table: "Lessons",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Lessons",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
