using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    public class ProductCategoryController : AdminBaseController
    {

        #region Ctor

        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        #endregion

        #region List Of Categories

        public async Task<IActionResult> ListOfProductCategories(CancellationToken cancellation = default)
        {
            return View(await _productCategoryService.ListOfProductCategories(cancellation));
        }

        #endregion

        #region Create Category

        public IActionResult CreateProductCategory(int? parentId)
        {
            return View(new CreateProductCategoryDto()
            {
                ParentId = parentId
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductCategory(CreateProductCategoryDto model,
                                                               CancellationToken cancellation = default)
        {
            if (ModelState.IsValid)
            {
                var res = await _productCategoryService.AddProductCategory(model, cancellation);
                if (res)
                {
                    return RedirectToAction(nameof(ListOfProductCategories));
                }
            }
            return View(model);
        }

        #endregion

        #region Delete Category

        public async Task<IActionResult> DeleteCategory(int categoryId, CancellationToken cancellation = default)
        {
            return View();
        }

        #endregion
    }
}
