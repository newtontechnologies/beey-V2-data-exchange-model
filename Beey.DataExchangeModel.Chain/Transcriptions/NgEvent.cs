using System.Text.Json;
using System.Text.Json.Nodes;


namespace Beey.DataExchangeModel.Transcriptions;

public abstract class NgEvent
{
    public TimeSpan Begin { get; set; }

    public NgEvent()
    {
    }

#pragma warning disable IDE0060 // Remove unused parameter

    public NgEvent(JsonObject? source)
    {
    }

#pragma warning restore IDE0060 // Remove unused parameter

    public abstract JsonObject Serialize();

    internal static NgEvent Deserialize(JsonObject e, DiarEventList? parent)
    {
        return e["k"].Deserialize<string>() switch
        {
            "s" or "e" => new NgSpeakerEvent(e),
            "p" => new NgPhraseEvent(e),
            "r" => new NgRecoveryEvent(e),
            "v" => new NgVoiceprintEvent(e),
            "h" => new NgHeadingEvent(e),
            "l" => new NgPhraseLookAheadEvent(e),
            _ => throw new NotImplementedException(),
        };
    }
}
