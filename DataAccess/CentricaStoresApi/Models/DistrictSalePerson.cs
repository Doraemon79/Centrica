using System.ComponentModel.DataAnnotations;

namespace CentricaStoresApi.Models;

public class DistrictSalePerson
{
    [Required(AllowEmptyStrings = false)]
    public string districtname { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string name { get; set; }
}
