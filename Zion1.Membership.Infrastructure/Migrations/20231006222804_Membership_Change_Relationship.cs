using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zion1.Membership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Membership_Change_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembersInGroups",
                table: "MembersInGroups");

            migrationBuilder.DropIndex(
                name: "IX_MembersInGroups_MemberId",
                table: "MembersInGroups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MembersInGroups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembersInGroups",
                table: "MembersInGroups",
                columns: new[] { "MemberId", "GroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_MembersInGroups_GroupId",
                table: "MembersInGroups",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembersInGroups",
                table: "MembersInGroups");

            migrationBuilder.DropIndex(
                name: "IX_MembersInGroups_GroupId",
                table: "MembersInGroups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MembersInGroups",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembersInGroups",
                table: "MembersInGroups",
                columns: new[] { "GroupId", "MemberId" });

            migrationBuilder.CreateIndex(
                name: "IX_MembersInGroups_MemberId",
                table: "MembersInGroups",
                column: "MemberId");
        }
    }
}
