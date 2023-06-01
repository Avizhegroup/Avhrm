using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avhrm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacationRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Verifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VerifyDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequest", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationRequest");
        }
    }
}
