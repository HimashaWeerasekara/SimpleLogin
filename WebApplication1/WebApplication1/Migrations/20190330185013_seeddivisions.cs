using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class seeddivisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Divisions(DivitionNumber) VALUES('B7896')");
            migrationBuilder.Sql("INSERT INTO Divisions(DivitionNumber) VALUES('B5453')");
            migrationBuilder.Sql("INSERT INTO Divisions(DivitionNumber) VALUES('B5453')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Divisions WHERE DivitionNumber = 'B7896'");
            migrationBuilder.Sql("DELETE FROM Divisions WHERE DivitionNumber = 'B5453'");
            migrationBuilder.Sql("DELETE FROM Divisions WHERE DivitionNumber = 'B5453'");
        }
    }
}
