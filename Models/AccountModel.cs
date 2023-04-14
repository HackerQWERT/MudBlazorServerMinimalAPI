namespace MudBlazorServer.Models;

public class AccountModel
{
    public string Id { get; set; }
    public string Password { get; set; }
    public int LastDrawCounts { get; set; }
    public int LastChatCounts { get; set; }
    public string ExclusiveInvitationCode { get; set; }
    public string BoundInvitationCode { get; set; }
}
