namespace Agilite.DataTransferObject.DTOs;

public class UserDto
{
    public int IdUser { get; set; }

    public string? FirstNameUser { get; set; }

    public string? LastNameUser { get; set; }

    public string? EmailUser { get; set; }

    public string? PasswordUser { get; set; }

    public int EnumRoleUser { get; set; }

    public string? DateCreationUser { get; set; }

    public int? AgeUser { get; set; }
}
