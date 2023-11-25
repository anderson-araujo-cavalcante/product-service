using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WK.Web.Product.Client.Interfaces;
using WK.Web.Product.Models;

namespace WK.Web.Product.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IProductClient productClient) : base(productClient)
        {
        }

        public async Task<ActionResult> Index()
        {
            var result = await _productClient.GetAllCategoriesAsync();
            return View(result.OrderBy(_ => _.CreatedAt));
        }

        public async Task<ActionResult> Create()
        {            
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Category category)
        {
            try
            {
                await _productClient.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _productClient.GetCategoryByIdAsync(id);
            return View(result);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var result = await _productClient.GetCategoryByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Category category)
        {
            try
            {
                await _productClient.EditCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productClient.GetCategoryByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _productClient.DeleteCategoryAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
