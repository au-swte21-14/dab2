using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDab2.Migrations
{
    public partial class SeedDataMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_member_MemberId",
                table: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Access_MemberId",
                table: "Access");

            migrationBuilder.InsertData(
                table: "Access",
                columns: new[] { "Id", "DriverLicense", "MemberId", "PhoneNr" },
                values: new object[,]
                {
                    { 1, 123456789, 1, 88888888 },
                    { 2, 654125678, 2, 22222222 }
                });

            migrationBuilder.InsertData(
                table: "AccessKeys",
                columns: new[] { "Id", "Code", "RoomId" },
                values: new object[,]
                {
                    { 1, "1234", 1 },
                    { 2, "5678", 2 },
                    { 3, "1a2b3c", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_MemberId",
                table: "Access",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Access_member_MemberId",
                table: "Access",
                column: "MemberId",
                principalTable: "member",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Access_member_MemberId",
                table: "Access");

            migrationBuilder.DropIndex(
                name: "IX_Access_MemberId",
                table: "Access");

            migrationBuilder.DeleteData(
                table: "Access",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Access",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccessKeys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccessKeys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccessKeys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Access_MemberId",
                table: "Access",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Access_member_MemberId",
                table: "Access",
                column: "MemberId",
                principalTable: "member",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
