using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class UpdateActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
