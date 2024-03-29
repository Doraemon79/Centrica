﻿using System.Runtime.Serialization;

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
