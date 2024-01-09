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

        public string StoresName { get; }

        public GeneralDistrict(string storesName)
        {
            StoresName=storesName;
        }

    }
}
