using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

namespace Collections.DAL.Migrations
{
    public partial class AddLikeEntityAndGeneratedSearchVectorColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_Items_ItemId",
                table: "FieldValue");

            migrationBuilder.DropTable(
                name: "LikedItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_Name",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Text",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Collections_Title_Description",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue");

            migrationBuilder.DropIndex(
                name: "IX_FieldValue_Value",
                table: "FieldValue");

            migrationBuilder.RenameTable(
                name: "FieldValue",
                newName: "FieldValues");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValue_ItemId",
                table: "FieldValues",
                newName: "IX_FieldValues_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValues",
                newName: "IX_FieldValues_FieldId");

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Items",
                type: "tsvector",
                nullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Name" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "FieldDef",
                type: "tsvector",
                nullable: true);

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Comments",
                type: "tsvector",
                nullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Text" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Collections",
                type: "tsvector",
                nullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Description", "Title" });

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "FieldValues",
                type: "tsvector",
                nullable: true)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldValues",
                table: "FieldValues",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f11e3dc9-4768-4794-9f9d-e76a3ab636d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "691b44f9-20d4-4637-980f-9709f8e5691c", "AQAAAAEAACcQAAAAEFdE5fXK8m2vyzX7MMiPhWURlEK/0CespCk+2yoqyNFTbKRGLFs20sCLPXPydqOICQ==", "18eac5a1-d8a4-4e60-98fc-cc8b4c522401" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SearchVector",
                table: "Items",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SearchVector",
                table: "Comments",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_SearchVector",
                table: "Collections",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValues_SearchVector",
                table: "FieldValues",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValues_FieldDef_FieldId",
                table: "FieldValues",
                column: "FieldId",
                principalTable: "FieldDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValues_Items_ItemId",
                table: "FieldValues",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldValues_FieldDef_FieldId",
                table: "FieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldValues_Items_ItemId",
                table: "FieldValues");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Items_SearchVector",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SearchVector",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Collections_SearchVector",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldValues",
                table: "FieldValues");

            migrationBuilder.DropIndex(
                name: "IX_FieldValues_SearchVector",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "FieldDef");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "FieldValues");

            migrationBuilder.RenameTable(
                name: "FieldValues",
                newName: "FieldValue");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValues_ItemId",
                table: "FieldValue",
                newName: "IX_FieldValue_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldValues_FieldId",
                table: "FieldValue",
                newName: "IX_FieldValue_FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldValue",
                table: "FieldValue",
                column: "Id");

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
                name: "IX_Items_Name",
                table: "Items",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Text",
                table: "Comments",
                column: "Text")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Title_Description",
                table: "Collections",
                columns: new[] { "Title", "Description" })
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_Value",
                table: "FieldValue",
                column: "Value")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_UserLikeId",
                table: "LikedItems",
                column: "UserLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "FieldDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_Items_ItemId",
                table: "FieldValue",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
