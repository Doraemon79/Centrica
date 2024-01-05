using CentricaShops.Models;
using System.Runtime.Serialization;

namespace CentricaShops.Exceptions
{
    public class SalePersonException : Exception
    {
        public SalepersonAndRole SalePersonIsPrimaryExisting { get; }
        public SalepersonAndRole SalePersonIsPrimary { get; }

        public SalePersonException(SalepersonAndRole salePersonIsPrimaryExisting)
        {
            SalePersonIsPrimaryExisting = salePersonIsPrimaryExisting;
        }

        public SalePersonException(string? message, SalepersonAndRole salePersonIsPrimaryExisting) : base(message)
        {
            SalePersonIsPrimaryExisting = salePersonIsPrimaryExisting;
        }

        public SalePersonException(string? message, Exception? innerException, SalepersonAndRole salePersonIsPrimaryExisting) : base(message, innerException)
        {
            SalePersonIsPrimaryExisting = salePersonIsPrimaryExisting;
        }

        protected SalePersonException(SerializationInfo info, StreamingContext context, SalepersonAndRole salePersonIsPrimaryExisting) : base(info, context)
        {
            SalePersonIsPrimaryExisting = salePersonIsPrimaryExisting;
        }
    }
}
