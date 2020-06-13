using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class rolespec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivitionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Divisions_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Divisions_DivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "AspNetUsers");
        }
    }
}
