using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    ProfilePicture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wardrobes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wardrobes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wardrobes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outfits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: true),
                    ColorSchemes = table.Column<List<string>>(type: "text[]", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    WardrobeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outfits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outfits_Wardrobes_WardrobeId",
                        column: x => x.WardrobeId,
                        principalTable: "Wardrobes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClothingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TimesWorn = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    WardrobeId = table.Column<Guid>(type: "uuid", nullable: false),
                    OutfitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingItems_Outfits_OutfitId",
                        column: x => x.OutfitId,
                        principalTable: "Outfits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClothingItems_Wardrobes_WardrobeId",
                        column: x => x.WardrobeId,
                        principalTable: "Wardrobes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutfitClothingItem",
                columns: table => new
                {
                    OutfitId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClothingItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutfitClothingItem", x => new { x.OutfitId, x.ClothingItemId });
                    table.ForeignKey(
                        name: "FK_OutfitClothingItem_ClothingItems_ClothingItemId",
                        column: x => x.ClothingItemId,
                        principalTable: "ClothingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutfitClothingItem_Outfits_OutfitId",
                        column: x => x.OutfitId,
                        principalTable: "Outfits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingItems_OutfitId",
                table: "ClothingItems",
                column: "OutfitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingItems_WardrobeId",
                table: "ClothingItems",
                column: "WardrobeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutfitClothingItem_ClothingItemId",
                table: "OutfitClothingItem",
                column: "ClothingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Outfits_WardrobeId",
                table: "Outfits",
                column: "WardrobeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wardrobes_UserId",
                table: "Wardrobes",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutfitClothingItem");

            migrationBuilder.DropTable(
                name: "ClothingItems");

            migrationBuilder.DropTable(
                name: "Outfits");

            migrationBuilder.DropTable(
                name: "Wardrobes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
