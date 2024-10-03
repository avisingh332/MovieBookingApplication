using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedpriceinshowentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "20f558d5-c8bb-4662-96db-c1ae47a651c4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "9a41542e-8b3f-4408-84ed-6e7fbb4bef68" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "bf57efdf-c474-4624-9679-283591048623" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20f558d5-c8bb-4662-96db-c1ae47a651c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a41542e-8b3f-4408-84ed-6e7fbb4bef68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf57efdf-c474-4624-9679-283591048623");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Shows",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13442f0b-d40a-4abd-a135-cb1e18361bf7", 0, "133586e2-fd8f-4584-89a7-828ead068034", "user2@test.com", false, false, null, "User 2", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEBZibGUvA2wWtZoQVR9PUmxDBEtDo+U0sCnxturevNK1zmH4V/9MbmUhxHyWnRrLTg==", null, false, "43f4bead-b8f7-490b-a855-dcbef9d9ccf1", false, "user2@test.com" },
                    { "464b13d9-b4c5-4d5f-84be-327a482843b4", 0, "e5b36bbe-e035-447a-bd6e-10e7b89fd1ea", "admin@test.com", false, false, null, "Admin", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEKC0P61Qzqpol7I41bo/aQeQIWYWTtLcER5H+zJkJ9vZSv0/Tr0WvqazFJnqJQdURQ==", null, false, "5ce9351b-af29-48b4-b8dd-3ec0a4929585", false, "admin@test.com" },
                    { "940a3add-734f-4d35-9bd3-a4fab2f47907", 0, "95edcd8f-113a-4a3d-80cf-e556b52c96e9", "user1@test.com", false, false, null, "User 1", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEMi5RGP3ST8J2V94VD32uNdc80Ythz58WhvUKoERiqGP1dJUNLqqR24Ta6/uXBsNCQ==", null, false, "d9ccbad6-ce2b-4d06-a8cc-bb7e6154f2f6", false, "user1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "13442f0b-d40a-4abd-a135-cb1e18361bf7" },
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "464b13d9-b4c5-4d5f-84be-327a482843b4" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "940a3add-734f-4d35-9bd3-a4fab2f47907" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "13442f0b-d40a-4abd-a135-cb1e18361bf7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "464b13d9-b4c5-4d5f-84be-327a482843b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "940a3add-734f-4d35-9bd3-a4fab2f47907" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13442f0b-d40a-4abd-a135-cb1e18361bf7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "464b13d9-b4c5-4d5f-84be-327a482843b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "940a3add-734f-4d35-9bd3-a4fab2f47907");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shows");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20f558d5-c8bb-4662-96db-c1ae47a651c4", 0, "99389a6e-7096-4f8e-bd2b-15d74071c141", "admin@test.com", false, false, null, "Admin", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEMM9yvd7h0XL49Eyj2C/OGuuE7OTJnT8RSe1o74zwcLmChyE/vNFmJk9CJMjP2aOyA==", null, false, "22de654f-17b7-47bb-8e30-f807f7004bfa", false, "admin@test.com" },
                    { "9a41542e-8b3f-4408-84ed-6e7fbb4bef68", 0, "6ff747d3-504c-4833-9379-bf0399b009a1", "user2@test.com", false, false, null, "User 2", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEC19k0Ge3x+Ny6VrQUHMwZlvsO7j/p2CXgvu0OnfqtCaef3n/Fxc+bMdN0ct5n7VMQ==", null, false, "8d6632da-dce6-4427-bbc5-5ab12ff591c6", false, "user2@test.com" },
                    { "bf57efdf-c474-4624-9679-283591048623", 0, "73414e60-a2cf-458a-9dd6-913855bb17cf", "user1@test.com", false, false, null, "User 1", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEFVzt+rXy5DdVupgQvsIeyIK7gjnUVF2QJwDpvxcZ/rcl7J+UHcib4M9YsLUO+KGuA==", null, false, "f1a9b167-4d0d-49d4-b4e5-b5849371a088", false, "user1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "20f558d5-c8bb-4662-96db-c1ae47a651c4" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "9a41542e-8b3f-4408-84ed-6e7fbb4bef68" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "bf57efdf-c474-4624-9679-283591048623" }
                });
        }
    }
}
