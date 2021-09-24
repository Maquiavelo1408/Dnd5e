using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnd5e.Migrations
{
    public partial class AddedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeSkills",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeSkills", x => new { x.AttributeId, x.SkillId });
                });

            migrationBuilder.CreateTable(
                name: "CharacterAttributes",
                columns: table => new
                {
                    CharacterAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    Prerequisite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAttributes", x => x.CharacterAttributeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Characters_CharacterId",
                table: "CharacterSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkills_Skills_SkillId",
                table: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "AttributeSkills");

            migrationBuilder.DropTable(
                name: "CharacterAttributes");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills");
        }
    }
}
