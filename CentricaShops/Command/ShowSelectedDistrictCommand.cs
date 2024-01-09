using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace CentricaShops.Command
{
    public class ShowSelectedDistrictCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GeneralDistrict _generalDistrict;

        public ShowSelectedDistrictCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory, GeneralDistrict generalDistrict)
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;
            _generalDistrict = generalDistrict;
        }
        public async override void Execute(object? parameter)
        {
            var httpClient = _httpClientFactory.CreateClient("CentricaAPI");

            var httpResponse = await httpClient.GetAsync($"api/Saleperson/Districts/{_showDistrictViewModel.SelectedDistrictTest}");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = httpResponse.Content.ReadFromJsonAsync<IEnumerable<StoreSalePerson>>().Result.ToArray();
                _showDistrictViewModel.GetDetails(response);

            }
            else
            {
                throw new ConnectionException("Connection to {httpResponse.Headers}  host failed", httpResponse.StatusCode.ToString());
            }
        }
    }
}
