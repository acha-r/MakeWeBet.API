using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MakeWeBet.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BarcodeId", "Name", "WalletBal" },
                values: new object[,]
                {
                    { 1, "b5eda94a-a70a-4ed0-94c1-e5e5f1422c16", "Iam", 56000m },
                    { 2, "1784a490-143d-4ae8-885c-662b9ba3f197", "Yah", 200000m },
                    { 3, "6a68b7ff-0fd7-4d9d-85ae-8c39f62b04bf", "Jah", 149000m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "No 2 CD Close, Enugu", "GIG" },
                    { 2, "12 New Heaven, Enugu", "ATM" },
                    { 3, "=Port Harcourt", "MGIG" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductBarcCode", "StoreId" },
                values: new object[,]
                {
                    { 1, "Gummies", 1200m, "5209f5ea-10b4-4ffa-886a-7249f7116a8e", 1 },
                    { 2, "Yogurt", 1500m, "582e592a-5adf-4672-b95e-029a7b468a7c", 2 },
                    { 3, "Orbit", 400m, "c36dc4a5-e06d-411a-926f-9d209012b5b0", 1 },
                    { 4, "Malt", 800m, "74851dc9-96b9-444f-a55c-a3600f1bab51", 3 },
                    { 5, "Coke", 300m, "d42dc085-5712-45bd-9c14-4b5e5d7d5b1a", 2 },
                    { 6, "Yogurt", 1200m, "36125b17-1ac9-4430-b62e-b7f2626c7e8d", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
