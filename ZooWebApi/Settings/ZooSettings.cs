using System.ComponentModel.DataAnnotations;

namespace ZooWebApi.Settings;

public class ZooSettings
{
    public const string SectionName = "ZooSettings";
    [Required]
    public string StorageType { get; set; } = string.Empty;

}