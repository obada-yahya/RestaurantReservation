using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class menuItemSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "RestaurantId", "Name", "Description", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Spaghetti Carbonara", "Creamy pasta with bacon and egg", 12.99f },
                    { 2, 1, "Margherita Pizza", "Classic tomato and mozzarella pizza", 9.99f },
                    { 3, 2, "Sushi Combo", "Assorted sushi rolls and sashimi", 18.99f },
                    { 4, 2, "Teriyaki Chicken", "Grilled chicken with teriyaki sauce", 14.99f },
                    { 5, 3, "Burger Deluxe", "Classic beef burger with fries", 10.99f },
                    { 6, 3, "Spaghetti Carbonara", "Creamy pasta with bacon and egg", 15.99f },
                    { 7, 2, "Margherita Pizza", "Classic tomato and mozzarella pizza", 12.99f },
                    { 8, 1, "Sushi Combo", "Assorted sushi rolls and sashimi", 22.99f },
                    { 9, 3, "Teriyaki Chicken", "Grilled chicken with teriyaki sauce", 11.99f },
                    { 10, 2, "Burger Deluxe", "Classic beef burger with fries", 15.99f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 1 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 2 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 3 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 4 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 5 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 6 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 7 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 8 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 9 }
            );

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValues: new object[] { 10 }
            );
        }
    }
}
