using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task Post(ProductModel product);
    }
}
