using CentricaShops.Models;
using CentricaShops.ViewModels;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CentricaShops.Command
{
    public class AddCommand : CommandBase
    {

        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;

        public AddCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory )
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;

            _showDistrictViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShowDistrictViewModel.CanAddSalPerson))
            {
                OnCanExecutedChanged();
            }
        }


        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_showDistrictViewModel.SalepersonToAdd)
                && !string.IsNullOrEmpty(_showDistrictViewModel.SelectedDistrictTest)
                && _showDistrictViewModel.IsPrimary == false && base.CanExecute(parameter);
        }

        public async override void Execute(object? parameter)
        {
            var person = new DistrictAndSalePerson { name = _showDistrictViewModel.SalepersonToAdd, districtname = _showDistrictViewModel.SelectedDistrictTest };

            var httpClient = _httpClientFactory.CreateClient("CentricaAPI");
            var todoItemJson = new StringContent(JsonSerializer.Serialize(person),
            Encoding.UTF8,
            "application/json");

            var httpResponse = await httpClient.PostAsync($"/api/SalePerson/SalePerson/{_showDistrictViewModel.SelectedDistrictTest}/{_showDistrictViewModel.SalepersonToAdd}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                _showDistrictViewModel.InsertPerson_Secondary("The secondary saleperson has been added");
            }
            else
            {
                _showDistrictViewModel.UserMessage = $"Connection to {httpResponse.Headers} host failed" + httpResponse.StatusCode.ToString();
            }
        }
    }
}
