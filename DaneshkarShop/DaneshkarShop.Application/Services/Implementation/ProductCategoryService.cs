﻿using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using DaneshkarShop.Domain.Entities.Product;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation;

public class ProductCategoryService : IProductCategoryService
{

    #region Ctor
    
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    #endregion

    #region Admin Side

    public async Task<List<ProductCategory>> ListOfProductCategories(CancellationToken cancellationToken)
    {
        return await _productCategoryRepository.ListOfProductCategories(cancellationToken);
    }

    public async Task<bool> AddProductCategory(CreateProductCategoryDto model,CancellationToken cancellation)
    {
        //object Mapping
        ProductCategory productCategory = new()
        {
            CategoryTitle = model.CategoryTitle,
            ParentId = model.ParentId,
        };

        await _productCategoryRepository.AddProductCategory(productCategory,cancellation);
        await _productCategoryRepository.SaveChanges(cancellation);
        return true;
    }

    public async Task<ProductCategory?> GetProductCategoryById(int categoryId, CancellationToken cancellation)
    {
        return await _productCategoryRepository.GetProductCategoryById(categoryId, cancellation);
    }
    public async Task<bool> DeleteProductCategory(int categoryId, CancellationToken cancellation)
    {
        //Find Category by id
        var category = await _productCategoryRepository.GetProductCategoryById(categoryId, cancellation);
        if (category ==null) return false;
        
        //delete Child categories
        if (category.ParentId == null)
        {
            var children =await _productCategoryRepository.GetChildrenByParentCategoryId(categoryId, cancellation);
            if (children.Any())
            {
                foreach (var child in children)
                {
                    _productCategoryRepository.DeleteCategory(child);
                }
            }
        }

        //delete category
        _productCategoryRepository.DeleteCategory(category);

        //Save changes
        await _productCategoryRepository.SaveChanges(cancellation);

        return true;
    }
    #endregion
}

