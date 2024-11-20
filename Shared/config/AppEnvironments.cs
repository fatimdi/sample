namespace tgworkshop.shared.config;
public class AppEnvironments
{
    public static string ConnectionString { get; set; }

    static AppEnvironments()
    {        
        ConnectionString = Environment.GetEnvironmentVariable("connectionstring")!;
    }


}