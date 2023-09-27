using Course.Services.Basket.API.Dtos;
using Course.Share.Dtos;
using System.Threading.Tasks;

namespace Course.Services.Basket.API.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> DeleteBasket(string userId);
    }
}
