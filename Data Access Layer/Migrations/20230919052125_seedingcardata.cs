using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class seedingcardata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VehicleId", "Maker", "Model", "RentalPrice" },
                values: new object[,]
                {
                    { new Guid("27613834-2f2c-4653-8ae7-0cc10d8c983a"), "Maruti Suzuki", "Claz", 1200.0 },
                    { new Guid("47260862-087b-472d-a2b2-3ee2c3a0d61d"), "Tata", "Altrox", 900.0 },
                    { new Guid("94ffe6c3-25c0-4b1e-b412-17b30bd2e22f"), "Maruti Suzuki", "Ignis", 2000.0 },
                    { new Guid("cfbc05be-17c6-4574-939d-6fbb7e634eb0"), "Tata", "Tiago", 1000.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "User");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 3, "Admin1234@gmail.com", "Admin", "Admin111@", "12345671111", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "VehicleId",
                keyValue: new Guid("27613834-2f2c-4653-8ae7-0cc10d8c983a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "VehicleId",
                keyValue: new Guid("47260862-087b-472d-a2b2-3ee2c3a0d61d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "VehicleId",
                keyValue: new Guid("94ffe6c3-25c0-4b1e-b412-17b30bd2e22f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "VehicleId",
                keyValue: new Guid("cfbc05be-17c6-4574-939d-6fbb7e634eb0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Admin");
        }
    }
}
