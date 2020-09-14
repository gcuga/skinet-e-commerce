using System;
using System.Collections.Generic;

namespace Skinet.WebApi.Errors
{
    public class ApiStatusMessageDictionary : IApiStatusMessageDictionary
    {
        private Dictionary<ApiStatusCode, string> _messageDictionary;

        public ApiStatusMessageDictionary()
        {
            _messageDictionary = new Dictionary<ApiStatusCode, string>
            {
                { ApiStatusCode.BadRequest, "A bad request, you have made" },
                { ApiStatusCode.Unauthorized, "Authorized, you are not" },
                { ApiStatusCode.NotFound, "Resource found, it was not"},
                { ApiStatusCode.InternalServerError, "Chief, all is lost"}
            };
        }

        public string GetDefaultMessageForStatusCode(ApiStatusCode statusCode)
        {
            _messageDictionary.TryGetValue(statusCode, out string statusMessage);
            return statusMessage;
        }
    }
}
