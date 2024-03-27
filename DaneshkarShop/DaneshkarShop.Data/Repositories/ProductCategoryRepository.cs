using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entities.Product;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{

    #region Ctor

    private readonly DaneshkarDbContext _context;

    public ProductCategoryRepository(DaneshkarDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Admin Side

    public async Task<List<ProductCategory>> ListOfProductCategories(CancellationToken cancellationToken)
    {
        return await _context.ProductCategories.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task AddProductCategory(ProductCategory category, CancellationToken cancellation)
    {
        await _context.ProductCategories.AddAsync(category, cancellation);
    }

    public async Task SaveChanges(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<ProductCategory?> GetProductCategoryById(int categoryId, CancellationToken cancellation)
    {
        return await _context.ProductCategories.FirstOrDefaultAsync(p => p.Id == categoryId, cancellation);
    }

    public void DeleteCategory(ProductCategory category)
    {
        _context.ProductCategories.Remove(category);
    }

    public async Task<List<ProductCategory>> GetChildrenByParentCategoryId(int categoryId,
                                                                           CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == categoryId)
                                               .ToListAsync(cancellation);
    }
    #endregion
}

