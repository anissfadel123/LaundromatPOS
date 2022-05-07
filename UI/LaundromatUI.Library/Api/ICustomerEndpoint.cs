using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Api
{
    public interface ICustomerEndpoint
    {
        Task Post(CustomerModel customer);
        Task GetAll();
        Task<CustomerModel> Get(int id);
        //Task<IEnumerable<CustomerSearchModel>> GetCustomerContain(string str);
        Task<IEnumerable<CustomerModel>> FilterCustomer(string id, string name);


    }
}
