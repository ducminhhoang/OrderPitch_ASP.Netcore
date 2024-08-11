using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Data
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Seed data for AccountType
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { Id = 1, Name = "Admin", CreatedAt = DateTime.Now },
                new AccountType { Id = 2, Name = "User", CreatedAt = DateTime.Now },
                new AccountType { Id = 3, Name = "Guest", CreatedAt = DateTime.Now }
            );

            // Seed data for PitchType
            modelBuilder.Entity<PitchType>().HasData(
                new PitchType { Id = 1, Quantity = 5, Description = "5v5", CreatedAt = DateTime.Now },
                new PitchType { Id = 2, Quantity = 7, Description = "7v7", CreatedAt = DateTime.Now },
                new PitchType { Id = 3, Quantity = 9, Description = "9v9", CreatedAt = DateTime.Now },
                new PitchType { Id = 4, Quantity = 11, Description = "11v11", CreatedAt = DateTime.Now }
            );

            // Seed data for Bank
            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "Vietcombank", BankNumber = "123456789", Image = "Resources\\Banks\\vcb.jpg", CreatedAt = DateTime.Now },
                new Bank { Id = 2, Name = "Mbbank", BankNumber = "987654321", Image = "Resources\\Banks\\mbbank.jpg", CreatedAt = DateTime.Now }
            );

            // Seed data for Discount
            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = 1, Code = "Group5MaiDinh", Amount = 10, UsageLimit = 1000000, EndDate = DateTime.Now.AddMonths(1), CreatedAt = DateTime.Now },
                new Discount { Id = 2, Code = "Deptraicogisai", Amount = 20, UsageLimit = 500000, EndDate = DateTime.Now.AddMonths(2), CreatedAt = DateTime.Now }
            );

            // Seed data for FootballPitch
            modelBuilder.Entity<FootballPitch>().HasData(
                new FootballPitch
                {
                    Id = 1,
                    Name = "Sân bóng Thành Đô",
                    TimeStart = new TimeSpan(6, 0, 0),
                    TimeEnd = new TimeSpan(23, 0, 0),
                    Description = "Standard Pitch",
                    PricePerHour = 700000,
                    IsMaintenance = false,
                    PitchTypeId = 2,
                    CreatedAt = DateTime.Now
                },
                new FootballPitch
                {
                    Id = 2,
                    Name = "Sân bóng Lai Xá",
                    TimeStart = new TimeSpan(7, 0, 0),
                    TimeEnd = new TimeSpan(23, 0, 0),
                    Description = "Normal Pitch",
                    PricePerHour = 500000,
                    IsMaintenance = false,
                    PitchTypeId = 1,
                    CreatedAt = DateTime.Now
                },
                new FootballPitch
                {
                    Id = 3,
                    Name = "Sân bóng Nguyên Xá",
                    TimeStart = new TimeSpan(6, 0, 0),
                    TimeEnd = new TimeSpan(17, 0, 0),
                    Description = "Advanced Pitch",
                    PricePerHour = 900000,
                    IsMaintenance = true,
                    PitchTypeId = 4,
                    CreatedAt = DateTime.Now
                },
                new FootballPitch
                {
                    Id = 4,
                    Name = "Sân bóng Mai Dịch",
                    TimeStart = new TimeSpan(5, 0, 0),
                    TimeEnd = new TimeSpan(23, 0, 0),
                    Description = "Advanced Pitch",
                    PricePerHour = 750000,
                    IsMaintenance = false,
                    PitchTypeId = 3,
                    CreatedAt = DateTime.Now
                },
                new FootballPitch
                {
                    Id = 5,
                    Name = "Sân bóng Minh Khai",
                    TimeStart = new TimeSpan(8, 0, 0),
                    TimeEnd = new TimeSpan(17, 0, 0),
                    Description = "Advanced Pitch",
                    PricePerHour = 700000,
                    IsMaintenance = false,
                    PitchTypeId = 2,
                    CreatedAt = DateTime.Now
                }
            );

            // Seed data for Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Name = "Admin1",
                    Phone = "1234567890",
                    Email = "admin@gmail.com",
                    Password = "8ddcff3a80f4189ca1c9d4d902c3c909",
                    Address = "Admin Address",
                    AccountTypeId = 1,
                    CreatedAt = DateTime.Now
                },
                new Account
                {
                    Id = 2,
                    Name = "Duc Minh Hoang",
                    Phone = "0987654321",
                    Email = "dmh@example.com",
                    Password = "25d55ad283aa400af464c76d713c07ad",
                    Address = "Ha Noi",
                    AccountTypeId = 2,
                    CreatedAt = DateTime.Now
                },
                new Account
                {
                    Id = 3,
                    Name = "Vu Tung Quan",
                    Phone = "0987654322",
                    Email = "vtq@gamil.com",
                    Password = "25d55ad283aa400af464c76d713c07ad",
                    Address = "Ha Noi",
                    AccountTypeId = 2,
                    CreatedAt = DateTime.Now
                },
                new Account
                {
                    Id = 4,
                    Name = "Vu Minh Duc",
                    Phone = "0987654324",
                    Email = "vmd@gmail.com",
                    Password = "25d55ad283aa400af464c76d713c07ad",
                    Address = "Ha Noi",
                    AccountTypeId = 2,
                    CreatedAt = DateTime.Now
                },
                new Account
                {
                    Id = 5,
                    Name = "Nguyen Ai Dan",
                    Phone = "0987654325",
                    Email = "nad@gmail.com",
                    Password = "25d55ad283aa400af464c76d713c07ad",
                    Address = "Ha Noi",
                    AccountTypeId = 2,
                    CreatedAt = DateTime.Now
                }
            );

            // Seed data for PitchImage
            modelBuilder.Entity<PitchImage>().HasData(
                new PitchImage { Id = 1, FootballPitchId = 1, Image = "Resources\\PitchImages\\p1.jpg" },
                new PitchImage { Id = 2, FootballPitchId = 1, Image = "Resources\\PitchImages\\p2.jpg" },
                new PitchImage { Id = 3, FootballPitchId = 1, Image = "Resources\\PitchImages\\p3.jpg" },
                new PitchImage { Id = 4, FootballPitchId = 1, Image = "Resources\\PitchImages\\p4.jpg" },
                new PitchImage { Id = 5, FootballPitchId = 2, Image = "Resources\\PitchImages\\p5.jpg" },
                new PitchImage { Id = 6, FootballPitchId = 2, Image = "Resources\\PitchImages\\p6.jpg" },
                new PitchImage { Id = 7, FootballPitchId = 2, Image = "Resources\\PitchImages\\p7.jpg" },
                new PitchImage { Id = 8, FootballPitchId = 2, Image = "Resources\\PitchImages\\p8.jpg" },
                new PitchImage { Id = 9, FootballPitchId = 2, Image = "Resources\\PitchImages\\p9.jpg" },
                new PitchImage { Id = 10, FootballPitchId = 3, Image = "Resources\\PitchImages\\p10.jpg" },
                new PitchImage { Id = 11, FootballPitchId = 3, Image = "Resources\\PitchImages\\p11.jpg" },
                new PitchImage { Id = 12, FootballPitchId = 4, Image = "Resources\\PitchImages\\p12.jpg" }
            );

            // Seed data for Order
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Name = "Order_1",
                    Phone = "1234567890",
                    Email = "dmh@gamil.com",
                    Deposit = 100000,
                    StartAt = DateTime.Now.AddDays(-1),
                    EndAt = DateTime.Now.AddDays(-1).AddHours(2),
                    Total = 1000000,
                    Status = StatusOrder.Completed,
                    AccountId = 2,
                    FootballPitchId = 1,
                    BankId = 1,
                    CreatedAt = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Name = "Order_2",
                    Phone = "0987654321",
                    Email = "order2@example.com",
                    Deposit = 150000,
                    StartAt = DateTime.Now.AddDays(1),
                    EndAt = DateTime.Now.AddDays(1).AddHours(2),
                    Total = 700000,
                    Status = StatusOrder.Waiting,
                    AccountId = 3,
                    FootballPitchId = 2,
                    DiscountId = 2,
                    CreatedAt = DateTime.Now
                },
                new Order
                {
                    Id = 3,
                    Name = "Order_3",
                    Phone = "0987654321",
                    Email = "order2@example.com",
                    Deposit = 150000,
                    StartAt = DateTime.Now.AddDays(2),
                    EndAt = DateTime.Now.AddDays(2).AddHours(2),
                    Total = 700000,
                    Status = StatusOrder.Canceled,
                    AccountId = 1,
                    FootballPitchId = 2,
                    DiscountId = 2,
                    CreatedAt = DateTime.Now
                },
                new Order
                {
                    Id = 4,
                    Name = "Order_4",
                    Phone = "0987654321",
                    Email = "order2@example.com",
                    Deposit = 150000,
                    StartAt = DateTime.Now.AddDays(3),
                    EndAt = DateTime.Now.AddDays(2).AddHours(2),
                    Total = 700000,
                    Status = StatusOrder.Ordered,
                    AccountId = 3,
                    FootballPitchId = 2,
                    DiscountId = 2,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
