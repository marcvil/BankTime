using Microsoft.EntityFrameworkCore.Migrations;

namespace BankTimeApp.Migrations
{
    public partial class TasksUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_User_UserWhoCompletedTaskHoursId",
                schema: "BankTimeApp",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_User_UserWhoOwesHoursId1",
                schema: "BankTimeApp",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_User_UserId1",
                schema: "BankTimeApp",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_UserId1",
                schema: "BankTimeApp",
                table: "Tasks");

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

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId1",
                schema: "BankTimeApp",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "BankTimeApp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "BankTimeApp",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "BankTimeApp",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "BankTimeApp",
                newName: "Users",
                newSchema: "BankTimeApp");

            migrationBuilder.AddColumn<string>(
                name: "UserAssigned",
                schema: "BankTimeApp",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                schema: "BankTimeApp",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "BankTimeApp",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Users_UserWhoCompletedTaskHoursId",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoCompletedTaskHoursId",
                principalSchema: "BankTimeApp",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Users_UserWhoOwesHoursId1",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoOwesHoursId1",
                principalSchema: "BankTimeApp",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId1",
                schema: "BankTimeApp",
                table: "Requests",
                column: "UserId1",
                principalSchema: "BankTimeApp",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Users_UserWhoCompletedTaskHoursId",
                schema: "BankTimeApp",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Users_UserWhoOwesHoursId1",
                schema: "BankTimeApp",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId1",
                schema: "BankTimeApp",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "BankTimeApp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAssigned",
                schema: "BankTimeApp",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                schema: "BankTimeApp",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "BankTimeApp",
                newName: "User",
                newSchema: "BankTimeApp");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "BankTimeApp",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "BankTimeApp",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "BankTimeApp",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "BankTimeApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: true)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: true)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId1",
                schema: "BankTimeApp",
                table: "Tasks",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_User_UserWhoCompletedTaskHoursId",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoCompletedTaskHoursId",
                principalSchema: "BankTimeApp",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_User_UserWhoOwesHoursId1",
                schema: "BankTimeApp",
                table: "Exchanges",
                column: "UserWhoOwesHoursId1",
                principalSchema: "BankTimeApp",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_User_UserId1",
                schema: "BankTimeApp",
                table: "Requests",
                column: "UserId1",
                principalSchema: "BankTimeApp",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_UserId1",
                schema: "BankTimeApp",
                table: "Tasks",
                column: "UserId1",
                principalSchema: "BankTimeApp",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
