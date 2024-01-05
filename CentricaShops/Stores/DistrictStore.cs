using CentricaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Stores
{
    public class DistrictStore
    {
        private readonly List<string> _districts;

        public IEnumerable<string> Districts => _districts; 
    }
}
