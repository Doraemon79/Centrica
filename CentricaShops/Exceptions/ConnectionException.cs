using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CentricaShops.Exceptions
{
    public class ConnectionException : Exception
    {
        string Client { get; set; }
        public ConnectionException(string client)
        {
            Client = client;
        }

        public ConnectionException(string? message, string client) : base(message)
        {
            Client = client;
        }

        public ConnectionException(string? message, Exception? innerException, string client) : base(message, innerException)
        {
            Client = client;
        }

        protected ConnectionException(SerializationInfo info, StreamingContext context, string client) : base(info, context)
        {
            Client = client;
        }
    }
}
