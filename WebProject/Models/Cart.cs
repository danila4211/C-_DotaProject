namespace WebProject.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }
    }
}
