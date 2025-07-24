namespace Garry_Net
{
    public class AppSettings
    {
        public AzureAdSettings AzureAd { get; set; }
        public BotSettings Bot { get; set; }
    }

    public class AzureAdSettings
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class BotSettings
    {
        public string CallbackUrl { get; set; }
    }
}
