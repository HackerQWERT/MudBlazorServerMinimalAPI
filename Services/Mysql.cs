namespace MudBlazorServer.Services;

static public class Mysql
{
    public static MySqlConnection MySqlConnection { get; set; }

    public static string Port { get; set; } = "3306";
    public static string Ip { get; set; } = "127.0.0.1";
    public static string Database { get; set; } = "AI";
    public static string User { get; set; } = "root";
    public static string Password { get; set; } = "F";
    public static string ConnectionString { get; } = $"server={Ip};port={Port};user={User};password={Password}; database={Database};";

    public static async Task<AccountModel>? QueryAccount(AccountModel accountModel)
    {
        var sqlString = @"Select * From Account Where Id=@Id";
        try
        {
            return await MySqlConnection.QueryFirstAsync<AccountModel>(sqlString, accountModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static async Task<AccountModel>? QueryExclusiveInvitationCode(AccountModel accountModel)
    {
        var sqlString = @"Select * From Account Where ExclusiveInvitationCode=@ExclusiveInvitationCode";
        try
        {
            return await MySqlConnection.QueryFirstAsync<AccountModel>(sqlString, accountModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static async Task<AccountModel>? QueryBoundInvitationCode(AccountModel accountModel)
    {
        var sqlString = @"Select * From Account Where BoundInvitationCode=@BoundInvitationCode";
        try
        {
            return await MySqlConnection.QueryFirstAsync<AccountModel>(sqlString, accountModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static async Task<int> InsertAccount(AccountModel accountModel)
    {
        var sqlString = @"INSERT INTO Account (Id,Password,LastDrawCounts,LastChatCounts) VALUES (@Id,@Password,@LastDrawCounts,@LastChatCounts)";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, accountModel);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }

    }

    public static async Task<int> UpdateAccountPassword(AccountModel accountModel)
    {
        var sqlString = @"UPDATE Account SET Password = @Password WHERE Id = @Id";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, accountModel);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    public static async Task<int> UpdateAccountExclusiveInvitationCodeOrBoundInvitationCode(AccountModel accountModel)
    {
        var sqlString = @"UPDATE Account SET ExclusiveInvitationCode = @ExclusiveInvitationCode,BoundInvitationCode=@BoundInvitationCode WHERE Id = @Id";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, accountModel);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }

    public static async Task<int> UpdateAccountLastDrawCountsOrLastChatCounts(AccountModel accountModel)
    {
        var sqlString = @"UPDATE Account SET LastDrawCounts = LastDrawCounts + @LastDrawCounts,LastChatCounts=LastChatCounts+ @LastChatCounts  WHERE Id = @Id";
        try
        {
            return await MySqlConnection.ExecuteAsync(sqlString, accountModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }
}
