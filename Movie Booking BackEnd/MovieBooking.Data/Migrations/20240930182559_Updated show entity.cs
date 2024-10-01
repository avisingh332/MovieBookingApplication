using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatedshowentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "115e32bb-af52-465e-b5e8-6496a9bd3cc8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "7a33dea3-5356-4d29-9f9f-e2823d46d849" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "8293b029-9682-47a8-8085-778e41d1d8cd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "115e32bb-af52-465e-b5e8-6496a9bd3cc8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a33dea3-5356-4d29-9f9f-e2823d46d849");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8293b029-9682-47a8-8085-778e41d1d8cd");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Shows",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Shows",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Shows");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "115e32bb-af52-465e-b5e8-6496a9bd3cc8", 0, "5c46169a-bd35-42ff-9d76-3925cc1e6c0a", "user1@test.com", false, false, null, "User 1", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEJjBFnJCEuVecwfaQugRSAbuhGabjJIux3UrxupygUq98iwPM58kny5HSnHgjJI32Q==", null, false, "01bcddb9-a2a1-4834-9a8b-80a86e4262a9", false, "user1@test.com" },
                    { "7a33dea3-5356-4d29-9f9f-e2823d46d849", 0, "fdad789f-b88d-4def-8e0a-4cd9a7e2101c", "user2@test.com", false, false, null, "User 2", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEAs4dp3qX3ZVn/fv4X/Zgv11wMxeMKB90keaxRFCl/pshT8LFQj9zUxmu1ffmBNRiA==", null, false, "c00e2d43-692b-4c84-bc41-8beb249465c8", false, "user2@test.com" },
                    { "8293b029-9682-47a8-8085-778e41d1d8cd", 0, "0041adbc-333d-46d8-b335-036c6d59cef3", "admin@test.com", false, false, null, "Admin", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEOjwUkqj5KRqZphtRyo+mEJNHnUvnpSE5Efi748AxH9Gtgd4oFwGb2EILDSezAF8dw==", null, false, "20fe2ba7-2eeb-4995-a3f1-883eb753a673", false, "admin@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "115e32bb-af52-465e-b5e8-6496a9bd3cc8" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "7a33dea3-5356-4d29-9f9f-e2823d46d849" },
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "8293b029-9682-47a8-8085-778e41d1d8cd" }
                });
        }
    }
}
