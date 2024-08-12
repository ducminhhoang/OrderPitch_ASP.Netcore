using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFootballPitch.Migrations
{
    public partial class dan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9353), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9355), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9355) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9357), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9549), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9551), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9553), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9555), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9557), new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9471), new DateTime(2024, 9, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9475), new DateTime(2024, 10, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "FootballPitches",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9595), new DateTime(2024, 8, 10, 23, 40, 49, 14, DateTimeKind.Local).AddTicks(9593), new DateTime(2024, 8, 10, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9598), new DateTime(2024, 8, 12, 23, 40, 49, 14, DateTimeKind.Local).AddTicks(9597), new DateTime(2024, 8, 12, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9601), new DateTime(2024, 8, 13, 23, 40, 49, 14, DateTimeKind.Local).AddTicks(9600), new DateTime(2024, 8, 13, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9599) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndAt", "StartAt" },
                values: new object[] { new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9603), new DateTime(2024, 8, 13, 23, 40, 49, 14, DateTimeKind.Local).AddTicks(9602), new DateTime(2024, 8, 14, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "PitchTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 8, 11, 21, 40, 49, 14, DateTimeKind.Local).AddTicks(9442));
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
