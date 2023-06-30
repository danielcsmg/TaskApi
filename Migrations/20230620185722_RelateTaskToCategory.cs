using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class RelateTaskToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Tasks_WorkTaskId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Category_WorkTaskId",
                table: "Categories",
                newName: "IX_Categories_WorkTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TasksCategories",
                columns: table => new
                {
                    WorkTaskId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksCategories", x => new { x.WorkTaskId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TasksCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasksCategories_Tasks_WorkTaskId",
                        column: x => x.WorkTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TasksCategories_CategoryId",
                table: "TasksCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Tasks_WorkTaskId",
                table: "Categories",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Tasks_WorkTaskId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "TasksCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_WorkTaskId",
                table: "Category",
                newName: "IX_Category_WorkTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Tasks_WorkTaskId",
                table: "Category",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
