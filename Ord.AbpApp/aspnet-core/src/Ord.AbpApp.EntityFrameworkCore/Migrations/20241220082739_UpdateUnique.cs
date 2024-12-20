using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ord.AbpApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DistrictCode",
                table: "District",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Province_ProvinceCode",
                table: "Province",
                column: "ProvinceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_District_DistrictCode",
                table: "District",
                column: "DistrictCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commune_CommuneCode",
                table: "Commune",
                column: "CommuneCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Province_ProvinceCode",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_District_DistrictCode",
                table: "District");

            migrationBuilder.DropIndex(
                name: "IX_Commune_CommuneCode",
                table: "Commune");

            migrationBuilder.AlterColumn<string>(
                name: "DistrictCode",
                table: "District",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
