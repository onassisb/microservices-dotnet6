using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token);
        Task<CartViewModel> AddItemToCart(CartViewModel cart, string token);
        Task<CartViewModel> UpdateCart(CartViewModel cart, string token);
        Task<bool> DeleteFromCart(long id, string token);
        Task<bool> ApplyCoupo (CartViewModel cart, string coupoCode, string token);
        Task<bool> DeleteCoupo (string userId, string token);
        Task<bool> ClearCart (string userId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);

    }
}
