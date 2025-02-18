using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avatar_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class modelanditemdbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SerialNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerialNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialNumber_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Name", "Price", "SerialNumberId" },
                values: new object[] { 1, "Samsung", 10000, 10 });

            migrationBuilder.InsertData(
                table: "SerialNumber",
                columns: new[] { "Id", "ItemId", "Name" },
                values: new object[] { 10, 1, "Galaxy A12" });

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber_ItemId",
                table: "SerialNumber",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumber");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
