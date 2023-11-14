namespace DataExtractionTool.Helpers
{
    public static class AppSettings
    {
        public static string DBConnectionStringAU { get; set; }
        public static string DBConnectionStringNZ { get; set; }

        public static string GetConnectinString(string country)
        {
          return  country == "AU" ? AppSettings.DBConnectionStringAU : AppSettings.DBConnectionStringNZ;
        }

    }
}
