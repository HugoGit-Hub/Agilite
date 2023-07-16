namespace Agilite.UI.Services.Exceptions;

internal class NoTokenStoredInCacheException : Exception
{
    public override string Message => "No token stored in cache";
}