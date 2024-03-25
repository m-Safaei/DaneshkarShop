namespace DaneshkarShop.Domain.Entities.Product;

public class ProductCategory
{
    public int Id { get; set; }

    public string CategoryTitle { get; set; }

    public int? ParentId { get; set; }
}

