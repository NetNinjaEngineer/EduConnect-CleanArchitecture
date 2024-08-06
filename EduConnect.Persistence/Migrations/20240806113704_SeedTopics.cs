using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "TopicName" },
                values: new object[,]
                {
                    { new Guid("096acc69-09a4-4f36-84ff-322e9846ad54"), "Machine Learning" },
                    { new Guid("5393a6fe-5c8b-42af-a453-2af2c64f5a35"), "Internet of Things (IoT)" },
                    { new Guid("62841cba-863b-4816-9366-e789646ca43e"), "Cybersecurity" },
                    { new Guid("71fd7466-e4d4-41f6-ace8-ed67ea8fafcf"), "Artificial Intelligence" },
                    { new Guid("7db2ed45-a087-4e00-b804-b944f400f450"), "Cloud Computing" },
                    { new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563"), "Programming" },
                    { new Guid("b16ea527-9f9c-4c58-8385-a2f69e5c83d9"), "Web Development" },
                    { new Guid("b8c0db6a-716d-4004-9c89-0e7cf1ba790c"), "DevOps Practices" },
                    { new Guid("b9dd9a87-4852-434e-99dd-3103f7fba183"), "Mobile App Development" },
                    { new Guid("df8d86f9-69d9-4eda-9fc4-aa8725c7a47b"), "Blockchain Technology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("096acc69-09a4-4f36-84ff-322e9846ad54"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("5393a6fe-5c8b-42af-a453-2af2c64f5a35"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("62841cba-863b-4816-9366-e789646ca43e"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("71fd7466-e4d4-41f6-ace8-ed67ea8fafcf"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("7db2ed45-a087-4e00-b804-b944f400f450"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("9b0418c2-d8c8-46fb-bd0d-0094f83ad563"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b16ea527-9f9c-4c58-8385-a2f69e5c83d9"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b8c0db6a-716d-4004-9c89-0e7cf1ba790c"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("b9dd9a87-4852-434e-99dd-3103f7fba183"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("df8d86f9-69d9-4eda-9fc4-aa8725c7a47b"));
        }
    }
}
