namespace OrderFootballPitch.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BankId { get; set; }
        public double Deposit { get; set; }
        public int? DiscountId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public double Total { get; set; }
    }

}
