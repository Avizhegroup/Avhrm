using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avhrm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_WorkingDate_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkDayDateTime",
                table: "WorkingReports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkDayDateTime",
                table: "WorkingReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
