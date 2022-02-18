using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazoeProject.Shared.Migrations
{
    public partial class SeedEmployeesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mukhwami@gmail.com", "ombasa", 0, "mukhwami", "images/john.png" },
                    { 2, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "martin.simiyu@test.com", "martin", 0, "simiyu", "images/john.png" },
                    { 3, new DateTime(2002, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "joel.orandi@tes.com", "joel", 0, "orangi", "images/john.png" },
                    { 4, new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ososi.vincent@tes.com", "ososi", 0, "vincent", "images/john.png" },
                    { 5, new DateTime(2010, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "phelisters.bogonko@test.com", "phelisters", 1, "Bogongo", "images/john.png" },
                    { 6, new DateTime(1998, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "silas.mogare@test.com", "silas", 0, "mogare", "images/john.png" },
                    { 7, new DateTime(2009, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "scholastica.memusi@test.com", "scholastica", 1, "memusi", "images/john.png" },
                    { 8, new DateTime(2002, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "breana62@gmail.com", "branambo", 1, "midecha", "images/john.png" },
                    { 9, new DateTime(2006, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "sarah.moraa@test.com", "sarah", 1, "moraa", "images/john.png" },
                    { 10, new DateTime(2004, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "aquirinah.mukhwami@test.com", "Aquirinah", 1, "mukhwami", "images/john.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
