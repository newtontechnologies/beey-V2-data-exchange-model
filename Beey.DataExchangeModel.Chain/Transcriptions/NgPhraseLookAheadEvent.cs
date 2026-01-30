using System.Text.Json;
using System.Text.Json.Nodes;



namespace Beey.DataExchangeModel.Transcriptions;

public class NgPhraseLookAheadEvent : NgEvent
{
    public TimeSpan End { get; set; }

    public string? Text { get; set; } = null;
    public double Confidence { get; set; } = 1;
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
        else
            Confidence = 1.0;

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

        return ret;
    }
}
