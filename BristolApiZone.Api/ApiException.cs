using System;
using System.Net.Http;

namespace ApiWrapper
{
    public sealed class ApiException : Exception
    {
        public override string Message { get; }

        public ApiException(HttpResponseMessage response)
        {
            var method = response.RequestMessage.Method.Method;
            var path = response.RequestMessage.RequestUri.AbsolutePath;
            var status = response.StatusCode;

            var message = $"Error calling {method} {path} (status: {status})";

            Data.Add("Status Code", status);
            Data.Add("Method", method);
            Data.Add("Uri", response.RequestMessage.RequestUri.ToString());

            Message = message;
        }
    }
}
