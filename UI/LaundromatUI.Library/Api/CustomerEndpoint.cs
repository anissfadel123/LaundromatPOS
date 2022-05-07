using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Api
{
    public class CustomerEndpoint : ICustomerEndpoint
    {
        private IAPIHelper _apiHelper;

        public CustomerEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IEnumerable<CustomerModel>> FilterCustomer(string id, string name)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Customers/Filter?id={ id }&name={ name }"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<CustomerModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<CustomerModel> Get(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Customers/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<CustomerModel>();

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<CustomerSearchModel>>  GetCustomerContain(string str)
        //{
        //    using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/Customers/contains/{str}"))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadAsAsync<IEnumerable<CustomerSearchModel>>();

        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}

        public async Task Post(CustomerModel customer)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync<CustomerModel>("/api/Customers", customer))
            {
                response.EnsureSuccessStatusCode();

            }
        }
    }
}
