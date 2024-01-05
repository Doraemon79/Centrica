using CentricaShops.Models;
using System.Collections.ObjectModel;

namespace CentricaShops.ViewModels
{
    public interface ISalePersonProcessor
    {
        ObservableCollection<DistrictAndSalePerson> AddSalePerson(string district, SalepersonAndRole salePerson, ObservableCollection<DistrictAndSalePerson> districts);
    }
}
