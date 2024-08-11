using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFootballPitch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8559), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8561), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8563), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8562) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8958), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8955) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8961), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8964), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8966), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8968), new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8904), new DateTime(2024, 9, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8899) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8906), new DateTime(2024, 10, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9068), new DateTime(2024, 8, 11, 6, 12, 21, 790, DateTimeKind.Local).AddTicks(9065), new DateTime(2024, 8, 11, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9073), new DateTime(2024, 8, 13, 6, 12, 21, 790, DateTimeKind.Local).AddTicks(9071), new DateTime(2024, 8, 13, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9077), new DateTime(2024, 8, 14, 6, 12, 21, 790, DateTimeKind.Local).AddTicks(9075), new DateTime(2024, 8, 14, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9081), new DateTime(2024, 8, 14, 6, 12, 21, 790, DateTimeKind.Local).AddTicks(9079), new DateTime(2024, 8, 15, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 12, 4, 12, 21, 790, DateTimeKind.Local).AddTicks(8859));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6215), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6217), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6414), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6417), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6416) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6419), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6418) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6421), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6423), new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6422) });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6376), new DateTime(2024, 9, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6379), new DateTime(2024, 10, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6378) });

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6459), new DateTime(2024, 8, 8, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6456), new DateTime(2024, 8, 8, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6462), new DateTime(2024, 8, 10, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6461), new DateTime(2024, 8, 10, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6465), new DateTime(2024, 8, 11, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6464), new DateTime(2024, 8, 11, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6463) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6468), new DateTime(2024, 8, 11, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6467), new DateTime(2024, 8, 12, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6466) });

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6348));
        }
    }
}
