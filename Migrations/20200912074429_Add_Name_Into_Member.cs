using Microsoft.EntityFrameworkCore.Migrations;

namespace wsKooshDaroo.Migrations
{
    public partial class Add_Name_Into_Member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Member");
        }
    }
}
