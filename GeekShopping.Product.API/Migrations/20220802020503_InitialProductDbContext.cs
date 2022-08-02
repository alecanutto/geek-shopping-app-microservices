using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GeekShopping.Product.API.Migrations
{
    public partial class InitialProductDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    ProductType = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "General" },
                    { 2L, "Geek" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "ProductType" },
                values: new object[,]
                {
                    { 1L, 1L, " This project is a good learning project to get comfortable with soldering and programming an Arduino.", "https://user-images.githubusercontent.com/41929050/61567048-13938600-aa33-11e9-9cfd-712191013192.jpeg", "The Quantified Cactus = An Easy Plant Soil Moisture Sensor", 19.9m, "Resale" },
                    { 2L, 1L, " Use craft items you have around the house, plus two LEDs and a LilyPad battery holder, to create a useful book light for reading in the dark.", "https://user-images.githubusercontent.com/41929050/61567049-13938600-aa33-11e9-9c69-a4184bf8e524.jpeg", "A beautiful switch-on book light", 19.9m, "Resale" },
                    { 3L, 1L, " Create a web-connected light-strip API controllable from your website, using the Particle.io.", "https://user-images.githubusercontent.com/41929050/61567053-13938600-aa33-11e9-9780-104fe4019659.png", "Bling your Laptop with an Internet-Connected Light Show", 19.9m, "Resale" },
                    { 4L, 1L, " Use an Altoids tin with Chibitronics sticker LEDs to create a light-up compact that doubles as a survival kit for the young hipster", "https://user-images.githubusercontent.com/41929050/61567051-13938600-aa33-11e9-8ae7-0b5c19aafab4.jpeg", "Create a Compact Survival Kit with LED Track Lighting", 19.9m, "Resale" },
                    { 5L, 1L, " Visualization of sailor scouts sorted by bubblesort algorithm by their planet's distance from the sun", "https://user-images.githubusercontent.com/41929050/61567054-13938600-aa33-11e9-9163-eec98e239b7a.png", "Bubblesort Visualization", 19.9m, "Resale" },
                    { 6L, 1L, " Light-up corsage I made with my summer intern.", "https://user-images.githubusercontent.com/41929050/61567055-142c1c80-aa33-11e9-96ff-9fbac6413625.png", "Light-up Corsage", 19.9m, "Resale" },
                    { 7L, 1L, " Pastel hardware kits complete with custom manufactured pastel alligator clips.", "https://user-images.githubusercontent.com/41929050/61567056-142c1c80-aa33-11e9-8682-10065d338145.png", "Pastel hardware kit", 19.9m, "Resale" },
                    { 8L, 1L, " custom molded heart shaped LED with sprinkles.", "https://user-images.githubusercontent.com/41929050/61567052-13938600-aa33-11e9-9a88-cd842073ba44.jpg", "Heart-shaped LED", 19.9m, "Resale" },
                    { 9L, 1L, " Black sweatshirt hoody with the Sick of the Internet logo.", "https://user-images.githubusercontent.com/41929050/61567060-142c1c80-aa33-11e9-8188-5a4803844a9e.png", "Black Sweatshirt", 19.9m, "Resale" },
                    { 10L, 1L, " Still some time to enter the pin/sticker giveaway! ", "https://user-images.githubusercontent.com/41929050/61567059-142c1c80-aa33-11e9-939b-2ecf4492786d.png", "Sick of the Internet Pins", 19.9m, "Resale" },
                    { 11L, 1L, " Hipster Dev is busy coding away while styled in a camo jacket and orange beanie.", "https://user-images.githubusercontent.com/41929050/61567061-14c4b300-aa33-11e9-9fee-63ff2c0c9823.png", "Hipster Dev", 19.9m, "Resale" },
                    { 12L, 1L, " Everyone’s favorite design is finally here on a tee! The Pretty Girls Code crew-neck tee is available in a soft pink with red writing.", "https://user-images.githubusercontent.com/41929050/61567062-14c4b300-aa33-11e9-9dcd-8bfed4ece810.png", "Pretty Girls Code Tee", 19.9m, "Resale" },
                    { 13L, 1L, " Styled in a dashiki, Ruby Sis is listening to music while coding in her favorite language, Ruby!", "https://user-images.githubusercontent.com/41929050/61567063-14c4b300-aa33-11e9-8515-bcb866da9ea3.png", "Ruby Sis", 19.9m, "Resale" },
                    { 14L, 1L, " Not sure if I'll be making more, get it while I have it in the store.", "https://user-images.githubusercontent.com/41929050/61567057-142c1c80-aa33-11e9-9781-9e442418eaab.png", "Holographic Dark Moon Necklace", 19.9m, "Resale" },
                    { 15L, 1L, " Used up the Diskette fabric today to make 2 of these crops.", "https://user-images.githubusercontent.com/41929050/61567058-142c1c80-aa33-11e9-89fb-b4f30d84d69d.png", "Floppy Crop", 19.9m, "Resale" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
