using Microsoft.EntityFrameworkCore.Migrations;

namespace Collections.DAL.Migrations
{
    public partial class EditEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_SenderId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Items_ItemId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_FieldDef_Id",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_Text",
                table: "Comments",
                newName: "IX_Comments_Text");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_SenderId",
                table: "Comments",
                newName: "IX_Comments_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ItemId",
                table: "Comments",
                newName: "IX_Comments_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "FieldValue",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

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
                name: "IX_FieldValue_FieldId",
                table: "FieldValue",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId",
                table: "Comments",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "FieldDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_SenderId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue");

            migrationBuilder.DropIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Text",
                table: "Comment",
                newName: "IX_Comment_Text");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_SenderId",
                table: "Comment",
                newName: "IX_Comment_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ItemId",
                table: "Comment",
                newName: "IX_Comment_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "FieldId",
                table: "FieldValue",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "28faed5d-e9e5-48a3-82f2-ddee60774233");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dd7faf4-f047-4db2-8189-8e1ccf0cdb82", "AQAAAAEAACcQAAAAELQoJf15ChXp1KSpdPlUsr1HtjDrlrRwmYcAGoBs66SaG3Qdux5oS35CPdHYOxaHpQ==", "df502f61-938f-44fc-adcb-6e56cf8c8ebf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_SenderId",
                table: "Comment",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Items_ItemId",
                table: "Comment",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_FieldDef_Id",
                table: "FieldValue",
                column: "Id",
                principalTable: "FieldDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
