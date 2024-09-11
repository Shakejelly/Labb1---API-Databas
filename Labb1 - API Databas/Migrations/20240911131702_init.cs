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
                    ReservationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DishPrice = table.Column<double>(type: "float", nullable: false),
                    DishInStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seatings = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
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
                    BookingAmount = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "PhoneNumber", "ReservationName" },
                values: new object[,]
                {
                    { 1, "(555) 123 - 4567", "John Doe" },
                    { 2, "(555) 234-5678", "Jane Smith" },
                    { 3, "(555) 345-6789", "Michael Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "DishId", "Description", "DishInStock", "DishName", "DishPrice" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta with a creamy egg and pancetta sauce.", false, "Spaghetti Carbonara", 14.99 },
                    { 2, "A simple pizza topped with fresh tomatoes, mozzarella, and basil.", false, "Margherita Pizza", 12.5 },
                    { 3, "Tender chicken in a spiced tomato and cream sauce, served with rice.", false, "Chicken Tikka Masala", 16.989999999999998 },
                    { 4, "An assortment of fresh sushi rolls with wasabi and soy sauce.", false, "Sushi Platter", 22.0 },
                    { 5, "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan.", false, "Caesar Salad", 10.5 },
                    { 6, "Soft tortillas filled with seasoned beef, lettuce, and cheddar cheese.", false, "Beef Tacos", 11.25 },
                    { 7, "Stir-fried rice noodles with shrimp, peanuts, and tangy tamarind sauce.", false, "Pad Thai", 13.75 },
                    { 8, "Rich and creamy soup made from fresh lobster and a touch of sherry.", false, "Lobster Bisque", 18.5 },
                    { 9, "A colorful mix of vegetables sautéed in a savory soy-ginger sauce.", false, "Veggie Stir-Fry", 12.0 },
                    { 10, "Warm, molten-centered chocolate cake served with vanilla ice cream.", false, "Chocolate Lava Cake", 8.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Seatings" },
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
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
