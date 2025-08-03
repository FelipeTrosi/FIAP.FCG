using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.FCG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessLevel", "CreatedAt", "Email", "Name", "Password" },
                values: new object[] { 1L, 1, new DateTime(2025, 8, 2, 16, 21, 46, 24, DateTimeKind.Local).AddTicks(5299), "admin@fiap.com.br", "Admin", "4Dm1n@Fiap" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
