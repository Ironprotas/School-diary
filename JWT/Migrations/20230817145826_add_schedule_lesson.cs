using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JWT.Migrations
{
    /// <inheritdoc />
    public partial class add_schedule_lesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schedules_scheduleId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_scheduleId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "scheduleId",
                table: "Lessons");

            migrationBuilder.CreateTable(
                name: "ScheduleLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleLessons_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLessons_LessonId",
                table: "ScheduleLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLessons_ScheduleId",
                table: "ScheduleLessons",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleLessons");

            migrationBuilder.AddColumn<int>(
                name: "scheduleId",
                table: "Lessons",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_scheduleId",
                table: "Lessons",
                column: "scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schedules_scheduleId",
                table: "Lessons",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}
