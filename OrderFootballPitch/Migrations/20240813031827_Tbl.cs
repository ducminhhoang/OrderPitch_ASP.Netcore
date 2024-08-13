using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFootballPitch.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UsageLimit = table.Column<double>(type: "float", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PitchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballPitches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    PricePerHour = table.Column<double>(type: "float", nullable: false),
                    IsMaintenance = table.Column<bool>(type: "bit", nullable: false),
                    PitchTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPitches_PitchTypes_PitchTypeId",
                        column: x => x.PitchTypeId,
                        principalTable: "PitchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FootballPitchId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_FootballPitches_FootballPitchId",
                        column: x => x.FootballPitchId,
                        principalTable: "FootballPitches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PitchImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballPitchId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitchImages_FootballPitches_FootballPitchId",
                        column: x => x.FootballPitchId,
                        principalTable: "FootballPitches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6213), "Admin", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6209) },
                    { 2, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6215), "User", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6214) },
                    { 3, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6217), "Guest", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6216) }
========
                    { 1, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5747), "Admin", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5742) },
                    { 2, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5749), "User", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5749) },
                    { 3, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5751), "Guest", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5750) }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "BankNumber", "CreatedAt", "Image", "Name", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, "123456789", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6359), "Resources\\Banks\\vcb.jpg", "Vietcombank", null },
                    { 2, "987654321", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6360), "Resources\\Banks\\mbbank.jpg", "Mbbank", null }
========
                    { 1, "123456789", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5891), "Resources\\Banks\\vcb.jpg", "Vietcombank", null },
                    { 2, "987654321", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5893), "Resources\\Banks\\mbbank.jpg", "Mbbank", null }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "Code", "CreatedAt", "EndDate", "UpdatedAt", "UsageLimit" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, 10, "Group5MaiDinh", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6376), new DateTime(2024, 9, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6371), null, 1000000.0 },
                    { 2, 20, "Deptraicogisai", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6379), new DateTime(2024, 10, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6378), null, 500000.0 }
========
                    { 1, 10, "Group5MaiDinh", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5908), new DateTime(2024, 9, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5904), null, 1000000.0 },
                    { 2, 20, "Deptraicogisai", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5910), new DateTime(2024, 10, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5909), null, 500000.0 }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "PitchTypes",
                columns: new[] { "Id", "CreatedAt", "Description", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6344), "5v5", 5, null },
                    { 2, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6346), "7v7", 7, null },
                    { 3, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6347), "9v9", 9, null },
                    { 4, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6348), "11v11", 11, null }
========
                    { 1, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5874), "5v5", 5, null },
                    { 2, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5875), "7v7", 7, null },
                    { 3, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5876), "9v9", 9, null },
                    { 4, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5877), "11v11", 11, null }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Address", "CreatedAt", "Email", "Name", "Password", "Phone", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, 1, "Admin Address", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6414), "admin@gmail.com", "Admin1", "8ddcff3a80f4189ca1c9d4d902c3c909", "1234567890", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6412) },
                    { 2, 2, "Ha Noi", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6417), "dmh@example.com", "Duc Minh Hoang", "25d55ad283aa400af464c76d713c07ad", "0987654321", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6416) },
                    { 3, 2, "Ha Noi", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6419), "vtq@gamil.com", "Vu Tung Quan", "25d55ad283aa400af464c76d713c07ad", "0987654322", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6418) },
                    { 4, 2, "Ha Noi", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6421), "vmd@gmail.com", "Vu Minh Duc", "25d55ad283aa400af464c76d713c07ad", "0987654324", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6420) },
                    { 5, 2, "Ha Noi", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6423), "nad@gmail.com", "Nguyen Ai Dan", "25d55ad283aa400af464c76d713c07ad", "0987654325", new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6422) }
========
                    { 1, 1, "Admin Address", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5945), "admin@gmail.com", "Admin1", "8ddcff3a80f4189ca1c9d4d902c3c909", "1234567890", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5942) },
                    { 2, 2, "Ha Noi", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5947), "dmh@example.com", "Duc Minh Hoang", "25d55ad283aa400af464c76d713c07ad", "0987654321", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5946) },
                    { 3, 2, "Ha Noi", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5949), "vtq@gamil.com", "Vu Tung Quan", "25d55ad283aa400af464c76d713c07ad", "0987654322", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5948) },
                    { 4, 2, "Ha Noi", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5951), "vmd@gmail.com", "Vu Minh Duc", "25d55ad283aa400af464c76d713c07ad", "0987654324", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5950) },
                    { 5, 2, "Ha Noi", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5953), "nad@gmail.com", "Nguyen Ai Dan", "25d55ad283aa400af464c76d713c07ad", "0987654325", new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5952) }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "FootballPitches",
                columns: new[] { "Id", "CreatedAt", "Description", "IsMaintenance", "Name", "PitchTypeId", "PricePerHour", "TimeEnd", "TimeStart", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6393), "Standard Pitch", false, "Sân bóng Thành Đô", 2, 700000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), null },
                    { 2, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6395), "Normal Pitch", false, "Sân bóng Lai Xá", 1, 500000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), null },
                    { 3, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6396), "Advanced Pitch", true, "Sân bóng Nguyên Xá", 4, 900000.0, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), null },
                    { 4, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6398), "Advanced Pitch", false, "Sân bóng Mai Dịch", 3, 750000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 5, 0, 0, 0), null },
                    { 5, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6400), "Advanced Pitch", false, "Sân bóng Minh Khai", 2, 700000.0, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), null }
