using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("09120475-3020-4682-a2eb-23f3915051d6"), "45640b56-a27c-45ac-904c-dede7fb11b89", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("09120475-3020-4682-a2eb-23f3915051d6"), new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74"), 0, "4778e1ed-8b10-4223-a05a-1d0ad6c5edba", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "tienncph18949@fpt.edu.vn", true, "Tien", "Nguyen", false, null, "tienncph18949@fpt.edu.vn", "admin", "AQAAAAEAACcQAAAAEKVJEBn45txtWGpSIAxVJ20KnldQrHQHYHAKUfTxts88oO92DDJrV24utgVd6bqYLg==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 18, 2, 16, 2, 506, DateTimeKind.Local).AddTicks(2778));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09120475-3020-4682-a2eb-23f3915051d6"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09120475-3020-4682-a2eb-23f3915051d6"), new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 18, 2, 2, 38, 855, DateTimeKind.Local).AddTicks(1834));
        }
    }
}
