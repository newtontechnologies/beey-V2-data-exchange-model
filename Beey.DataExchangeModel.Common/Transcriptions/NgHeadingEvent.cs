using System.Text.Json;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Transcriptions;

public class NgHeadingEvent : NgEvent
{
    public string? Heading { get; set; }

    private int _level = 1;
    public int Level
    {
        get => _level;
        set => _level = value < 1 ? 1 : value;
    }

    public NgHeadingEvent()
    {
        Level = 1;
    }

    public NgHeadingEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());
        Heading = source["h"]?.Deserialize<string>();
        if (source.TryGetPropertyValue("l", out var lToken))
            Level = lToken.Deserialize<int>();
        else
            Level = 1;
    }

    public override JsonObject Serialize()
    {
        return new JsonObject()
        {
            { "b", (long)Begin.TotalMilliseconds },
            { "k", "h" },
            { "h", Heading },
            { "l", Level },
        };
    }
}
