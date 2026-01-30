using System.Text.Json;
using System.Text.Json.Nodes;



namespace Beey.DataExchangeModel.Transcriptions;

public class NgPhraseLookAheadEvent : NgEvent
{
    public TimeSpan End { get; set; }

    public string? Text { get; set; }
    public double Confidence { get; set; }
    public string? Phonetics { get; set; }

    public NgPhraseLookAheadEvent()
    {
        Confidence = 1.0;
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
        return
            new JsonObject()
            {
                { "b", (long)Begin.TotalMilliseconds },
                { "e", (long)End.TotalMilliseconds },
                { "k", "l" },
                { "t", Text },
                { "c", Confidence },
                { "p", Phonetics },
            };
    }
}
