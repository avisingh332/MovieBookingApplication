using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoviesshowsuserbookingsapplicationuserentityandalsoseededdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScreenNo = table.Column<int>(type: "int", nullable: false),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatsBooked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookings_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1", "Admin", "ADMIN" },
                    { "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "95cb1e1c-d8b6-45a2-b240-6d211c06fd00", "User", "USER" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookings_ShowId",
                table: "UserBookings",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookings_UserId",
                table: "UserBookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBookings");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95cb1e1c-d8b6-45a2-b240-6d211c06fd00");

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
        }
    }
}
