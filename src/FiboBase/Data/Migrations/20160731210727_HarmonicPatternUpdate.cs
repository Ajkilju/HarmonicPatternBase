using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarmonicPatternsBase.Migrations
{
    public partial class HarmonicPatternUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AvarageReactionRating",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "AvaragePrecisionRating",
                table: "HarmonicPatterns",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AvarageReactionRating",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "AvaragePrecisionRating",
                table: "HarmonicPatterns",
                nullable: false);
        }
    }
}
