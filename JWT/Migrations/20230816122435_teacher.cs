using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT.Migrations
{
    /// <inheritdoc />
    public partial class teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassTeacherId",
                table: "Classes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkClassId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkClassId",
                table: "AspNetUsers",
                column: "WorkClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_WorkClassId",
                table: "AspNetUsers",
                column: "WorkClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_WorkClassId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassTeacherId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "WorkClassId",
                table: "AspNetUsers");
        }
    }
}
