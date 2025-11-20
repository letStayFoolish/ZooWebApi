using System.ComponentModel.DataAnnotations;
using ZooWebApi.Domain.Enumerations;

namespace ZooWebApi.Settings;

public class ZooSettings
{
    public const string SectionName = "ZooSettings";
    [Required]
    public StorageType StorageType { get; set; } = StorageType.InMemory;

}