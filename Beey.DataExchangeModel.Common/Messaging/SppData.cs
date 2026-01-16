using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Common.Messaging;

public class SppData : SubsystemData<SppData>
{
    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgPhraseEvent? RecognitionData { get; set; } = null;

    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgSpeakerEvent? DiarizationData { get; set; } = null;

    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgVoiceprintEvent? VoiceprintData { get; set; } = null;

    [JsonConverter(typeof(JsonNgEventConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NgHeadingEvent? HeadingData { get; set; } = null;
}

