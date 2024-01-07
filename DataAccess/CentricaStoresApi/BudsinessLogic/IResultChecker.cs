using CentricaStoresApi.Models;

namespace CentricaStoresApi.BudsinessLogic;

public interface IResultChecker
{
    bool PresentInDistrict(IEnumerable<StorePersonDistrictModel> list, string name);
    bool SalePersonIsPrimary(IEnumerable<StorePersonDistrictModel> list, string name);
}