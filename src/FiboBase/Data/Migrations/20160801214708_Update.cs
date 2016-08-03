using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarmonicPatternsBase.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Instruments_InstrumentId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Intervals_IntervalId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_PatternDirects_PatternDirectId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Patterns_PatternTypeId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter5CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.AlterColumn<int>(
                name: "ReactionAfter5CandlesId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatternTypeId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatternDirectId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfWaves",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IntervalId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CDtoBCratio",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CDtoABratio",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BCtoABratio",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ADtoXAratio",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ABtoXAratio",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Instruments_InstrumentId",
                table: "HarmonicPatterns",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Intervals_IntervalId",
                table: "HarmonicPatterns",
                column: "IntervalId",
                principalTable: "Intervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_PatternDirects_PatternDirectId",
                table: "HarmonicPatterns",
                column: "PatternDirectId",
                principalTable: "PatternDirects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Patterns_PatternTypeId",
                table: "HarmonicPatterns",
                column: "PatternTypeId",
                principalTable: "Patterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter5CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter5CandlesId",
                principalTable: "ReactionLvls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Instruments_InstrumentId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Intervals_IntervalId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_PatternDirects_PatternDirectId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_Patterns_PatternTypeId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter5CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.AlterColumn<int>(
                name: "ReactionAfter5CandlesId",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "PatternTypeId",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "PatternDirectId",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfWaves",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "IntervalId",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentId",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "CDtoBCratio",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "CDtoABratio",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "BCtoABratio",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "ADtoXAratio",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "ABtoXAratio",
                table: "HarmonicPatterns",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Instruments_InstrumentId",
                table: "HarmonicPatterns",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Intervals_IntervalId",
                table: "HarmonicPatterns",
                column: "IntervalId",
                principalTable: "Intervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_PatternDirects_PatternDirectId",
                table: "HarmonicPatterns",
                column: "PatternDirectId",
                principalTable: "PatternDirects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_Patterns_PatternTypeId",
                table: "HarmonicPatterns",
                column: "PatternTypeId",
                principalTable: "Patterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter5CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter5CandlesId",
                principalTable: "ReactionLvls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
