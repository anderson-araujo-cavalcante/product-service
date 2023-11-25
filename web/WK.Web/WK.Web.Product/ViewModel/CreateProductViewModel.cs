using WK.Web.Product.Models;

namespace WK.Web.Product.ViewModel
{
    public class CreateProductViewModel
    {
        public Models.Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
