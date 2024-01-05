using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Models
{
    public class StoreSalePerson
    {
        public string StoreName { get; set; }
        public string SalePerson { get; set; }
        public Boolean IsPrimary { get; set; }

        public StoreSalePerson(string storeName, string salePerson, bool isPrimary)
        {
            StoreName = storeName;
            SalePerson = salePerson;
            IsPrimary = isPrimary;
        }

    }
}
