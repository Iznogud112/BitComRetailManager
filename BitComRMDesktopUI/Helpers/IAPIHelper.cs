using System.Threading.Tasks;
using BitComRMDesktopUI.Models;

namespace BitComRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}