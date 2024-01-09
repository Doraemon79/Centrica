using CentricaShops.Command;
using CentricaShops.Exceptions;
using CentricaShops.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Net.Http;
using System.Windows.Input;

namespace CentricaShops.ViewModels
{
    public class ShowDistrictViewModel : ViewModelBase
    {
        private readonly ObservableCollection<string> _districts;
        public IEnumerable<string> Districts => _districts;
        private ObservableCollection<StoreSalePerson> _storeSalePersons;
        public IEnumerable<StoreSalePerson> StoreSalePersons => _storeSalePersons;

        
        private readonly IHttpClientFactory _httpClientFactory;

        private ObservableCollection<string> _stores;
        public IEnumerable<string> SalePersonAndRole;

        private string userMessage;

        public string UserMessage
        {
            get
            {
                return userMessage;
            }
            set
            {
                userMessage = value;
                this.OnPropertyChanged(nameof(UserMessage));

            }

        }

        private string salePersonToAdd;
        public string SalepersonToAdd
        {
            get
            {
                return salePersonToAdd;
            }
            set
            {
                salePersonToAdd = value; 

                OnPropertyChanged(nameof(CanAddSalPerson));
                OnPropertyChanged(nameof(CanUpdateSalePerson));
            }
        }

        public bool isPrimary;

        public bool IsPrimary
        {
            get
            {
                return isPrimary;
            }
            set
            {
                isPrimary = value;
                this.OnPropertyChanged("SelectedDistrictTest");
                OnPropertyChanged(nameof(CanAddSalPerson));
                OnPropertyChanged(nameof(CanUpdateSalePerson));
            }
        }

        private string selectedDistrictTest;

        public string SelectedDistrictTest
        {
            get
            {
                return selectedDistrictTest;
            }
            set
            {
                selectedDistrictTest = value;
                this.OnPropertyChanged("SelectedDistrictTest");
                OnPropertyChanged(nameof(CanAddSalPerson));
                OnPropertyChanged(nameof(CanUpdateSalePerson));
            }

        }

        public bool CanUpdateSalePerson =>
    IsPrimary &&
    !string.IsNullOrEmpty(SelectedDistrictTest) &&
    !string.IsNullOrEmpty(SalepersonToAdd);

        public bool CanAddSalPerson =>
    !IsPrimary &&
    !string.IsNullOrEmpty(SelectedDistrictTest) &&
        !string.IsNullOrEmpty(SalepersonToAdd);

        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public ICommand UpdateCommand { get; }
        public ICommand GetDetailsCommand { get; }
        public ICommand DeleteCommand { get; }

        public ShowDistrictViewModel(GeneralDistrict generalDistrict, IHttpClientFactory clientFactory)
        {
            _districts = new ObservableCollection<string>();
            _storeSalePersons = new ObservableCollection<StoreSalePerson>();
            _stores = new ObservableCollection<string>();

            _districts.Add("Test3");
            _districts.Add("Test4");

            RefreshCommand = new RefreshDistrictsCommand(this, clientFactory, generalDistrict);
            RemoveCommand = new DeleteCommand(this, clientFactory, generalDistrict);
            AddCommand = new AddCommand(this, clientFactory, generalDistrict);
            UpdateCommand = new UpdateSalePersonCommand(this, clientFactory, generalDistrict);
            GetDetailsCommand = new ShowSelectedDistrictCommand(this, clientFactory, generalDistrict);
            DeleteCommand = new DeleteCommand(this, clientFactory, generalDistrict);

        }



        public ObservableCollection<string> Stores
        {
            get { return _stores; }
            set { _stores = value; }
        }

        public void InsertPerson_Secondary(string response)
        {
            if (response != null)
                UserMessage = "Success" + response;
        }

        public void InsertPerson_Primary(string response)
        {
            if (response != null)
                UserMessage = "Success" + response;
        }

        public void DeleteSalePersom(string response)
        {
            if (response != null)
                UserMessage = "Success" + response;
        }

        public IEnumerable<StoreSalePerson> GetDetails(IEnumerable<StoreSalePerson> storeSalePerson)
        {
            _storeSalePersons.Clear();
            foreach (var el in storeSalePerson)
            {
                _storeSalePersons.Add(el);
            }
            return _storeSalePersons;
        }

        public IEnumerable<string> RefreshDistricts(IEnumerable<string> districts)
        {
           _districts.Clear();
            foreach(var el in  districts)
            {
                _districts.Add(el);
            }
            return _districts;
        }

    }
}
