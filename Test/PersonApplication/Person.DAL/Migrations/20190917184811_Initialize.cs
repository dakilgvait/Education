using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Person.DAL.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    PersonNumber = table.Column<string>(maxLength: 11, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 0, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 2, 1, "Female" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birthdate", "FirstName", "GenderId", "LastName", "PersonNumber", "Salary" },
                values: new object[,]
                {
                    { 4, new DateTime(1973, 1, 20, 6, 31, 26, 0, DateTimeKind.Local), "jeffrey", 1, "stephens", "00000965393", 9989429m },
                    { 18, new DateTime(1990, 4, 16, 19, 14, 48, 0, DateTimeKind.Local), "dora", 2, "peterson", "00008051052", 48839m },
                    { 17, new DateTime(1961, 7, 5, 6, 38, 35, 0, DateTimeKind.Local), "sara", 2, "castillo", "00002810928", 7248822m },
                    { 16, new DateTime(1996, 2, 28, 0, 55, 1, 0, DateTimeKind.Local), "hazel", 2, "shaw", "00002099017", 4045863m },
                    { 13, new DateTime(1962, 3, 14, 22, 25, 2, 0, DateTimeKind.Local), "esther", 2, "peterson", "00001517833", 2368608m },
                    { 11, new DateTime(1960, 11, 6, 11, 0, 38, 0, DateTimeKind.Local), "ana", 2, "weaver", "00001948908", 562748m },
                    { 10, new DateTime(1975, 11, 8, 23, 35, 0, 0, DateTimeKind.Local), "emma", 2, "banks", "00001960560", 7092748m },
                    { 7, new DateTime(1957, 1, 24, 1, 49, 16, 0, DateTimeKind.Local), "shelly", 2, "phillips", "00007507760", 8141896m },
                    { 6, new DateTime(1973, 12, 22, 16, 32, 54, 0, DateTimeKind.Local), "erika", 2, "gonzalez", "00005222962", 5706540m },
                    { 5, new DateTime(1946, 6, 12, 15, 29, 56, 0, DateTimeKind.Local), "bella", 2, "welch", "00005594189", 5967764m },
                    { 3, new DateTime(1955, 6, 16, 21, 56, 15, 0, DateTimeKind.Local), "maureen", 2, "hudson", "00000131068", 842228m },
                    { 24, new DateTime(1989, 4, 20, 8, 50, 49, 0, DateTimeKind.Local), "jennifer", 2, "bennett", "00004753410", 9503051m },
                    { 2, new DateTime(1976, 1, 26, 8, 54, 51, 0, DateTimeKind.Local), "marion", 2, "graves", "00002517114", 9878052m },
                    { 23, new DateTime(1955, 2, 8, 17, 0, 15, 0, DateTimeKind.Local), "brad", 1, "cook", "00000141526", 4717208m },
                    { 22, new DateTime(1992, 11, 25, 12, 2, 2, 0, DateTimeKind.Local), "gilbert", 1, "miller", "00001602811", 9158945m },
                    { 21, new DateTime(1974, 12, 15, 15, 41, 28, 0, DateTimeKind.Local), "kurt", 1, "moore", "00003201802", 1279011m },
                    { 20, new DateTime(1969, 10, 27, 8, 58, 13, 0, DateTimeKind.Local), "alvin", 1, "edwards", "00004557549", 8401437m },
                    { 19, new DateTime(1981, 2, 2, 5, 43, 9, 0, DateTimeKind.Local), "jason", 1, "walker", "00005073131", 9201081m },
                    { 15, new DateTime(1991, 6, 10, 16, 36, 34, 0, DateTimeKind.Local), "noah", 1, "gutierrez", "00008931824", 5241941m },
                    { 14, new DateTime(1967, 12, 31, 17, 32, 13, 0, DateTimeKind.Local), "morris", 1, "chambers", "00003723263", 5438711m },
                    { 12, new DateTime(1960, 5, 27, 16, 46, 31, 0, DateTimeKind.Local), "elmer", 1, "hart", "00000331136", 7402702m },
                    { 9, new DateTime(1984, 2, 21, 2, 47, 7, 0, DateTimeKind.Local), "steven", 1, "walker", "00003917882", 5407150m },
                    { 8, new DateTime(1946, 10, 21, 8, 58, 0, 0, DateTimeKind.Local), "roberto", 1, "garza", "00005356822", 2223593m },
                    { 1, new DateTime(1963, 9, 25, 12, 7, 23, 0, DateTimeKind.Local), "vera", 2, "wood", "00001175132", 3203626m },
                    { 25, new DateTime(1981, 8, 17, 1, 47, 14, 0, DateTimeKind.Local), "ruby", 2, "herrera", "00007504400", 5120060m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GenderId",
                table: "Persons",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonNumber",
                table: "Persons",
                column: "PersonNumber",
                unique: true,
                filter: "[PersonNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
