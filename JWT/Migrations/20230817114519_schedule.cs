using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT.Migrations
{
    /// <inheritdoc />
    public partial class schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Lessons",
                newName: "scheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_ScheduleId",
                table: "Lessons",
                newName: "IX_Lessons_scheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schedules_scheduleId",
                table: "Lessons",
                column: "scheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schedules_scheduleId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "scheduleId",
                table: "Lessons",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_scheduleId",
                table: "Lessons",
                newName: "IX_Lessons_ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}
