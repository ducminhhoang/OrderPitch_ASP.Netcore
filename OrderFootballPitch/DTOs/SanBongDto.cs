public class SanBongDto
{
    public int Id { get; set; }
    public string TenSan { get; set; }
    public string DiaChi { get; set; }
    public string LoaiSan { get; set; }  // Assuming LoaiSan is a string, if it's an object, use LoaiSanDto instead
    public decimal Gia { get; set; }
}
