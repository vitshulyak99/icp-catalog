using Microsoft.EntityFrameworkCore.Migrations;

namespace Collections.DAL.Migrations
{
    public partial class AddSearchVectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name",
                table: "Items",
                column: "Name")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_FieldValue_Value",
                table: "FieldValue",
                column: "Value")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Text",
                table: "Comment",
                column: "Text")
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Title_Description",
                table: "Collections",
                columns: new[] { "Title", "Description" })
                .Annotation("Npgsql:IndexMethod", "GIN")
                .Annotation("Npgsql:TsVectorConfig", "english");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_Name",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_FieldValue_Value",
                table: "FieldValue");

            migrationBuilder.DropIndex(
                name: "IX_Comment_Text",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Collections_Title_Description",
                table: "Collections");

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
        }
    }
}
