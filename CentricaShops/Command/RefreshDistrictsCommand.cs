using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace CentricaShops.Command
{
    public class RefreshDistrictsCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;

        public RefreshDistrictsCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory)
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;
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
