namespace AcconAPI.Application.Features.Queries.Settings.EmailSettings;

public class EmailSettingsQueryResponse
{
    public string? EmailFrom { get; set; }
    public string? EmailTo { get; set; }
    public string? SmptHost { get; set; }
    public int? SmptPort { get; set; }
    public string? SmptUser { get; set; }
    public string? SmptPassword { get; set; }

}