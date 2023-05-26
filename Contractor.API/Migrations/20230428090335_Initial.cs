using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contractor.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nip = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PhoneNo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Email", "Name", "Nip", "PhoneNo" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "wsiz@wsiz.edu.pl", "WSIZ", "1234567890", "178660000" });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Email", "Name", "Nip", "PhoneNo" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "ur@ur.edu.pl", "UR", "0987654321", "179999999" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractors");
        }
    }
}
