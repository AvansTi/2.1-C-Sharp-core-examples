using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCatogories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCatogories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingItem",
                columns: table => new
                {
                    ArtNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ItemCatogoryId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Manufactuer = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItem", x => x.ArtNumber);
                    table.ForeignKey(
                        name: "FK_ShoppingItem_ItemCatogories_ItemCatogoryId",
                        column: x => x.ItemCatogoryId,
                        principalTable: "ItemCatogories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItem_ItemCatogoryId",
                table: "ShoppingItem",
                column: "ItemCatogoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItem");

            migrationBuilder.DropTable(
                name: "ItemCatogories");
        }
    }
}
