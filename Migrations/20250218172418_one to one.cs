using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avatar_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class onetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_SpecialityModel_SpecialityModelId",
                table: "Avatars");

            migrationBuilder.DropTable(
                name: "SpecialityModel");

            migrationBuilder.DropIndex(
                name: "IX_Avatars_SpecialityModelId",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "SpecialityModelId",
                table: "Avatars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Avatars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityModelId",
                table: "Avatars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecialityModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialityModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avatars_SpecialityModelId",
                table: "Avatars",
                column: "SpecialityModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_SpecialityModel_SpecialityModelId",
                table: "Avatars",
                column: "SpecialityModelId",
                principalTable: "SpecialityModel",
                principalColumn: "Id");
        }
    }
}
