using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service.Migrations
{
    /// <inheritdoc />
    public partial class TaskChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunTime",
                table: "Tasks",
                newName: "NextRunTime");

            migrationBuilder.AddColumn<int>(
                name: "IntervalId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRunTime",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IntervalId",
                table: "Tasks",
                column: "IntervalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Intervals_IntervalId",
                table: "Tasks",
                column: "IntervalId",
                principalTable: "Intervals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Intervals_IntervalId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_IntervalId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IntervalId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastRunTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "NextRunTime",
                table: "Tasks",
                newName: "RunTime");
        }
    }
}
