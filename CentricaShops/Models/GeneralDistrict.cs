using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Models
{
    public class GeneralDistrict
    {
        private readonly List<string> _districts;
        private readonly List<StoreSalePerson> _districtDetails;

        public string StoresName { get; }

        public GeneralDistrict(string storesName)
        {
            StoresName=storesName;
            _districts = new List<string>();
            _districtDetails = new List<StoreSalePerson>();
        }

        public IEnumerable<string> GetDistricts()
        {
           return _districts;
        }

        public void SetDistricts(IEnumerable<string> districts)
        {
            _districts.AddRange(districts);
        }

        public IEnumerable<StoreSalePerson> GetDetails()
        {
            return _districtDetails;
        }

    }
}
