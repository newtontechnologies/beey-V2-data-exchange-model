using Beey.DataExchangeModel.Messaging.Subsystems;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Common.Messaging.Subsystems;

public class TranscriptionStreamingData : SubsystemData<TranscriptionStreamingData>
{
    public TimeSpan? Transcribed { get; set; }
    public NgPhraseEvent? Word { get; set; }
    public NgSpeakerEvent? SpeakerChangePoint { get; set; }
    public SpeakerIdentificationData? SpeakerData { get; set; }
    public NgHeadingEvent? Heading { get; set; }

    public NgPhraseLookAheadEvent[]? Hypothesis { get; set; }
    public TimeSpan? RecognitionLength { get; set; }
}
