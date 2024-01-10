using CentricaShops.Models;
using System.Net.Http;

namespace CentricaShops.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(IHttpClientFactory httpClientFactory, GeneralDistrict generalDistrict)
        {
            CurrentViewModel = new ShowDistrictViewModel(generalDistrict, httpClientFactory);

        }

    }
}
