using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysModule",
                columns: table => new
                {
                    ModuleID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModuleTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    ModuleState = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysModule", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    RoleState = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleRight",
                columns: table => new
                {
                    RoleRightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ModuleID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleRight", x => x.RoleRightID);
                });

            migrationBuilder.CreateTable(
                name: "SysUserInfo",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIP = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserInfo", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysModule");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysRoleRight");

            migrationBuilder.DropTable(
                name: "SysUserInfo");
        }
    }
}
