using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    FriendID = table.Column<long>(nullable: false),
                    AddFriendDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.id);
                    table.ForeignKey(
                        name: "FK_Friend_User1",
                        column: x => x.FriendID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friend_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendID = table.Column<long>(nullable: false),
                    RecieveID = table.Column<long>(nullable: false),
                    MessageText = table.Column<string>(nullable: false),
                    SendDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.id);
                    table.ForeignKey(
                        name: "FK_Message_User1",
                        column: x => x.RecieveID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User",
                        column: x => x.SendID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestFriend",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendUserID = table.Column<long>(nullable: false),
                    RecieveUserID = table.Column<long>(nullable: false),
                    DateSend = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFriend", x => x.id);
                    table.ForeignKey(
                        name: "FK_RequestFriend_User1",
                        column: x => x.RecieveUserID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestFriend_User",
                        column: x => x.SendUserID,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendID",
                table: "Friend",
                column: "FriendID");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserID",
                table: "Friend",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RecieveID",
                table: "Message",
                column: "RecieveID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SendID",
                table: "Message",
                column: "SendID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFriend_RecieveUserID",
                table: "RequestFriend",
                column: "RecieveUserID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFriend_SendUserID",
                table: "RequestFriend",
                column: "SendUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "RequestFriend");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
