using System.Threading.Tasks;
using BitComDesktopUI.Library.Models;

namespace BitComDesktopUI.Library.API
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}