========
                    { 1, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5925), "Standard Pitch", false, "Sân bóng Thành Đô", 2, 700000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), null },
                    { 2, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5927), "Normal Pitch", false, "Sân bóng Lai Xá", 1, 500000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), null },
                    { 3, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5928), "Advanced Pitch", true, "Sân bóng Nguyên Xá", 4, 900000.0, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0), null },
                    { 4, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5930), "Advanced Pitch", false, "Sân bóng Mai Dịch", 3, 750000.0, new TimeSpan(0, 23, 0, 0, 0), new TimeSpan(0, 5, 0, 0, 0), null },
                    { 5, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5931), "Advanced Pitch", false, "Sân bóng Minh Khai", 2, 700000.0, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), null }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AccountId", "BankId", "CreatedAt", "Deposit", "DiscountId", "Email", "EndAt", "FootballPitchId", "Name", "Note", "Phone", "StartAt", "Status", "Total", "UpdatedAt" },
                values: new object[,]
                {
<<<<<<<< HEAD:OrderFootballPitch/Migrations/20240809052631_Init1.cs
                    { 1, 2, 1, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6459), 100000.0, null, "dmh@gamil.com", new DateTime(2024, 8, 8, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6456), 1, "Order_1", null, "1234567890", new DateTime(2024, 8, 8, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6452), 3, 1000000.0, null },
                    { 2, 3, null, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6462), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 10, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6461), 2, "Order_2", null, "0987654321", new DateTime(2024, 8, 10, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6460), 0, 700000.0, null },
                    { 3, 1, null, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6465), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 11, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6464), 2, "Order_3", null, "0987654321", new DateTime(2024, 8, 11, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6463), 2, 700000.0, null },
                    { 4, 3, null, new DateTime(2024, 8, 9, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6468), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 11, 14, 26, 31, 276, DateTimeKind.Local).AddTicks(6467), 2, "Order_4", null, "0987654321", new DateTime(2024, 8, 12, 12, 26, 31, 276, DateTimeKind.Local).AddTicks(6466), 1, 700000.0, null }
========
                    { 1, 2, 1, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5991), 100000.0, null, "dmh@gamil.com", new DateTime(2024, 8, 12, 12, 18, 26, 928, DateTimeKind.Local).AddTicks(5988), 1, "Order_1", null, "1234567890", new DateTime(2024, 8, 12, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5984), 3, 1000000.0, null },
                    { 2, 3, null, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5999), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 14, 12, 18, 26, 928, DateTimeKind.Local).AddTicks(5998), 2, "Order_2", null, "0987654321", new DateTime(2024, 8, 14, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(5997), 0, 700000.0, null },
                    { 3, 1, null, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(6002), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 15, 12, 18, 26, 928, DateTimeKind.Local).AddTicks(6001), 2, "Order_3", null, "0987654321", new DateTime(2024, 8, 15, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(6000), 2, 700000.0, null },
                    { 4, 3, null, new DateTime(2024, 8, 13, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(6005), 150000.0, 2, "order2@example.com", new DateTime(2024, 8, 15, 12, 18, 26, 928, DateTimeKind.Local).AddTicks(6003), 2, "Order_4", null, "0987654321", new DateTime(2024, 8, 16, 10, 18, 26, 928, DateTimeKind.Local).AddTicks(6003), 1, 700000.0, null }
>>>>>>>> f2463b8 (update4):OrderFootballPitch/Migrations/20240813031827_Tbl.cs
                });

            migrationBuilder.InsertData(
                table: "PitchImages",
                columns: new[] { "Id", "FootballPitchId", "Image" },
                values: new object[,]
                {
                    { 1, 1, "Resources\\PitchImages\\p1.jpg" },
                    { 2, 1, "Resources\\PitchImages\\p2.jpg" },
                    { 3, 1, "Resources\\PitchImages\\p3.jpg" },
                    { 4, 1, "Resources\\PitchImages\\p4.jpg" },
                    { 5, 2, "Resources\\PitchImages\\p5.jpg" },
                    { 6, 2, "Resources\\PitchImages\\p6.jpg" },
                    { 7, 2, "Resources\\PitchImages\\p7.jpg" },
                    { 8, 2, "Resources\\PitchImages\\p8.jpg" },
                    { 9, 2, "Resources\\PitchImages\\p9.jpg" },
                    { 10, 3, "Resources\\PitchImages\\p10.jpg" },
                    { 11, 3, "Resources\\PitchImages\\p11.jpg" },
                    { 12, 4, "Resources\\PitchImages\\p12.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPitches_PitchTypeId",
                table: "FootballPitches",
                column: "PitchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BankId",
                table: "Orders",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FootballPitchId",
                table: "Orders",
                column: "FootballPitchId");

            migrationBuilder.CreateIndex(
                name: "IX_PitchImages_FootballPitchId",
                table: "PitchImages",
                column: "FootballPitchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PitchImages");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "FootballPitches");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "PitchTypes");
        }
    }
}
