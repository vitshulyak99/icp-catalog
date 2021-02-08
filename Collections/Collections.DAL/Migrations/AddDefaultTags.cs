using Microsoft.EntityFrameworkCore.Migrations;

namespace Collections.DAL.Migrations
{
    public partial class AddDefaultTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue");

            migrationBuilder.DropIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValue");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a9c7f0d6-57da-4230-a96e-50a565ab54a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3546deb1-7ab5-42d6-9b07-d55e1173a0ef", "AQAAAAEAACcQAAAAEL8t2FLk3U98AKFio5kW2u2fxKF6R26b8j1wIZnOPPJer10FLHcivLBRbxnuYp64Fg==", "2ce68547-1f59-461e-bd79-c1dbe553b1f2" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SomeTag" },
                    { 2, "SomeTag2" },
                    { 3, "Lamba" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ade65935-6ea8-4722-bf73-1f64590ff83f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09675cf-c975-485a-a61d-55a12cdf264e", "AQAAAAEAACcQAAAAEKJPCxswaEyt1h6h5oxGtpBqpftBWJU7Q8tRGEGGQY7zeS7+kQNA2+Ve3cr8oCCm2A==", "b86369e7-56cd-4843-b761-fccebdded0b5" });

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_FieldId",
                table: "FieldValue",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldValue_FieldDef_FieldId",
                table: "FieldValue",
                column: "FieldId",
                principalTable: "FieldDef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
