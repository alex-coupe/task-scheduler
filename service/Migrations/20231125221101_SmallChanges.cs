using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace service.Migrations
{
    /// <inheritdoc />
    public partial class SmallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Intervals_IntervalId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Success",
                table: "Results",
                newName: "StatusId");

            migrationBuilder.AlterColumn<int>(
                name: "IntervalId",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Completed" },
                    { 7, "Failed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_StatusId",
                table: "Results",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Intervals_IntervalId",
                table: "Jobs",
                column: "IntervalId",
                principalTable: "Intervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Status_StatusId",
                table: "Results",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Intervals_IntervalId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Status_StatusId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_StatusId",
                table: "Results");

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Results",
                newName: "Success");

            migrationBuilder.AlterColumn<int>(
                name: "IntervalId",
                table: "Jobs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Intervals_IntervalId",
                table: "Jobs",
                column: "IntervalId",
                principalTable: "Intervals",
                principalColumn: "Id");
        }
    }
}
