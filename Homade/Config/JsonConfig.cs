using System.Text.Json;
using System.Text.Json.Serialization;

namespace Homade.Config;

public static class JsonConfig
{
    public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
}