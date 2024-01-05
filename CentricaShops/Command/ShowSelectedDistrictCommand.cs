using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace CentricaShops.Command
{
    public class ShowSelectedDistrictCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GeneralDistrict _generalDistrict;
        string localHost = "https://localhost:7235/api/SalePerson/GetDetailsByDistrict";

        public ShowSelectedDistrictCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory, GeneralDistrict generalDistrict)
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;
            _generalDistrict = generalDistrict;
        }
        public async override void Execute(object? parameter)
        {
            IEnumerable<string> result;
            var httpClient = _httpClientFactory.CreateClient();
            using var httpResponse =
                await httpClient.GetAsync($"{localHost}/{_showDistrictViewModel.SelectedDistrictTest}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var tst = httpResponse.Content.ReadFromJsonAsync<IEnumerable<StoreSalePerson>>().Result.ToArray();
                _showDistrictViewModel.GetDetails(tst);

            }
            else
            {
                throw new ConnectionException("Connection to" + localHost + " host failed", httpResponse.StatusCode.ToString());
            }
        }
    }
}
