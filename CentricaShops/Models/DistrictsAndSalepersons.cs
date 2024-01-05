using CentricaShops.Exceptions;

namespace CentricaShops.Models
{
    public class DistrictsAndSalepersons
    {
        private readonly List<DistrictAndSalePerson> _districtAndSalePeople;
        public DistrictsAndSalepersons()
        {
            _districtAndSalePeople = new List<DistrictAndSalePerson>();
        }

        public void AddSaleperson(string districtName, string salepersonName, bool isPrimary)
        {

            SalepersonAndRole salePersonToAdd = new SalepersonAndRole(salepersonName, isPrimary);

            //if not present and new one is primary
            // replace old primary with new

            // if not present and new one is NOT primary
            // add

            // if present already and new one is primary
            // replace old primary and remove old secondary which is NOT primary

            //if present and old one is primary and new one is not primary 
            //exception



            //var districtPerson = _districtAndSalePeople.Where(x => x.District.Equals(districtName) && x.salepersonAndRole.SalePerson.Equals(salepersonName));

            //int index = _districtAndSalePeople.FindIndex(x => x.District.Equals(districtName) && x.salepersonAndRole.SalePerson.Equals(salepersonName));
            //if (index == -1)
            //{
            //    if (isPrimary)
            //    {
            //        look for primary
            //        var primaryIndex = _districtAndSalePeople.FindIndex(x => x.District.Equals(districtName) && x.salepersonAndRole.IsPrimary);
            //        replace


            //        ReplaceSalePerson(districtName, salePersonToAdd, _districtAndSalePeople[primaryIndex].salepersonAndRole);
            //    }
            //    else
            //    {
            //        add
            //        var districtAndSaleperson = new DistrictAndSalePerson(districtName, salepersonName, isPrimary);
            //        _districtAndSalePeople.Add(districtAndSaleperson);
            //    }
            //}
            //else
            //{
            //    if (isPrimary)
            //    {
            //        replace old remove previous secondary

            //        RemoveSalePerson(districtName, _districtAndSalePeople[index].salepersonAndRole);
            //        var primaryIndex = _districtAndSalePeople.FindIndex(x => x.District.Equals(districtName) && x.salepersonAndRole.IsPrimary);
            //        ReplaceSalePerson(districtName, salePersonToAdd, _districtAndSalePeople[primaryIndex].salepersonAndRole);

            //    }
            //    else
            //    {
            //        throw new SalePersonException("A primary with same name exist", salePersonToAdd);
            //    }
            //}



            //if (index == -1 && isPrimary)
            //{

            //    var districtAndSaleperson = new DistrictAndSalePerson(districtName, salepersonName, isPrimary);
            //    _districtAndSalePeople.Add(districtAndSaleperson);
            //}

            //if (index != -1 && _districtAndSalePeople[index].salepersonAndRole.IsPrimary)
            //{
            //    throw new SalePersonException("A primary exist", salePersonToAdd);
            //}
            //if (index != -1 && !_districtAndSalePeople[index].salepersonAndRole.IsPrimary)
            //{
            //    var person = new SalepersonAndRole(salepersonName, isPrimary);
            //    RemoveSalePerson(districtName, person);
            //    var districtAndSaleperson = new DistrictAndSalePerson(districtName, salepersonName, isPrimary);
            //    _districtAndSalePeople.Add(districtAndSaleperson);
            //}


        }

        //public void ReplaceSalePerson(string districtName, SalepersonAndRole newSaleperson, SalepersonAndRole oldSaleperson)
        //{
        //    int index = _districtAndSalePeople.FindIndex(x => x.District.Equals(districtName) && x.salepersonAndRole.SalePerson.Equals(oldSaleperson));
        //    _districtAndSalePeople[index].salepersonAndRole = newSaleperson;
        //}

        //public void RemoveSalePerson(string districtName, SalepersonAndRole salepersonName)
        //{
        //    if (salepersonName.IsPrimary)
        //    { throw new SalePersonException("Cannot delete a Primary Saleperson try replacing it", salepersonName); }
        //    _districtAndSalePeople.RemoveAll(x => x.salepersonAndRole.SalePerson.Equals(salepersonName.SalePerson));
        //}
        //public IEnumerable<string> GetDistricts()
        //{
        //    var districts = _districtAndSalePeople.Select(x => x.District).Distinct() ;
        //    return districts;
        //}

        //private void RemoveSalePersonFromDistrict(string District, SalepersonAndRole salePerson)
        //{
        //    if(salePerson.IsPrimary)
        //    {
        //        throw new SalePersonException();
        //    }
        //}

    }
}
