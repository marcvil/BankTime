using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankTimeApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BankTimeApp");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "BankTimeApp",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "BankTimeApp",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "BankTimeApp",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BankTimeApp",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "BankTimeApp",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TimeToCompleteTask = table.Column<DateTime>(nullable: false),
                    ExchangeState = table.Column<int>(nullable: false),
                    UserWhoOwesHoursId = table.Column<int>(nullable: false),
                    UserWhoOwesHoursId1 = table.Column<string>(nullable: true),
                    UserWhoCompletedTaskId = table.Column<int>(nullable: false),
                    UserWhoCompletedTaskHoursId = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchanges_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "BankTimeApp",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchanges_User_UserWhoCompletedTaskHoursId",
                        column: x => x.UserWhoCompletedTaskHoursId,
                        principalSchema: "BankTimeApp",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exchanges_User_UserWhoOwesHoursId1",
                        column: x => x.UserWhoOwesHoursId1,
                        principalSchema: "BankTimeApp",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    RequestTimeToComplete = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "BankTimeApp",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "BankTimeApp",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_TaskId",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_UserWhoCompletedTaskHoursId",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoCompletedTaskHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_UserWhoOwesHoursId1",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoOwesHoursId1");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TaskId",
                schema: "BankTimeApp",
                table: "Requests",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId1",
                schema: "BankTimeApp",
                table: "Requests",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                schema: "BankTimeApp",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId1",
                schema: "BankTimeApp",
                table: "Tasks",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exchanges",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "BankTimeApp");

            migrationBuilder.DropTable(
                name: "User",
                schema: "BankTimeApp");
        }
    }
}
