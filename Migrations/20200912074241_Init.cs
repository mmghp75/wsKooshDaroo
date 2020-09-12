using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wsKooshDaroo.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNo = table.Column<string>(nullable: true),
                    isInactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    is24h = table.Column<bool>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    isInactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyConnection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PharmacyId = table.Column<int>(nullable: false),
                    DateOfConnectionState = table.Column<DateTime>(nullable: false),
                    StateOf = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyConnection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prescribe",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Prescription = table.Column<byte[]>(nullable: true),
                    DateOf = table.Column<DateTime>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    isCancelled = table.Column<bool>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescribe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrescribeItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrescribeId = table.Column<int>(nullable: false),
                    DrugName = table.Column<string>(nullable: true),
                    CountOf = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribeItem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrescribeResource",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrescribeId = table.Column<int>(nullable: false),
                    PharmacyId = table.Column<int>(nullable: false),
                    Item01 = table.Column<bool>(nullable: false),
                    Item02 = table.Column<bool>(nullable: false),
                    Item03 = table.Column<bool>(nullable: false),
                    Item04 = table.Column<bool>(nullable: false),
                    Item05 = table.Column<bool>(nullable: false),
                    Item06 = table.Column<bool>(nullable: false),
                    Item07 = table.Column<bool>(nullable: false),
                    Item08 = table.Column<bool>(nullable: false),
                    Item09 = table.Column<bool>(nullable: false),
                    Item10 = table.Column<bool>(nullable: false),
                    PharmacyAccepted = table.Column<bool>(nullable: false),
                    PharmacyAcceptDateOf = table.Column<DateTime>(nullable: false),
                    MemberAccepted = table.Column<bool>(nullable: false),
                    MemberAcceptDateOf = table.Column<DateTime>(nullable: false),
                    MemberTakesDrugs = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribeResource", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyConnection");

            migrationBuilder.DropTable(
                name: "Prescribe");

            migrationBuilder.DropTable(
                name: "PrescribeItem");

            migrationBuilder.DropTable(
                name: "PrescribeResource");
        }
    }
}
