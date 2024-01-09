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

        public RefreshDistrictsCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory, GeneralDistrict generalDistrict)
        {
            _showDistrictViewModel=showDistrictViewModel;
            _httpClientFactory=clientFactory;
            _generalDistrict = generalDistrict;
        }

        public async override void Execute(object? parameter)
        {
            var httpClient = _httpClientFactory.CreateClient("CentricaAPI");
            var httpResponse = await httpClient.GetAsync("api/Saleperson/Districts");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = httpResponse.Content.ReadFromJsonAsync<IEnumerable<string>>().Result;
                _showDistrictViewModel.RefreshDistricts(response.ToArray());
            }
            else
            {
                throw new ConnectionException("Connection to CetricaAPI host failed", httpResponse.StatusCode.ToString());
            }
        }
    }
}
