using CentricaShops.Exceptions;
using CentricaShops.Models;
using System.Collections.ObjectModel;

namespace CentricaShops.ViewModels
{
    public class SalePersonProcessor : ISalePersonProcessor
    {
        public ObservableCollection<DistrictAndSalePerson> AddSalePerson(string district, SalepersonAndRole salePerson, ObservableCollection<DistrictAndSalePerson> districts)
        {
            var _district = districts;
            //var districtAndSalePerson = new DistrictAndSalePerson(district, salePerson.SalePerson );
            //_district.Add(districtAndSalePerson);
            return _district;
        }

        //public ObservableCollection<DistrictAndSalePerson> ProcessSalePerson(string district, SalepersonAndRole salePerson, ObservableCollection<DistrictAndSalePerson> districts)
        //{
        //    var _districts = districts;
        //    //If new person is Primary
        //    //replace old primary with new saleperson
        //    if (salePerson.IsPrimary)
        //    {
        //        ReplaceSalePerson(district, salePerson, _districts);
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
        //            _districts = AddSalePerson(district, salePerson, _districts);
        //        }

        //    }
        //    return _districts;
        //}

        //public ObservableCollection<DistrictAndSalePerson> ReplaceSalePerson(string district, SalepersonAndRole newSalePerson, ObservableCollection<DistrictAndSalePerson> districts)
        //{
        //    var _districts = districts;
        //    int index = -1;
        //    for (int i = 0; i < _districts.Count; i++)
        //    {
        //        if (_districts[i].District == district && _districts[i].salepersonAndRole.IsPrimary)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    if (index > -1)
        //    {
        //        _districts[index].salepersonAndRole = newSalePerson;

        //    }
        //    return _districts;
        //}
        //public void RemoveSalePerson(string district, SalepersonAndRole salePerson, ObservableCollection<DistrictAndSalePerson> districts)
        //{
        //    var _districts = districts;
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

        //public void GetSalePersons(string district)
        //{
        //    //SelectedDistrictTest = district;
        //    //var salePersonsAndRole = _districts.Where(x => x.District.Equals(district)).Select(x => x.salepersonAndRole);
        //    //SalePersons.Clear();
        //    //foreach (var el in salePersonsAndRole)
        //    //{ SalePersons.Add(el); }


        //    //var stores = _storesAndDistricts.Where(x => x.District.Equals(district)).Select(x => x.Store);
        //    //Stores.Clear();
        //    //foreach (var el in stores)
        //    //{ Stores.Add(el); }
        //}

        //public void GetSalePersons(ObservableCollection<DistrictAndSalePerson> districts, ObservableCollection<StoreAndDistrict> _storesAndDistricts, ObservableCollection<SalepersonAndRole> salepersonAndRole, string district)
        //{
        //    throw new NotImplementedException();
        //}
    }
}


