﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    public partial class RelateTaskToActivities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkTaskId",
                table: "Activities",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkTaskId",
                table: "Activities",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_WorkTaskId",
                table: "Activities",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
