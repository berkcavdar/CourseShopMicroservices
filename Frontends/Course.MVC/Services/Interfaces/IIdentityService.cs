using Course.MVC.ViewModels;
using Course.Share.Dtos;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace Course.MVC.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInViewModel signInViewModel);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
