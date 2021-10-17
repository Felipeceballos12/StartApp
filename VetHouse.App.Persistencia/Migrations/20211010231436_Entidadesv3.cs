using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetHouse.App.Persistencia.Migrations
{
    public partial class Entidadesv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "StatusHealth",
                table: "VitalSign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirth",
                table: "Pet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Pet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirth",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Pet_HistoryId",
                table: "Pet",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_History_HistoryId",
                table: "Pet",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_History_HistoryId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_HistoryId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "StatusHealth",
                table: "VitalSign");

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
