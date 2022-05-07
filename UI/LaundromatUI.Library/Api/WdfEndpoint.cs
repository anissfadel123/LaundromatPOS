using LaundroDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaundroDesktopUI.Library.Api
{
    public class WdfEndpoint : IWdfEndpoint
    {
        private IAPIHelper _apiHelper;
        public WdfEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IEnumerable<WDFModel>> GetAll()
        {
            using (HttpResponseMessage result = await _apiHelper.ApiClient.GetAsync("/api/Wdf"))
            {
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<List<WDFModel>>();
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }

        public async Task IncrementStatus(int id)
        {
            using (HttpResponseMessage result = await _apiHelper.ApiClient.PutAsJsonAsync($"/api/Wdf/IncrementStatus", id))
            {
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }

        public async Task DecrementStatus(int id)
        {
            using (HttpResponseMessage result = await _apiHelper.ApiClient.PutAsJsonAsync($"/api/Wdf/DecrementStatus", id))
            {
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }
    }
}
