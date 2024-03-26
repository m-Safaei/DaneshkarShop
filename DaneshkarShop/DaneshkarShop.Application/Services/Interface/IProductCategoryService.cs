using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using DaneshkarShop.Domain.Entities.Product;

namespace DaneshkarShop.Application.Services.Interface;

public interface IProductCategoryService
{
    #region Admin Side

    Task<List<ProductCategory>> ListOfProductCategories(CancellationToken cancellationToken);

    Task<bool> AddProductCategory(CreateProductCategoryDto model, CancellationToken cancellation);

    #endregion
}

