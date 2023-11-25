using System.Text;
using System.Text.Json;
using WK.Web.Product.Client.Interfaces;

namespace WK.Web.Product.Client
{
    public class ProductClient : IProductClient
    {
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        public ProductClient(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        #region Product

        public async Task AddProductAsync(Models.Product product)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = "/api/product";

            var request = new { product.Name, product.CategoryId };
            var bodyJson = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            using var httpResponseMessage = await client.PostAsync(apiUrl, stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task EditProductAsync(Models.Product product)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/product/{product.Id}";

            var request = new { product.Id, product.Name, product.CategoryId };
            var bodyJson = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            using var httpResponseMessage = await client.PutAsync(apiUrl, stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/product/{id}";

            using var httpResponseMessage = await client.DeleteAsync(apiUrl);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Models.Product>> GetAllProductsAsync()
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = "/api/product/all";
            var response = await client.GetAsync(apiUrl);

            var products = Enumerable.Empty<Models.Product>();
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                products = await JsonSerializer.DeserializeAsync<IEnumerable<Models.Product>>(apiResponse, _options);
            }
            return products;
        }

        public async Task<Models.Product> GetProductByIdAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/product/{id}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Models.Product>(apiResponse, _options);
            }
            return null;
        }
        #endregion

        #region Category
        public async Task<IEnumerable<Models.Category>> GetAllCategoriesAsync()
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = "/api/category/all";
            var response = await client.GetAsync(apiUrl);

            var categories = Enumerable.Empty<Models.Category>();
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                categories = await JsonSerializer.DeserializeAsync<IEnumerable<Models.Category>>(apiResponse, _options);
            }
            return categories;
        }

        public async Task AddCategoryAsync(Models.Category category)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = "/api/category";

            var bodyJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            using var httpResponseMessage = await client.PostAsync(apiUrl, stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task EditCategoryAsync(Models.Category category)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/category/{category.Id}";

            var bodyJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            using var httpResponseMessage = await client.PutAsync(apiUrl, stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/category/{id}";

            using var httpResponseMessage = await client.DeleteAsync(apiUrl);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<Models.Category> GetCategoryByIdAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductClient");
            string apiUrl = $"/api/category/{id}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Models.Category>(apiResponse, _options);
            }
            return null;
        }
        #endregion

    }
}
