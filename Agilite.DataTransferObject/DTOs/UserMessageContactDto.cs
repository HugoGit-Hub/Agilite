namespace Agilite.DataTransferObject.DTOs;

public class UserMessageContactDto
{
    public int UserIdUser { get; set; }

    public int ContactIdContact { get; set; }

    public int MessageIdMessage { get; set; }

    public DateTime DateTimeUserMessageContact { get; set; }
}