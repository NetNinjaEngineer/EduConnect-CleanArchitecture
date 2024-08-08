using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCultureFieldsCourseTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TopicNameAr",
                table: "Topics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseNameAr",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("0bca523a-285d-48fd-a805-7950f6bf676f"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("102f8148-fcf8-4c1f-b513-21327622b8e1"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1ab8063b-dc0f-43a6-9109-ed1b6770c82d"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1e2bac13-26be-4ff0-9716-ea95970a7bb7"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("34f1d3b2-5e90-4873-a5c8-f9a3ae175b3b"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("375a26a9-a1ed-42e2-95e7-e9a30824d192"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4976c9f0-c558-41bf-be86-190249fac48d"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4996138f-fd12-4126-9e29-6bbf7e0330bf"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5661c5b1-3fc1-4b84-99f5-898c6679fdf2"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6bae2c61-0dd3-44e4-8c0c-e98add7f3948"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7496625c-9fad-4a07-87c6-98ba31c0064f"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("808ca6a1-258e-4077-a443-af979e010d73"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("83c47415-c606-4cf5-a13f-d692e7326edd"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("99eedb49-b4f1-4c13-a3ce-80059ab6f559"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a4207bab-0908-4ff5-878c-0ae69dba6457"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("aa25d7c5-5f48-40b3-be6e-4bf6eb577f7a"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bf1dcec8-b9fe-40f0-b847-2a142fc320f3"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e99c06c9-8605-4136-9c40-556bfd9ee2a2"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ed9aafb1-872d-48a9-ade2-1a37b3a39f56"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f8475a7e-7778-4ddf-8bf7-6879da2e2e02"),
                column: "CourseNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("096acc69-09a4-4f36-84ff-322e9846ad54"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("5393a6fe-5c8b-42af-a453-2af2c64f5a35"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("62841cba-863b-4816-9366-e789646ca43e"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("71fd7466-e4d4-41f6-ace8-ed67ea8fafcf"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("7db2ed45-a087-4e00-b804-b944f400f450"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b16ea527-9f9c-4c58-8385-a2f69e5c83d9"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b8c0db6a-716d-4004-9c89-0e7cf1ba790c"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b9dd9a87-4852-434e-99dd-3103f7fba183"),
                column: "TopicNameAr",
                value: null);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("df8d86f9-69d9-4eda-9fc4-aa8725c7a47b"),
                column: "TopicNameAr",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopicNameAr",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CourseNameAr",
                table: "Courses");
        }
    }
}
