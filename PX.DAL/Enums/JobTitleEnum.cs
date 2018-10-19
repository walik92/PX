using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PX.DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobTitleEnum
    {
        Administrator = 1,
        Developer = 2,
        Architect = 3,
        Manager = 4
    }
}