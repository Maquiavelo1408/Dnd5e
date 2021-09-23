using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnd5e.Migrations
{
    public partial class AddedSpeedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlyingSpeed",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HitPoints",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SwimingSpeed",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WalkingSpeed",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlyingSpeed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HitPoints",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SwimingSpeed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "WalkingSpeed",
                table: "Characters");
        }
    }
}
