using System;
using System.Web.Http;

namespace StoryTale.Core.Web
{
    public class ClientException : Exception
    {
        public ClientException(HttpError errorObject) : base(errorObject.Message)
        {
            HttpErrorObject = errorObject;
        }

        public HttpError HttpErrorObject { get; }
    }
}