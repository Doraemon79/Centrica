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

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(localHost);
            var todoItemJson = new StringContent(JsonSerializer.Serialize(person),
            Encoding.UTF8,
            "application/json");
                using var httpResponse =
      await httpClient.DeleteAsync($"{localHost}/{person.districtname}/{person.name}");

            var result = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                _showDistrictViewModel.DeleteSalePersom("The person has been deleted from the DB");

            }
            else
            {
                throw new ConnectionException("Connection to" + localHost + " host failed", httpResponse.StatusCode.ToString());
            }
        }
    }
}
