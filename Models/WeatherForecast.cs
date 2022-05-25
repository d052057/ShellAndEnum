using ShellAndEnum.Models;
using Newtonsoft.Json.Converters;
namespace ShellAndEnum
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public WeatherConditionEnum Summary { get; set; }
    }
}