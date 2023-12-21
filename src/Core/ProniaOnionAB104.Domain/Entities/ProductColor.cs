namespace ProniaOnionAB104.Domain.Entities
{
    public class ProductColor : BaseEntity
    {
        //Relational Properties
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
