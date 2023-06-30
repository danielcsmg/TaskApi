using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class RenameTaskAndActivitiesToWorkTasksWorkActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "WorkTasks");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "WorkActivities");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_WorkTaskId",
                table: "WorkActivities",
                newName: "IX_WorkActivities_WorkTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkActivities",
                table: "WorkActivities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_WorkTasks_WorkTaskId",
                table: "TasksCategories",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkActivities_WorkTasks_WorkTaskId",
                table: "WorkActivities",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_WorkTasks_WorkTaskId",
                table: "TasksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkActivities_WorkTasks_WorkTaskId",
                table: "WorkActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTasks",
                table: "WorkTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkActivities",
                table: "WorkActivities");

            migrationBuilder.RenameTable(
                name: "WorkTasks",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "WorkActivities",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_WorkActivities_WorkTaskId",
                table: "Activities",
                newName: "IX_Activities_WorkTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
