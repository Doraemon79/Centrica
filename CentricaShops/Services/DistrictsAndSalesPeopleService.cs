using CentricaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Services
{
    public class DistrictsAndSalesPeopleService : IDistrictsAndSalesPeopleService
    {
        public async Task<IEnumerable<string>> GetAllDistricts()
        {
            IEnumerable<string> result = new List<string>();
            using(HttpClient client=new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7235/api/SalePerson/GetAll");
                if (response.IsSuccessStatusCode)
                {
                   result = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
                }
            }
            return result;
        }

        public Task<IEnumerable<SalepersonAndRole>> GetSalePeopleByDistrict(string district)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetStoreseByDistrict(string district)
        {
            throw new NotImplementedException();
        }
    }
}
