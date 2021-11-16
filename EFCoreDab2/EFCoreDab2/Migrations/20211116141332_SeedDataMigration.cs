using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDab2.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "municipality",
                columns: new[] { "id", "cvr", "name" },
                values: new object[] { 1, 42200011, "Magnus kommune" });

            migrationBuilder.InsertData(
                table: "municipality",
                columns: new[] { "id", "cvr", "name" },
                values: new object[] { 2, 42200019, "Lasses kommune" });

            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "id", "access", "address", "limit", "municipalityId", "name" },
                values: new object[,]
                {
                    { 1, "Brækjern", "Rumallé 1", 20, 1, "Mødelokale" },
                    { 2, "Åbent", "Rumallé 1", 3, 1, "Toilet" },
                    { 3, "2426", "Motionsvej 24", -1, 2, "Sportshal" }
                });

            migrationBuilder.InsertData(
                table: "society",
                columns: new[] { "id", "activity", "address", "cvr", "municipalityId", "name" },
                values: new object[,]
                {
                    { 1, "Internat", "Facebook app 1", 42200010, 1, "Pet society" },
                    { 2, "Bofællesskab", "Aldersrovej 26", 42200018, 2, "Hurlumhejhuset" }
                });

            migrationBuilder.InsertData(
                table: "member",
                columns: new[] { "id", "address", "cpr", "isChairman", "name", "societyId" },
                values: new object[,]
                {
                    { 1, "Dyrevej 25", 105882521, true, "Mark Marsvin", 1 },
                    { 3, "Park Allé 24", 2102772423, false, "Gurli gris", 1 },
                    { 2, "Aldersrovej 26", 108002352, true, "Lasse Hyldahl", 2 }
                });

            migrationBuilder.InsertData(
                table: "room_property",
                columns: new[] { "id", "name", "roomId" },
                values: new object[,]
                {
                    { 1, "WiFi", 1 },
                    { 2, "Projektor", 1 },
                    { 3, "10 Stole", 1 },
                    { 4, "Toilet", 2 },
                    { 5, "Håndvask", 2 },
                    { 6, "Fodboldmål", 3 }
                });

            migrationBuilder.InsertData(
                table: "room_reservation",
                columns: new[] { "id", "endTime", "memberId", "roomId", "startTime" },
                values: new object[] { 1, new DateTime(2021, 9, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, new DateTime(2021, 9, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "room_reservation",
                columns: new[] { "id", "endTime", "memberId", "roomId", "startTime" },
                values: new object[] { 2, new DateTime(2021, 9, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2021, 9, 21, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "member",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "room_property",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "room_reservation",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_reservation",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "member",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "member",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "society",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "society",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "municipality",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "municipality",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
