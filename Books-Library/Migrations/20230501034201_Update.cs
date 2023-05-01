using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Books_Library.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "UserBorrowings");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBNNumber", "Title" },
                values: new object[,]
                {
                    { 1, "Arthur Kostler", 58974265L, "Darkness at Noon" },
                    { 2, "Mary Smith", 756655656L, "Circle of Pain" },
                    { 3, "Mario Puzo", 123679458L, "God Father" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Rörvägen 2", "Misha", "Samsson", "0717894987" },
                    { 2, "Kyrkgatan 12d ", "Tonny", "Jules", "078452588" },
                    { 3, "Storgatan 24", "Leroy", "Henry", "0707456669" }
                });

            migrationBuilder.InsertData(
                table: "UserBorrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "IsReturned", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 2, 1, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 3, 2, new DateTime(2021, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 4, 2, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 5, 3, new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserBorrowings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserBorrowings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserBorrowings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserBorrowings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserBorrowings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "UserBorrowings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
