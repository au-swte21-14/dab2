using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDab2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "municipality",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cvr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    municipalityId = table.Column<int>(type: "int", nullable: false),
                    limit = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    access = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.id);
                    table.ForeignKey(
                        name: "FK__room__municipali__32AB8735",
                        column: x => x.municipalityId,
                        principalTable: "municipality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "society",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    municipalityId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cvr = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    activity = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_society", x => x.id);
                    table.ForeignKey(
                        name: "FK__society__municip__2BFE89A6",
                        column: x => x.municipalityId,
                        principalTable: "municipality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_property", x => x.id);
                    table.ForeignKey(
                        name: "FK__room_prop__roomI__367C1819",
                        column: x => x.roomId,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    societyId = table.Column<int>(type: "int", nullable: false),
                    isChairman = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cpr = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_member", x => x.id);
                    table.ForeignKey(
                        name: "FK__member__societyI__2EDAF651",
                        column: x => x.societyId,
                        principalTable: "society",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room_reservation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_reservation", x => x.id);
                    table.ForeignKey(
                        name: "FK__room_rese__membe__3A4CA8FD",
                        column: x => x.memberId,
                        principalTable: "member",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__room_rese__roomI__395884C4",
                        column: x => x.roomId,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_member_societyId",
                table: "member",
                column: "societyId");

            migrationBuilder.CreateIndex(
                name: "IX_room_municipalityId",
                table: "room",
                column: "municipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_room_property_roomId",
                table: "room_property",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_room_reservation_memberId",
                table: "room_reservation",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_room_reservation_roomId",
                table: "room_reservation",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_society_municipalityId",
                table: "society",
                column: "municipalityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "room_property");

            migrationBuilder.DropTable(
                name: "room_reservation");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "society");

            migrationBuilder.DropTable(
                name: "municipality");
        }
    }
}
