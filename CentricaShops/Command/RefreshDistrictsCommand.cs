using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentricaShops.Command
{
    public class RefreshDistrictsCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly GeneralDistrict _generalDistrict;
        private readonly IHttpClientFactory _httpClientFactory;
        string localHost = "https://localhost:7235/api/SalePerson/GetAll";

        public RefreshDistrictsCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory, GeneralDistrict generalDistrict)
        {
            _showDistrictViewModel=showDistrictViewModel;
            _httpClientFactory=clientFactory;
            _generalDistrict = generalDistrict;
        }

        public async override void Execute(object? parameter)
        {
            IEnumerable<string> result;
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(localHost);


            var person = new DistrictAndSalePerson { name = _showDistrictViewModel.SalepersonToAdd, districtname = _showDistrictViewModel.SelectedDistrictTest };

            var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse =
                await httpClient.GetAsync(localHost );


            if (response.IsSuccessStatusCode)
            {
                var tst = response.Content.ReadFromJsonAsync<IEnumerable<string>>().Result.ToArray();
                _showDistrictViewModel.RefreshDistricts(tst);

            }
            else
            {
                throw new ConnectionException("Connection to" + localHost + " host failed", response.StatusCode.ToString());
            }
        }
    }
}
