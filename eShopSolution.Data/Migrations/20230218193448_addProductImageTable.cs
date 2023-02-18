using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class addProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09120475-3020-4682-a2eb-23f3915051d6"),
                column: "ConcurrencyStamp",
                value: "1438f950-09c3-4551-88a4-f526710e841c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "197f0f24-6893-4698-886a-cf1f6b223c6b", "AQAAAAEAACcQAAAAEMhm+VczZmblbK+lOdGxmJP4EcgwFMP4dBC20IYijAgc8EhRHn7hOu/4sHQFhv1QSA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 19, 2, 34, 47, 721, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09120475-3020-4682-a2eb-23f3915051d6"),
                column: "ConcurrencyStamp",
                value: "45640b56-a27c-45ac-904c-dede7fb11b89");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("fcf90235-67a7-4a8c-b7e0-81cc988ccf74"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4778e1ed-8b10-4223-a05a-1d0ad6c5edba", "AQAAAAEAACcQAAAAEKVJEBn45txtWGpSIAxVJ20KnldQrHQHYHAKUfTxts88oO92DDJrV24utgVd6bqYLg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 18, 2, 16, 2, 506, DateTimeKind.Local).AddTicks(2778));
        }
    }
}
