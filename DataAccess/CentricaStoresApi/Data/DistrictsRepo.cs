using CentricaStoresApi.Models;
using DataAccess.DbAccess;
using System.Linq;

namespace CentricaStoresApi.Data;

public class DistrictsRepo : IDistrictsRepo
{
    private readonly CentricaDbContext _context;
    private readonly ISqlDataAccess _dataAccess;

    public DistrictsRepo(CentricaDbContext centricaDbContext, ISqlDataAccess sqlDataAccess)
    {
        _context = centricaDbContext;
        _dataAccess = sqlDataAccess;
    }
    public async Task<IEnumerable<string>> GetAll()
    {
        using (var connection = this._context.CreateConnection())
        {
            return await _dataAccess.LoadData<string, dynamic>("Districts_GetAll", new { });
     
        }
    }

    public async Task<IEnumerable<StorePersonDistrictModel>> GetDetailsByDistrict(string district)
    {
        using (var connection = this._context.CreateConnection())
        {
            return await _dataAccess.LoadData<StorePersonDistrictModel, dynamic>("GetDetails_ByDistrict" , new { DistrictInput = district });
        }
    }

    public async Task InsertSalePerson(string name, string districtname)
    {
        using (var connection = this._context.CreateConnection())
        {
            await _dataAccess.SaveData("InsertPerson_Secondary", new { SalePersonName = name, DistrictName = districtname });
           
        }
    }

    public async Task UpdateSalePerson(string name, string districtname)
    {
        using (var connection = this._context.CreateConnection())
        {
            await _dataAccess.SaveData("PrimarySaleperson_Update", new { SalePersonName = name, DistrictName = districtname });
        }
    }

    public async Task DeleteSalePerson(string name, string districtname)
    {
        using (var connection = this._context.CreateConnection())
        {
            await _dataAccess.SaveData("DeleteSalePerson", new { SalePersonName = name, DistrictName = districtname });
        }
    }

}
