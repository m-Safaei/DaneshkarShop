using DaneshkarShop.Domain.Entities.Product;

namespace DaneshkarShop.Domain.IRepositories;

public interface IProductCategoryRepository
{
    #region Admin Side

    Task<List<ProductCategory>> ListOfProductCategories(CancellationToken cancellationToken);
    Task AddProductCategory(ProductCategory category, CancellationToken cancellation);
    Task SaveChanges(CancellationToken cancellation);
    Task<ProductCategory?> GetProductCategoryById(int categoryId, CancellationToken cancellation);
    void DeleteCategory(ProductCategory category);

    Task<List<ProductCategory>> GetChildrenByParentCategoryId(int categoryId, CancellationToken cancellation);

    #endregion
}

