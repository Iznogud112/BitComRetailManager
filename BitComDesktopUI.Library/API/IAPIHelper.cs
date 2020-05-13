using BitComDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BitComDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}