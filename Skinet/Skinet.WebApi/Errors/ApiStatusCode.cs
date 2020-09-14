namespace Skinet.WebApi.Errors
{
    public enum ApiStatusCode
    {
        Unknown = 0,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        UnknownError = 520
    }
}
