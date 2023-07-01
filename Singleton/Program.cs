

using Singleton.Start;


class Program
{
    static MemoryLogger Logger;

    static void Main(string[] args)
    {
        AssignVoucher("ahmed@mohamed.com" , "ABC123");
        UseVoucher("ABC123");
        Logger.ShowLog();
        Console.ReadKey();
    }

    static void AssignVoucher(string email , string voucher)
    {
        Logger = MemoryLogger.GetLogger;
        Logger.LogInfo($"voucher '{voucher}' assigned");
        Logger.LogError($"unable to send email '{email}'");
    }

    static void UseVoucher(string Voucher)
    {
        Logger = MemoryLogger.GetLogger;
        Logger.LogWarning($"3 attempts made to validate the voucher");
        Logger.LogInfo($"'{Voucher}' is used");
    }

}