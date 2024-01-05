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
        private ObservableCollection<StoreSalePerson> _storeSalePersons;

        public IEnumerable<string> Districts => _districts;
        public IEnumerable<StoreSalePerson> StoreSalePersons => _storeSalePersons;

        private readonly IHttpClientFactory _httpClientFactory;


        ObservableCollection<StoreAndDistrict> _storesAndDistricts;

               

        private ObservableCollection<string> _stores;
        //public IEnumerable<string> Districts => GetDistricts();
        public IEnumerable<string> SalePersonAndRole;
        public string Districtname { get; }
        public string Saleperson { get; }


        public string Store { get; }

        public string DistrictToShow { get; set; }

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
            _storesAndDistricts = new ObservableCollection<StoreAndDistrict>();

            _districts.Add("Test3");
            _districts.Add("Test4");

            RefreshCommand = new RefreshDistrictsCommand(this, clientFactory, generalDistrict);
            RemoveCommand = new DeleteCommand(this, clientFactory, generalDistrict);
            AddCommand = new AddCommand(this, clientFactory, generalDistrict);
            UpdateCommand = new UpdateSalePersonCommand(this, clientFactory, generalDistrict);
            GetDetailsCommand = new ShowSelectedDistrictCommand(this, clientFactory, generalDistrict);
            DeleteCommand = new DeleteCommand(this, clientFactory, generalDistrict);

            //Test
            //_districts.Add(new DistrictAndSalePerson("District1", "Mr1", true));
            //_districts.Add(new DistrictAndSalePerson("District2", "Mr2", true));
            //_districts.Add(new DistrictAndSalePerson("District3", "Mr3", true));
            //_districts.Add(new DistrictAndSalePerson("District2", "Mr4", false));


            //Test2
            //_storesAndDistricts.Add(new StoreAndDistrict("Store1", "District1"));
            //_storesAndDistricts.Add(new StoreAndDistrict("Store2", "District2"));
            //_storesAndDistricts.Add(new StoreAndDistrict("Store3", "District3"));
            //_storesAndDistricts.Add(new StoreAndDistrict("Store4", "District2"));

        }

        private string _selectedDistrict;
        //public string SelectedDistrict
        //{
        //    get { return _selectedDistrict; }
        //    set
        //    {

        //        _selectedDistrict = value;
        //        GetSalePersons(_selectedDistrict);

        //    }
        //}


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

        //public void GetSalePersons(string district)
        //{
        //    SelectedDistrictTest = district;
        //    var salePersonsAndRole = _districts.Where(x => x.District.Equals(district)).Select(x => x.salepersonAndRole);
        //    SalePersons.Clear();
        //    foreach (var el in salePersonsAndRole)
        //    { SalePersons.Add(el); }


        //    var stores = _storesAndDistricts.Where(x => x.District.Equals(district)).Select(x => x.Store);
        //    Stores.Clear();
        //    foreach (var el in stores)
        //    { Stores.Add(el); }
        //}

        //public void ProcessSalePerson(string district, SalepersonAndRole salePerson)
        //{
        //    //If new person is Primary
        //    //replace old primary with new saleperson
        //    if (salePerson.IsPrimary)
        //    {
        //        ReplaceSalePerson(district, salePerson);
        //    }

        //    //if new person is secondary
        //    else if (!salePerson.IsPrimary)
        //    {
        //        var oldSalePersonsAndRole = _districts.Where(x => x.District.Equals(district)).Select(x => x.salepersonAndRole);
        //        //if new person is already present
        //        if (oldSalePersonsAndRole != null)
        //        {
        //            //if present is primary 
        //            if (oldSalePersonsAndRole.First().IsPrimary)
        //            {
        //                //exception need to replace the primary first
        //                throw new SalePersonException("Need to replace Primary first", salePerson);

        //            }
        //            //If present is secondary 
        //            //exception salePerson present already
        //            else
        //            {
        //                throw new SalePersonException("Saleperson is present already", salePerson);
        //            }

        //        }
        //        else
        //        {
        //            _salePersonProcessor.AddSalePerson(district, salePerson, _districts);
        //        }

        //    }



            //If present is secondary 
            //exception salePerson present already

            //if new person is not present
            //Add new person

        //}

        //public void AddSalePerson(string district, SalepersonAndRole salePerson, ObservableCollection<DistrictAndSalePerson> districts)
        //{
        //    var districtAndSalePerson = new DistrictAndSalePerson(district, salePerson.SalePerson, salePerson.IsPrimary);
        //    _districts.Add(districtAndSalePerson);
        //}
        //public void ReplaceSalePerson(string district, SalepersonAndRole newSalePerson)
        //{
        //    int index = -1;
        //    for (int i = 0; i < _districts.Count; i++)
        //    {
        //        if (_districts[i].District == district && _districts[i].salepersonAndRole.SalePerson == newSalePerson.SalePerson)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    if (index > -1)
        //    {
        //        _districts[index].salepersonAndRole = newSalePerson;

        //    }

        //}
        //public void RemoveSalePerson(string district, SalepersonAndRole salePerson)
        //{
        //    int index = -1;
        //    for (int i = 0; i < _districts.Count; i++)
        //    {
        //        if (_districts[i].District == district && _districts[i].salepersonAndRole.IsPrimary)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    _districts.RemoveAt(index);
        //}
    }
}
