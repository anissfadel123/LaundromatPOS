using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Api
{
    public interface IWdfEndpoint
    {
        Task<IEnumerable<WDFModel>> GetAll();
        Task IncrementStatus(int id);
        Task DecrementStatus(int id);
    }
}
