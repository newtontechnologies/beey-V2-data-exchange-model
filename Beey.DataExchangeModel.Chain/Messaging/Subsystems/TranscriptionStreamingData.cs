using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Common.Messaging.Subsystems;

public class TranscriptionStreamingData : SubsystemData<TranscriptionStreamingData>
{
    public TimeSpan? Transcribed { get; set; }
    public NgPhraseEvent? Word { get; set; }
    public NgSpeakerEvent? SpeakerChangePoint { get; set; }
    public TimeSpan? RecognitionLength { get; set; }

    //for backward compatibility maintain writing null on other data
    //ignore writing null on new V2 data and stuff usefully only internally to reduce message sizes
    //C# static typed wrappers should be immune to these changes
    public SpeakerIdentificationData? SpeakerData { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgHeadingEvent? Heading { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgPhraseLookAheadEvent[]? Draft { get; set; }

}
