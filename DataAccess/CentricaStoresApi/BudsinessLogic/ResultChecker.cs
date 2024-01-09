using CentricaStoresApi.Models;

namespace CentricaStoresApi.BudsinessLogic;

public class ResultChecker: IResultChecker
{
    public bool PresentInDistrict(IEnumerable<StorePersonDistrictModel> list, string name)
    {
        return list.Any(x => x.SalePerson.Equals(name));
    }

    public bool SalePersonIsPrimary(IEnumerable<StorePersonDistrictModel> list, string name)
    {
      return list.Any(x => x.SalePerson.Equals("name") && x.IsPrimary) ;
    }
    
}
