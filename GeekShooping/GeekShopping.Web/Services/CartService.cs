using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.PostAsJson($"{BasePath}/add-cart/", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de salvar os dados.");
        }

        public async Task<bool> ApplyCoupo(CartViewModel cart, string coupoCode, string token)
        {
            InserirTokenHeader(token);
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            InserirTokenHeader(token);
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCoupo(string userId, string token)
        {
            InserirTokenHeader(token);
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFromCart(long id, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.DeleteAsync($"{BasePath}/delete-cart/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de excluir os dados.");
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
        {
            InserirTokenHeader(token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart/", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Erro ao fazer a chamada na API, no momento de salvar os dados.");
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            InserirTokenHeader(token);
            throw new NotImplementedException();
        }

        private void InserirTokenHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
