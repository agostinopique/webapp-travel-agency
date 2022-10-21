using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class RelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacchettoViaggioId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_PacchettoViaggioId",
                table: "Message",
                column: "PacchettoViaggioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_PacchettoViaggio_PacchettoViaggioId",
                table: "Message",
                column: "PacchettoViaggioId",
                principalTable: "PacchettoViaggio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_PacchettoViaggio_PacchettoViaggioId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_PacchettoViaggioId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "PacchettoViaggioId",
                table: "Message");
        }
    }
}
