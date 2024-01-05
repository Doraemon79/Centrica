using CentricaShops.Models;
using System.Net.Http;

namespace CentricaShops.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISalePersonProcessor _personProcessor;
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(IHttpClientFactory httpClientFactory, GeneralDistrict generalDistrict)
        {
            CurrentViewModel = new ShowDistrictViewModel( generalDistrict, httpClientFactory);

        }

    }
}
