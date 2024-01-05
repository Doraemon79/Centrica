namespace CentricaShops.Models
{
    public class StoreAndDistrict
    {
        public string District { get; set; }
        public string Store { get; set; }
        public StoreAndDistrict(string store, string district)
        {
            District = district;
            Store = store;
        }

    }
}
