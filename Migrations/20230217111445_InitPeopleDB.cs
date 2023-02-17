using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Api.Migrations
{
    public partial class InitPeopleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleTypes",
                columns: table => new
                {
                    PeopleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTypes", x => x.PeopleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_Peoples_PeopleTypes_PeopleTypeId",
                        column: x => x.PeopleTypeId,
                        principalTable: "PeopleTypes",
                        principalColumn: "PeopleTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peoples_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_PeopleTypeId",
                table: "Peoples",
                column: "PeopleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_StateId",
                table: "Peoples",
                column: "StateId");

            migrationBuilder.InsertData(
               table: "PeopleTypes",
               columns: new[] { "Description" },
               values: new object[,]
               {
                    { "Persona Fisica" },
                    { "Persona Juridica" }
               });

            migrationBuilder.InsertData(
               table: "States",
               columns: new[] { "Name" },
               values: new object[,]
               {
                    { "Santa Fe" }
               });

            migrationBuilder.InsertData(
               table: "Peoples",
               columns: new[] { "PeopleTypeId", "Name", "Address", "City", "Stateid" },
               values: new object[,]
               {
                    { 1, "Gustavo Zbinden", "Calle 83 644", "Reconquista", 1 },
                    { 1, "Leticia Lorenzon", "Freyre 244", "Reconquista", 1 },
                    { 1, "Jose Alvarez", "Lucas Funes 210", "Avellaneda", 1 }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "PeopleTypes");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
