using CentricaStoresApi.Models;

namespace CentricaStoresApi.BudsinessLogic;

public class ResultChecker: IResultChecker
{
    public bool PresentInDistrict(IEnumerable<StorePersonDistrictModel> list, string name)
    {
        var tst= list.Any(x => x.SalePerson.Equals(name));
        return  tst;
    }

    public bool SalePersonIsPrimary(IEnumerable<StorePersonDistrictModel> list, string name)
    {
      return list.Where(x => x.SalePerson.Equals("name")).First().IsPrimary;
    }
    
}
