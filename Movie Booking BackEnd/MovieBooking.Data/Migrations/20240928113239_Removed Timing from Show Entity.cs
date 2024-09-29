using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTimingfromShowEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "8124a30e-3eb4-496f-a19f-d48b7905fe9b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "88a1db89-5d02-47fc-a2f7-48b441a6dc9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "9a0d72ae-5298-4f9d-a89f-657aadbf8b3b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8124a30e-3eb4-496f-a19f-d48b7905fe9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88a1db89-5d02-47fc-a2f7-48b441a6dc9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0d72ae-5298-4f9d-a89f-657aadbf8b3b");

            migrationBuilder.DropColumn(
                name: "Timing",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Timing",
                table: "Shows",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8124a30e-3eb4-496f-a19f-d48b7905fe9b", 0, "630bcece-1059-4c5b-85a8-61d4bb77104b", "user2@test.com", false, false, null, "User 2", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEMQg7r8iB/qFB0q6zkhG20CZglE1Gauw7qWISGmVeJEjcQwQ/xUk6IB2khQuFs4Ysw==", null, false, "5a3c0d8b-253d-43fc-a638-07ab61f2479f", false, "user2@test.com" },
                    { "88a1db89-5d02-47fc-a2f7-48b441a6dc9f", 0, "a25fb4ec-8607-4983-bc16-c26e5ce921c8", "admin@test.com", false, false, null, "Admin", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEGT/9rWa9CzlAJaL2P91qIgQZrBEj0DjVIzpZwquPkFX+3UU02xgwfyCSWgAHWZMIg==", null, false, "e152a3b5-1833-46bc-a9c9-0cdf53d1cbe0", false, "admin@test.com" },
                    { "9a0d72ae-5298-4f9d-a89f-657aadbf8b3b", 0, "809d896c-5640-42b8-95b2-47219dab3f5a", "user1@test.com", false, false, null, "User 1", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEHg0JP4s8UwS/+yiO7aeBBa4XXwbwlui4ecOSwSTg+Ar36VWqOB0rFY0iEVEpxS0cg==", null, false, "1234323e-2f22-4e94-8223-2c03a646b376", false, "user1@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "8124a30e-3eb4-496f-a19f-d48b7905fe9b" },
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "88a1db89-5d02-47fc-a2f7-48b441a6dc9f" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "9a0d72ae-5298-4f9d-a89f-657aadbf8b3b" }
                });
        }
    }
}
