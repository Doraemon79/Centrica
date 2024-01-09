using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CentricaShops.Command
{
    public class DeleteCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GeneralDistrict _generalDistrict;
        string localHost = "https://localhost:7235/api/SalePerson/DeleteSalePerson";

        public DeleteCommand(ShowDistrictViewModel showDistrictViewModel,IHttpClientFactory clientFactory, GeneralDistrict generalDistrict)
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;
            _generalDistrict = generalDistrict;
        }

        public async override void Execute(object? parameter)
        {
            var person = new DistrictAndSalePerson { name = _showDistrictViewModel.SalepersonToAdd, districtname = _showDistrictViewModel.SelectedDistrictTest };

            var httpClient = _httpClientFactory.CreateClient("CentricaAPI");

            using var httpResponse = await httpClient.DeleteAsync($"api/Remove/{person.districtname}/{person.name}");

            var result = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                _showDistrictViewModel.DeleteSalePersom("The person has been deleted from the DB");

            }
            else
            {
                throw new ConnectionException($"Connection to {httpResponse.Headers}  host failed", httpResponse.StatusCode.ToString());
            }
        }
    }
}
