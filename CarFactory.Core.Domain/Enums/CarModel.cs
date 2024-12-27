using System.Text.Json.Serialization;

namespace CarFactory.Core.Domain.Enums
{
    /// <summary>
    /// Enum with types of car model
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CarModel
    {
        Sedan = 1,
        Suv = 2,
        OffRoad = 3,
        Sport = 4,
    }
}
