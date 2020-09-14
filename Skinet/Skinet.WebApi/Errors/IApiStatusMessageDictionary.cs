namespace Skinet.WebApi.Errors
{
    public interface IApiStatusMessageDictionary
    {
        string GetDefaultMessageForStatusCode(ApiStatusCode statusCode);
    }
}
