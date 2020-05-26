using System.Collections.Generic;
using System.Threading.Tasks;
using BitComDesktopUI.Library.Models;

namespace BitComDesktopUI.Library.API
{
    public interface IProductEndpoint
    {
        //IAPIHelper apiHelper();

        Task<List<ProductModel>> GetAll();
    }
}