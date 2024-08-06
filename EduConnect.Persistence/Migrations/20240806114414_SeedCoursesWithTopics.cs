using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoursesWithTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Duration", "TopicId" },
                values: new object[,]
                {
                    { new Guid("0bca523a-285d-48fd-a805-7950f6bf676f"), "TypeScript for Beginners", 20, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("102f8148-fcf8-4c1f-b513-21327622b8e1"), "Java Programming", 50, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("1ab8063b-dc0f-43a6-9109-ed1b6770c82d"), "Internet of Things (IoT)", 35, new Guid("5393a6fe-5c8b-42af-a453-2af2c64f5a35") },
                    { new Guid("1e2bac13-26be-4ff0-9716-ea95970a7bb7"), "Machine Learning", 50, new Guid("71fd7466-e4d4-41f6-ace8-ed67ea8fafcf") },
                    { new Guid("34f1d3b2-5e90-4873-a5c8-f9a3ae175b3b"), "JavaScript Essentials", 25, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("375a26a9-a1ed-42e2-95e7-e9a30824d192"), "Python Programming", 45, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("4976c9f0-c558-41bf-be86-190249fac48d"), "Advanced C#", 40, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("4996138f-fd12-4126-9e29-6bbf7e0330bf"), "React Fundamentals", 35, new Guid("b16ea527-9f9c-4c58-8385-a2f69e5c83d9") },
                    { new Guid("5661c5b1-3fc1-4b84-99f5-898c6679fdf2"), "SQL Basics", 30, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("6bae2c61-0dd3-44e4-8c0c-e98add7f3948"), "Cloud Computing", 30, new Guid("7db2ed45-a087-4e00-b804-b944f400f450") },
                    { new Guid("7496625c-9fad-4a07-87c6-98ba31c0064f"), "DevOps Practices", 35, new Guid("7db2ed45-a087-4e00-b804-b944f400f450") },
                    { new Guid("808ca6a1-258e-4077-a443-af979e010d73"), "Algorithms", 40, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("83c47415-c606-4cf5-a13f-d692e7326edd"), "NoSQL Databases", 40, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("99eedb49-b4f1-4c13-a3ce-80059ab6f559"), "Data Structures", 35, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("a4207bab-0908-4ff5-878c-0ae69dba6457"), "Blockchain Technology", 40, new Guid("df8d86f9-69d9-4eda-9fc4-aa8725c7a47b") },
                    { new Guid("aa25d7c5-5f48-40b3-be6e-4bf6eb577f7a"), "Artificial Intelligence", 55, new Guid("71fd7466-e4d4-41f6-ace8-ed67ea8fafcf") },
                    { new Guid("bf1dcec8-b9fe-40f0-b847-2a142fc320f3"), "Cybersecurity Basics", 25, new Guid("62841cba-863b-4816-9366-e789646ca43e") },
                    { new Guid("e99c06c9-8605-4136-9c40-556bfd9ee2a2"), "Mobile App Development", 45, new Guid("b9dd9a87-4852-434e-99dd-3103f7fba183") },
                    { new Guid("ed9aafb1-872d-48a9-ade2-1a37b3a39f56"), "C# Basics", 30, new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563") },
                    { new Guid("f8475a7e-7778-4ddf-8bf7-6879da2e2e02"), "Web Development", 50, new Guid("b16ea527-9f9c-4c58-8385-a2f69e5c83d9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("0bca523a-285d-48fd-a805-7950f6bf676f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("102f8148-fcf8-4c1f-b513-21327622b8e1"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1ab8063b-dc0f-43a6-9109-ed1b6770c82d"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1e2bac13-26be-4ff0-9716-ea95970a7bb7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("34f1d3b2-5e90-4873-a5c8-f9a3ae175b3b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("375a26a9-a1ed-42e2-95e7-e9a30824d192"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4976c9f0-c558-41bf-be86-190249fac48d"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("4996138f-fd12-4126-9e29-6bbf7e0330bf"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5661c5b1-3fc1-4b84-99f5-898c6679fdf2"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("6bae2c61-0dd3-44e4-8c0c-e98add7f3948"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("7496625c-9fad-4a07-87c6-98ba31c0064f"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("808ca6a1-258e-4077-a443-af979e010d73"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("83c47415-c606-4cf5-a13f-d692e7326edd"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("99eedb49-b4f1-4c13-a3ce-80059ab6f559"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("a4207bab-0908-4ff5-878c-0ae69dba6457"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("aa25d7c5-5f48-40b3-be6e-4bf6eb577f7a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("bf1dcec8-b9fe-40f0-b847-2a142fc320f3"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("e99c06c9-8605-4136-9c40-556bfd9ee2a2"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ed9aafb1-872d-48a9-ade2-1a37b3a39f56"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f8475a7e-7778-4ddf-8bf7-6879da2e2e02"));
        }
    }
}
