using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HarmonicPatternsBase.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intervals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvaragePrecisionRating = table.Column<int>(nullable: false),
                    AvarageReactionRating = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patterns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvaragePrecisionRating = table.Column<int>(nullable: false),
                    AvarageReactionRating = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HarmonicPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AvaragePrecisionRating = table.Column<int>(nullable: false),
                    AvarageReactionRating = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Instrument = table.Column<string>(nullable: true),
                    IntervalId = table.Column<int>(nullable: false),
                    NumberOfPrecisionRatings = table.Column<int>(nullable: false),
                    NumgerOfReactionRatings = table.Column<int>(nullable: false),
                    PatternTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarmonicPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarmonicPatterns_Intervals_IntervalId",
                        column: x => x.IntervalId,
                        principalTable: "Intervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarmonicPatterns_Patterns_PatternTypeId",
                        column: x => x.PatternTypeId,
                        principalTable: "Patterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarmonicPatterns_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HarmonicPatterns_IntervalId",
                table: "HarmonicPatterns",
                column: "IntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_HarmonicPatterns_PatternTypeId",
                table: "HarmonicPatterns",
                column: "PatternTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HarmonicPatterns_UserId",
                table: "HarmonicPatterns",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HarmonicPatterns");

            migrationBuilder.DropTable(
                name: "Intervals");

            migrationBuilder.DropTable(
                name: "Patterns");
        }
    }
}
