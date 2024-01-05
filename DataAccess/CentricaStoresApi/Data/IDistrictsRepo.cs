using CentricaStoresApi.Models;

namespace CentricaStoresApi.Data;

public interface IDistrictsRepo
{
    Task<IEnumerable<string>> GetAll();
    Task<IEnumerable<StorePersonDistrictModel>> GetDetailsByDistrict(string district);
    Task InsertSalePerson(string name, string districtname);
    Task UpdateSalePerson(string name, string districtname);
    Task DeleteSalePerson(string name, string districtname);
}
