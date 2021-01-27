using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Collections.DAL.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CollectionItems_CollectionItemId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_CollectionItems_CollectionItemId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "CollectionItemTag");

            migrationBuilder.DropTable(
                name: "CustomFieldValue");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionItems",
                table: "CollectionItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "CollectionItems",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "CollectionItemId",
                table: "Comment",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CollectionItemId",
                table: "Comment",
                newName: "IX_Comment_ItemId");

            migrationBuilder.RenameColumn(
                name: "CollectionItemId",
                table: "AspNetUsers",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CollectionItemId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CollectionItems_CollectionId",
                table: "Items",
                newName: "IX_Items_CollectionId");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AspNetUserRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AspNetUserRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FieldDef",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CollectionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDef_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    ItemTagsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.ItemTagsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Items_ItemTagsId",
                        column: x => x.ItemTagsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldValue_FieldDef_FieldId",
                        column: x => x.FieldId,
                        principalTable: "FieldDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldValue_FieldDef_Id",
                        column: x => x.Id,
                        principalTable: "FieldDef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldValue_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ade65935-6ea8-4722-bf73-1f64590ff83f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 1, 1, "IdentityUserRole<int>" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09675cf-c975-485a-a61d-55a12cdf264e", "AQAAAAEAACcQAAAAEKJPCxswaEyt1h6h5oxGtpBqpftBWJU7Q8tRGEGGQY7zeS7+kQNA2+Ve3cr8oCCm2A==", "b86369e7-56cd-4843-b761-fccebdded0b5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_AppRoleId",
                table: "AspNetUserRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_AppUserId",
                table: "AspNetUserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDef_CollectionId",
                table: "FieldDef",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValue",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_ItemId",
                table: "FieldValue",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagsId",
                table: "ItemTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_AppRoleId",
                table: "AspNetUserRoles",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_AppUserId",
                table: "AspNetUserRoles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Items_ItemId",
                table: "AspNetUsers",
                column: "ItemId",
                principalTable: "Items",
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
                name: "FK_Items_Collections_CollectionId",
                table: "Items",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_AppRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_AppUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Items_ItemId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Items_ItemId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Collections_CollectionId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "FieldValue");

            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropTable(
                name: "FieldDef");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_AppRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_AppUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "CollectionItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Comment",
                newName: "CollectionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ItemId",
                table: "Comment",
                newName: "IX_Comment_CollectionItemId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "AspNetUsers",
                newName: "CollectionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ItemId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CollectionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CollectionId",
                table: "CollectionItems",
                newName: "IX_CollectionItems_CollectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionItems",
                table: "CollectionItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CollectionItemTag",
                columns: table => new
                {
                    ItemTagsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionItemTag", x => new { x.ItemTagsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionItemTag_CollectionItems_ItemTagsId",
                        column: x => x.ItemTagsId,
                        principalTable: "CollectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionItemTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollectionId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomField_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollectionItemId = table.Column<int>(type: "integer", nullable: true),
                    CustomFieldId = table.Column<int>(type: "integer", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_CollectionItems_CollectionItemId",
                        column: x => x.CollectionItemId,
                        principalTable: "CollectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFieldValue_CustomField_Id",
                        column: x => x.Id,
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5a471762-060a-468e-935b-a2029c08d798");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "5de56061-71c2-41a1-90f4-051fecc99466", "customer", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8cf12d6-ae2f-4ee4-a018-ce234d097aa8", "AQAAAAEAACcQAAAAEHHbaydgN7hc05o/l0HtyJPUSizorw50MlRsSGa39WGnxAdzxvcxAoZTlQHHo4Orbg==", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CollectionItemId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, null, "bb4ff1e8-a25d-4660-9d7c-5258b82d388e", "user@icp.cc", true, false, null, "user@icp.cc", "USER@ICP.CC", "AQAAAAEAACcQAAAAEDxCD5bWdEoyIvffAecSbtqvhJ5GOXnJZykn0GXIUjFFkuevZ2lKOXRoqSrOiGiCeQ==", null, false, null, false, "USER@ICP.CC" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItemTag_TagsId",
                table: "CollectionItemTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_CollectionId",
                table: "CustomField",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValue_CollectionItemId",
                table: "CustomFieldValue",
                column: "CollectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValue_CustomFieldId",
                table: "CustomFieldValue",
                column: "CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CollectionItems_CollectionItemId",
                table: "AspNetUsers",
                column: "CollectionItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Collections_CollectionId",
                table: "CollectionItems",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_CollectionItems_CollectionItemId",
                table: "Comment",
                column: "CollectionItemId",
                principalTable: "CollectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
