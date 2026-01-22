using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Serialization.JsonConverters;
using Beey.DataExchangeModel.Transcriptions;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class LanguageIdentificationData : SubsystemData<LanguageIdentificationData>
{
    [JsonConverter(typeof(JsonNgEventConverter))]
    public NgEvent? NgEvent { get; set; }
}
