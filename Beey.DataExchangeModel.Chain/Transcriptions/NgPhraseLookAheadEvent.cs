using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;



namespace Beey.DataExchangeModel.Transcriptions;

public class NgPhraseLookAheadEvent : NgEvent
{
    public TimeSpan End { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; } = null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public double? Confidence
    {
        get => field;
        set
        {
            if (value is { } v && Math.Abs(v - 1) < 0.001)
                value = null;

            field = value;
        }
    } = default;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Phonetics { get; set; } = null;

    public NgPhraseLookAheadEvent()
    {
    }

    public NgPhraseLookAheadEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());
        End = TimeSpan.FromMilliseconds(source["e"].Deserialize<long>());
        Text = source["t"]?.Deserialize<string>();
        if (source.TryGetPropertyValue("c", out var cToken))
            Confidence = cToken.Deserialize<double>();

        if (source.TryGetPropertyValue("p", out var pToken))
            Phonetics = pToken.Deserialize<string>();
    }

    public override JsonObject Serialize()
    {
        var ret =
            new JsonObject()
            {
                { "b", (long)Begin.TotalMilliseconds },
                { "e", (long)End.TotalMilliseconds },
                { "k", "l" },
            };

        if (Text is { })
            ret.Add("t", Text);

        if (Phonetics is { })
            ret.Add("p", Phonetics);

        if (Confidence is { } c)
            ret.Add("c", Confidence);


        return ret;
    }
}
