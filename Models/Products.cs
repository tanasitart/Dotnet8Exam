namespace backapi.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Product_name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock_remain { get; set; }
        public DateTime Modified_Date { get; set; }
        public string? Remark { get; set; }
    }
}
