using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentPortalAPI.Migrations
{
    public partial class RemovedUserResumeFromJobApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserResume",
                table: "JobApplicants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UserResume",
                table: "JobApplicants",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
