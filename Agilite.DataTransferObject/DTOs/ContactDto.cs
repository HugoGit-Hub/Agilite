namespace Agilite.DataTransferObject.DTOs;

public class ContactDto
{
    public int IdContact { get; set; }

    public string NameContact { get; set; } = null!;

    public bool ArchivedContact { get; set; }
}