namespace DaneshkarShop.Domain.DTOs.AdminSide.Product;

public class CreateProductCategoryDto
{
    public string CategoryTitle { get; set; }

    public int? ParentId { get; set; }
}

