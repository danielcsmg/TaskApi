using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class RefactorTaskCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Tasks_WorkTaskId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_Categories_CategoryId",
                table: "TasksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_WorkTaskId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "WorkTaskId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_Categories_CategoryId",
                table: "TasksCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_Categories_CategoryId",
                table: "TasksCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkTaskId",
                table: "Categories",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WorkTaskId",
                table: "Categories",
                column: "WorkTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Tasks_WorkTaskId",
                table: "Categories",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_Categories_CategoryId",
                table: "TasksCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksCategories_Tasks_WorkTaskId",
                table: "TasksCategories",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
