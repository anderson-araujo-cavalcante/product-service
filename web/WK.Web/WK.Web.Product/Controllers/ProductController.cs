using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WK.Web.Product.Client.Interfaces;
using WK.Web.Product.Models;

namespace WK.Web.Product.Controllers
{    
    public class ProductController : BaseController
    {
        public ProductController(IProductClient productClient) : base(productClient)
        {
        }

        public async Task<ActionResult> Index()
        {
            var result = await _productClient.GetAllProductsAsync();
            return View(result.OrderBy(_ => _.CreatedAt));
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _productClient.GetProductByIdAsync(id);
            return View(result);
        }

       public async Task<ActionResult> Create()
        {
            var categories = await _productClient.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(_ => new SelectListItem() { Text = _.Name, Value = _.Id.ToString() });
            return View(new Models.Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Product product)
        {
            try
            {
                await _productClient.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            await CreateViewBagCategoriesAsync();
            var result = await _productClient.GetProductByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Product product)
        {
            try
            {
                await _productClient.EditProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
                
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productClient.GetProductByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _productClient.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task CreateViewBagCategoriesAsync()
        {
            var categories = await _productClient.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(_ => new SelectListItem() { Text = _.Name, Value = _.Id.ToString() });
        }
    }
}
