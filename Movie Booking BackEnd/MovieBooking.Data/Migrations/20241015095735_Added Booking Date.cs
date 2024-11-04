using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "UserBookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "25a12575-2505-48f6-8831-51c5c0032e25", 0, "c1fc005e-b2ce-4a1a-8e79-377432c5c488", "admin@test.com", false, false, null, "Admin", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEASLXxUEyrqn6I3ec0xvCNpJfML1ztmNJ6mb8yScj9bkPUTusCzVxbSn3FSEUFfJMA==", null, false, "d9ddfddd-53fa-4d08-919f-2e3c4ce459ba", false, "admin@test.com" },
                    { "be74ea1a-746c-4f02-a801-37651226c86c", 0, "000ceda3-3747-4557-8a57-5f47263247f6", "user2@test.com", false, false, null, "User 2", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAECK1bnzd9W60/jaowsoltWd7NhSfP0BFCEyN5IUmm37Md0Vb8DlDFcp+55qgzl0WSA==", null, false, "5002dfcd-d075-446d-83b3-5d9ed6fa9a87", false, "user2@test.com" },
                    { "d73bc0bb-9974-4d09-b31d-7e1908f3f029", 0, "c3a0738a-ac42-4b9a-a5fd-5c4865834a60", "user1@test.com", false, false, null, "User 1", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEJh+lwbdzecx3Rm2ONjO2aW0nwhVmm+fMKHpg9aKBmj77FcA5nQBMcByJiV9lWFDbQ==", null, false, "06743a2a-f515-4585-85ea-0f51059c3352", false, "user1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "25a12575-2505-48f6-8831-51c5c0032e25" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "be74ea1a-746c-4f02-a801-37651226c86c" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "d73bc0bb-9974-4d09-b31d-7e1908f3f029" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "25a12575-2505-48f6-8831-51c5c0032e25" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "be74ea1a-746c-4f02-a801-37651226c86c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "d73bc0bb-9974-4d09-b31d-7e1908f3f029" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25a12575-2505-48f6-8831-51c5c0032e25");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be74ea1a-746c-4f02-a801-37651226c86c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d73bc0bb-9974-4d09-b31d-7e1908f3f029");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "UserBookings");

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
    }
}
