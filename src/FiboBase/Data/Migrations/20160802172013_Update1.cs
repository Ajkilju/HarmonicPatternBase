using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FiboBase.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReactionAfter10CandlesId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReactionAfter20CandlesId",
                table: "HarmonicPatterns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HarmonicPatterns_ReactionAfter10CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter10CandlesId");

            migrationBuilder.CreateIndex(
                name: "IX_HarmonicPatterns_ReactionAfter20CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter20CandlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter10CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter10CandlesId",
                principalTable: "ReactionLvls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter20CandlesId",
                table: "HarmonicPatterns",
                column: "ReactionAfter20CandlesId",
                principalTable: "ReactionLvls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter10CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.DropForeignKey(
                name: "FK_HarmonicPatterns_ReactionLvls_ReactionAfter20CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.DropIndex(
                name: "IX_HarmonicPatterns_ReactionAfter10CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.DropIndex(
                name: "IX_HarmonicPatterns_ReactionAfter20CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.DropColumn(
                name: "ReactionAfter10CandlesId",
                table: "HarmonicPatterns");

            migrationBuilder.DropColumn(
                name: "ReactionAfter20CandlesId",
                table: "HarmonicPatterns");
        }
    }
}
