using Microsoft.EntityFrameworkCore.Migrations;

namespace Dnd5e.Migrations
{
    public partial class AddedAttributeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterAttributeId",
                table: "AttributeSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSkills_CharacterAttributeId",
                table: "AttributeSkills",
                column: "CharacterAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSkills_SkillId",
                table: "AttributeSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeSkills_CharacterAttributes_CharacterAttributeId",
                table: "AttributeSkills",
                column: "CharacterAttributeId",
                principalTable: "CharacterAttributes",
                principalColumn: "CharacterAttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeSkills_Skills_SkillId",
                table: "AttributeSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeSkills_CharacterAttributes_CharacterAttributeId",
                table: "AttributeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeSkills_Skills_SkillId",
                table: "AttributeSkills");

            migrationBuilder.DropIndex(
                name: "IX_AttributeSkills_CharacterAttributeId",
                table: "AttributeSkills");

            migrationBuilder.DropIndex(
                name: "IX_AttributeSkills_SkillId",
                table: "AttributeSkills");

            migrationBuilder.DropColumn(
                name: "CharacterAttributeId",
                table: "AttributeSkills");
        }
    }
}
