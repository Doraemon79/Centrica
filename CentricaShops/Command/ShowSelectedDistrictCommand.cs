﻿using CentricaShops.Exceptions;
using CentricaShops.Models;
using CentricaShops.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace CentricaShops.Command
{
    public class ShowSelectedDistrictCommand : CommandBase
    {
        private readonly ShowDistrictViewModel _showDistrictViewModel;
        private readonly IHttpClientFactory _httpClientFactory;

        public ShowSelectedDistrictCommand(ShowDistrictViewModel showDistrictViewModel, IHttpClientFactory clientFactory)
        {
            _showDistrictViewModel = showDistrictViewModel;
            _httpClientFactory = clientFactory;
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
