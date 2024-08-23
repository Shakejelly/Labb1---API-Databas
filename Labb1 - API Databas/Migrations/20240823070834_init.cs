using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb1___API_Databas.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishPrice = table.Column<double>(type: "float", nullable: false),
                    DishInStock = table.Column<int>(type: "int", nullable: true),
                    DishAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatings = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableNumber);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_TableNumber = table.Column<int>(type: "int", nullable: false),
                    FK_CustomerId = table.Column<int>(type: "int", nullable: false),
                    TimeToArrive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_FK_CustomerId",
                        column: x => x.FK_CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tables_FK_TableNumber",
                        column: x => x.FK_TableNumber,
                        principalTable: "Tables",
                        principalColumn: "TableNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BookingName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John Doe", "(555) 123 - 4567" },
                    { 2, "Jane Smith", "(555) 234-5678" },
                    { 3, "Michael Johnson", "(555) 345-6789" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "DishId", "Description", "DishAvailable", "DishInStock", "DishName", "DishPrice" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta with a creamy egg and pancetta sauce.", false, null, "Spaghetti Carbonara", 14.99 },
                    { 2, "A simple pizza topped with fresh tomatoes, mozzarella, and basil.", false, null, "Margherita Pizza", 12.5 },
                    { 3, "Tender chicken in a spiced tomato and cream sauce, served with rice.", false, null, "Chicken Tikka Masala", 16.989999999999998 },
                    { 4, "An assortment of fresh sushi rolls with wasabi and soy sauce.", false, null, "Sushi Platter", 22.0 },
                    { 5, "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan.", false, null, "Caesar Salad", 10.5 },
                    { 6, "Soft tortillas filled with seasoned beef, lettuce, and cheddar cheese.", false, null, "Beef Tacos", 11.25 },
                    { 7, "Stir-fried rice noodles with shrimp, peanuts, and tangy tamarind sauce.", false, null, "Pad Thai", 13.75 },
                    { 8, "Rich and creamy soup made from fresh lobster and a touch of sherry.", false, null, "Lobster Bisque", 18.5 },
                    { 9, "A colorful mix of vegetables sautéed in a savory soy-ginger sauce.", false, null, "Veggie Stir-Fry", 12.0 },
                    { 10, "Warm, molten-centered chocolate cake served with vanilla ice cream.", false, null, "Chocolate Lava Cake", 8.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableNumber", "Seatings" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 6 },
                    { 9, 6 },
                    { 10, 6 },
                    { 11, 6 },
                    { 12, 10 },
                    { 13, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FK_CustomerId",
                table: "Bookings",
                column: "FK_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FK_TableNumber",
                table: "Bookings",
                column: "FK_TableNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
