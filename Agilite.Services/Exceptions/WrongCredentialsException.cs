namespace Agilite.Services.Exceptions;

public class WrongCredentialsException : Exception
{
    public override string Message => "Credentials are not corrects";
}