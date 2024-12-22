using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ord.AbpApp.Migrations
{
    /// <inheritdoc />
    public partial class MsiDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConciousID",
                table: "District",
                newName: "ProvinceCode");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "Commune",
                newName: "ProvinceCode");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictCode",
                table: "District",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DistictCode",
                table: "Commune",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistictCode",
                table: "Commune");

            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                table: "District",
                newName: "ConciousID");

            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                table: "Commune",
                newName: "DistrictID");

            migrationBuilder.AlterColumn<string>(
                name: "DistrictCode",
                table: "District",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
