using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Yoshi.VIN.Membership.Data.EF.Migrations
{
    public partial class usernameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Member_UserName",
                schema: "dbo",
                table: "Member",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Member_UserName",
                schema: "dbo",
                table: "Member");
        }
    }
}
