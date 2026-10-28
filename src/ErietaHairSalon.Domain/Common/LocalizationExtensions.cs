namespace ErietaHairSalon.Domain.Common;

public static class LocalizationExtensions
{
    public static string Localize(this Dictionary<string, string>? dict, string lang, string fallback = "en")
    {
        if (dict is null || dict.Count == 0) return string.Empty;
        if (dict.TryGetValue(lang, out var val) && !string.IsNullOrWhiteSpace(val)) return val;
        if (dict.TryGetValue(fallback, out var fallbackVal)) return fallbackVal;
        return dict.Values.FirstOrDefault() ?? string.Empty;
    }
}