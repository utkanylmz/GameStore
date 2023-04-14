using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Init01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperCompanyMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperCompanyCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameTypeId = table.Column<int>(type: "int", nullable: false),
                    GameDeveleporId = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GameDeveloperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameDevelopers_GameDeveloperId",
                        column: x => x.GameDeveloperId,
                        principalTable: "GameDevelopers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_GameTypes_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.GamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GameUser_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameDevelopers",
                columns: new[] { "Id", "DeveloperCompanyCountry", "DeveloperCompanyMail", "DeveloperCompanyName" },
                values: new object[,]
                {
                    { 1, "Abd", "Valve@valve.com", "Valve" },
                    { 2, "Canada", "EaSport@EaSport.com", "EA Sport" }
                });

            migrationBuilder.InsertData(
                table: "GameTypes",
                columns: new[] { "Id", "TypeDescription", "TypeName" },
                values: new object[,]
                {
                    { 1, "It is a type of video game in which the player tries to shoot down enemies using a gun from a first-person perspective.", "Fps" },
                    { 2, "Sports games are video games that aim to give players the rules and experience of related sports by simulating various sports.", "Sport Game" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "Status", "LastName", "TelNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 13, 18, 4, 29, 522, DateTimeKind.Local).AddTicks(167), "Utkan@utkan.gmail.com", "Utkan", true, "Yılmaz", "0545545545" },
                    { 2, new DateTime(2023, 4, 13, 18, 4, 29, 522, DateTimeKind.Local).AddTicks(171), "Hasan@sanık.gmail.com", "Hasan", true, "Sanık", "0532532532" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameDeveleporId", "GameDeveloperId", "GameTypeId", "Name", "Platform", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "Cs Go", "Pc", 120m, new DateTime(2023, 4, 13, 18, 4, 29, 522, DateTimeKind.Local).AddTicks(125) },
                    { 2, 2, null, 2, "Fifa", "Pc/Console", 600m, new DateTime(2023, 4, 13, 18, 4, 29, 522, DateTimeKind.Local).AddTicks(148) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameDeveloperId",
                table: "Games",
                column: "GameDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeId",
                table: "Games",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_UsersId",
                table: "GameUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameUser");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GameDevelopers");

            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}
