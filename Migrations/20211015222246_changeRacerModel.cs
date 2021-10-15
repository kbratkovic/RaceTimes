using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RaceTimes.Migrations
{
    public partial class changeRacerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceTime",
                table: "Racers");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Racers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Milliseconds",
                table: "Racers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "Racers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seconds",
                table: "Racers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "Milliseconds",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "Seconds",
                table: "Racers");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RaceTime",
                table: "Racers",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
