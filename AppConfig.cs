using System;
using System.IO;
using System.Text.Json;

public class AppConfig
{
    public string BackendUrl { get; set; }
}

public static class ConfigurationManager
{
    public static AppConfig LoadConfiguration()
    {
        try
        {
            var jsonConfig = File.ReadAllText("appconfig.json");
            return JsonSerializer.Deserialize<AppConfig>(jsonConfig);
        }
        catch (Exception ex)
        {
            // Behandeln Sie Fehler beim Laden der Konfigurationsdatei
            // Hier können Sie Fehlerprotokollierung oder Benachrichtigungen implementieren
            return null;
        }
    }
}
