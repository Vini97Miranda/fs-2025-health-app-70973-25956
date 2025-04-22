using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 4, 21, 15, 48, 22, 563, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 4, 20, 15, 48, 22, 563, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 4, 19, 15, 48, 22, 563, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3dbaedf3-1450-44a6-a82d-c9dd4826d654");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ad15e175-c424-41aa-8b3d-66fe9c284d01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b487bdce-9c01-46a8-9aec-d6bcaa082920");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "996f1c7c-85af-4f11-b2bb-822d64ca3de0", "felipe.admin@demo.com", "Felipe", "Admin", "FELIPE.ADMIN@DEMO.COM", "FELIPE.ADMIN", "AQAAAAIAAYagAAAAEMJvfWug+nwRqd34d5Db0Dhfxr3u395AbVwGZM67U6dQoW+PNdyBSH3FbjkpafhmxQ==", "477632e3-2e35-4342-a595-74e3b43e668a", "felipe.admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "43135996-fd15-4be0-a6cb-1d3c2462ae25", "luna.silva@demo.com", "Luna", "Silva", "LUNA.SILVA@DEMO.COM", "LUNA.SILVA", "AQAAAAIAAYagAAAAEIpi8Q9V09O8FYxaj4mbgx0OlYmjPUC4cE8IudePK+CmHU4I+B9Szrtz+dyX12sESA==", "e17deb7d-21b1-42ad-955c-d8ed81333cc4", "luna.silva" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "292e8b49-92f8-4a02-a12e-38faf490871b", "dr.bruno@demo.com", "Dr. Bruno", "Santos", "DR.BRUNO@DEMO.COM", "DR.BRUNO", "AQAAAAIAAYagAAAAECtgLKsCYb/PneKbIIYwOmi2+ZFpR6dGZwA4oy02uOX1H026Ty1y9cpSgV62ypsZTg==", "4c49d425-a50b-4180-bbf2-7fa67244f307", "dr.bruno" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 4, 21, 11, 33, 20, 977, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 4, 20, 11, 33, 20, 977, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 4, 19, 11, 33, 20, 977, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d9dd2b48-285f-4818-bb7a-d58a289c91d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b76a048a-96d0-4446-92f4-1aba55b1308a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b6728c1c-f2d0-4063-abac-5bf8b5eda364");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "55021914-cfbb-4c37-9d08-357c399d1aba", "admin@email.com", "Admin", "Test", "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEHUyEBAfL6QYagIc0/OXMhi9ZPbFL37ayy+iqt92ewv3ZYChNHe/FXPRF87ShS0WIw==", "18cdc90d-4042-4658-a658-40075ad135f6", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "18551aca-b82f-4afd-bd27-8efc5b0f7c17", "alexandra.valkova@email.com", "Alexandra", "Valkova", "ALEXANDRA.VALKOVA@EMAIL.COM", "ALEXANDRA.VALKOVA", "AQAAAAIAAYagAAAAECyuSVV/BSOvuj8RBNdZi9xtEZPZGjufpd2wlL3KuW3Snk9ZpUWDhL1ZERa357LNfg==", "3b1ff1ad-7cb9-4154-b775-7cbd804dad7f", "alexandra.valkova" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3154599d-2e2d-425e-85f1-0f9a3e2218c9", "diana.yosifova@email.com", "Diana", "Yosifova", "DIANA.YOSIFOVA@EMAIL.COM", "DIANA.YOSIFOVA", "AQAAAAIAAYagAAAAEFIzhwk56pIthZnBoOzgWd5luKep7IzRnukUix3beh+GvdDYas/yJDjeLr5V1lVZkA==", "14f46ea2-d213-49ed-ad34-7a3c299f396d", "diana.yosifova" });
        }
    }
}
