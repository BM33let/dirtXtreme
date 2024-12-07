namespace BOROMOTORS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int DirtBikeId { get; set; }
        public DirtBike DirtBike { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
