using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBusiness.Migrations
{
    public partial class updateteams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FBUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IGUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TTUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FBUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IGUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TTUrl",
                table: "Teams");
        }
    }
}
