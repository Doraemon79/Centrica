using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Models
{
    public class DistrictDetails
    {
        private readonly List<StoreSalePerson> _details;

        public DistrictDetails()
        {
            _details=new List<StoreSalePerson>();
        }
    }
}
