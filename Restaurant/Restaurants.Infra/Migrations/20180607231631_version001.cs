using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Restaurants.Infra.Migrations
{
    public partial class version001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    creation_date = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dish",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    creation_date = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    restaurant_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish", x => x.id);
                    table.ForeignKey(
                        name: "FK_dish_restaurants_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dish_restaurant_id",
                table: "dish",
                column: "restaurant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish");

            migrationBuilder.DropTable(
                name: "restaurant");
        }
    }
}
