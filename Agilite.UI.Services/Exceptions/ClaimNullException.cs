namespace Agilite.UI.Services.Exceptions;

internal class ClaimNullException : Exception
{
    public override string Message => "The choosen claim type is null";
}