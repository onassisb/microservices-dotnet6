using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            InserirTokenHeader(token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }
        public async Task<ProductViewModel> FindByIdProduct(long id, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }
        public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de salvar os dados.");
        }
        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) 
                return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de atualizar os dados.");
        }
        public async Task<bool> DeleteProduct(long id, string token)
        {
            InserirTokenHeader(token);

            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) 
                return await response.ReadContentAs<bool>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de excluir os dados.");
        }
        private void InserirTokenHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

    }
}
