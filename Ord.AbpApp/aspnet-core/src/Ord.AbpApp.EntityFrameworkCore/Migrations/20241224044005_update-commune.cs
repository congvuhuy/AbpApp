using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ord.AbpApp.Migrations
{
    /// <inheritdoc />
    public partial class updatecommune : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistictCode",
                table: "Commune",
                newName: "DistrictCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistrictCode",
                table: "Commune",
                newName: "DistictCode");
        }
    }
}
