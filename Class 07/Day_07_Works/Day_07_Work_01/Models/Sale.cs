namespace Day_07_Work_01.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
