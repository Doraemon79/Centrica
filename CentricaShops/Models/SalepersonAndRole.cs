namespace CentricaShops.Models
{
    public class SalepersonAndRole
    {
        public string SalePerson { get; set; }
        public bool IsPrimary { get; set; }
        public SalepersonAndRole(string salePerson, bool isPrimary)
        {
            SalePerson = salePerson;
            IsPrimary = isPrimary;
        }
    }
}
