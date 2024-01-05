using CentricaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Services
{
    public interface IDistrictsAndSalesPeopleService
    {
        Task<IEnumerable<string>> GetAllDistricts();
        Task<IEnumerable<SalepersonAndRole>> GetSalePeopleByDistrict(string district);
        Task<IEnumerable<string>> GetStoreseByDistrict(string district);
    }
}
