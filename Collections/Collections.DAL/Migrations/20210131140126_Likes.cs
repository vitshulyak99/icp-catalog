using Microsoft.EntityFrameworkCore.Migrations;

namespace Collections.DAL.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Items_ItemId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ItemId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "LikedItems",
                columns: table => new
                {
                    LikedItemsId = table.Column<int>(type: "integer", nullable: false),
                    UserLikeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedItems", x => new { x.LikedItemsId, x.UserLikeId });
                    table.ForeignKey(
                        name: "FK_LikedItems_AspNetUsers_UserLikeId",
                        column: x => x.UserLikeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedItems_Items_LikedItemsId",
                        column: x => x.LikedItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "09b34519-29fa-486e-a56c-3549e619f1e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63501b9e-c2fd-4c54-80b2-4ff5e07d60c9", "AQAAAAEAACcQAAAAECn17+0UpnoolZpYfp64oP2fPvBJVSKCM+2oKyH3VbeaPXgmYqIQjq6my60dPXDucA==", "8be16886-2315-4448-8619-e3115dc3850b" });

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_UserLikeId",
                table: "LikedItems",
                column: "UserLikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "58797a15-03fe-4505-ae78-2f6e634343a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99f7ca5e-0cf2-42c4-9534-5e52110faf46", "AQAAAAEAACcQAAAAEMpYJke+/qIYfrTYc37sgnIZhsWFRQl0J8FLNTqWtT8AKW1pAHfyhYhWx4sMcXy90g==", "e3742ebb-98ed-4660-97c6-c73f9a5149a2" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ItemId",
                table: "AspNetUsers",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Items_ItemId",
                table: "AspNetUsers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
