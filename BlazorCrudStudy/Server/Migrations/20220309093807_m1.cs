﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCrudStudy.Server.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComicsV2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicsV2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroesV2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroesV2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroesV2_ComicsV2_ComicId",
                        column: x => x.ComicId,
                        principalTable: "ComicsV2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComicsV2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Marvel" });

            migrationBuilder.InsertData(
                table: "ComicsV2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "DC" });

            migrationBuilder.InsertData(
                table: "SuperHeroesV2",
                columns: new[] { "Id", "ComicId", "FirstName", "HeroName", "LastName" },
                values: new object[] { 1, 1, "Peter", "Spiderman", "Parker" });

            migrationBuilder.InsertData(
                table: "SuperHeroesV2",
                columns: new[] { "Id", "ComicId", "FirstName", "HeroName", "LastName" },
                values: new object[] { 2, 2, "Bruce", "Batman", "Wayne" });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroesV2_ComicId",
                table: "SuperHeroesV2",
                column: "ComicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroesV2");

            migrationBuilder.DropTable(
                name: "ComicsV2");
        }
    }
}
