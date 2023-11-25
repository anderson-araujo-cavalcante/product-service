using Microsoft.AspNetCore.Mvc;
using WK.Web.Product.Client.Interfaces;

namespace WK.Web.Product.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IProductClient _productClient;

        public BaseController(IProductClient productClient)
        {
            _productClient = productClient;
        }
    }
}
