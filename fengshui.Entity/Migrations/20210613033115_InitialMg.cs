using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fengshui.Entity.Migrations
{
    public partial class InitialMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ServiceProvider = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileNumbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MobileNumbers",
                columns: new[] { "Id", "CreationDate", "LastUpdateDate", "PhoneNumber", "ServiceProvider" },
                values: new object[] { 1, new DateTime(2021, 6, 13, 10, 31, 14, 724, DateTimeKind.Local).AddTicks(5722), new DateTime(2021, 6, 13, 10, 31, 14, 725, DateTimeKind.Local).AddTicks(6743), "0971111112", "Viettel" });

            migrationBuilder.InsertData(
                table: "MobileNumbers",
                columns: new[] { "Id", "CreationDate", "LastUpdateDate", "PhoneNumber", "ServiceProvider" },
                values: new object[] { 2, new DateTime(2021, 6, 13, 10, 31, 14, 725, DateTimeKind.Local).AddTicks(7496), new DateTime(2021, 6, 13, 10, 31, 14, 725, DateTimeKind.Local).AddTicks(7511), "0971111113", "Viettel" });

            migrationBuilder.InsertData(
                table: "MobileNumbers",
                columns: new[] { "Id", "CreationDate", "LastUpdateDate", "PhoneNumber", "ServiceProvider" },
                values: new object[] { 3, new DateTime(2021, 6, 13, 10, 31, 14, 725, DateTimeKind.Local).AddTicks(7521), new DateTime(2021, 6, 13, 10, 31, 14, 725, DateTimeKind.Local).AddTicks(7522), "0971111115", "Viettel" });

            migrationBuilder.CreateIndex(
                name: "IX_MobileNumbers_PhoneNumber",
                table: "MobileNumbers",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileNumbers");
        }
    }
}
