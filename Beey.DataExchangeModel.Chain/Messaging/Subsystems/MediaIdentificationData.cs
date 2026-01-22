using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Serialization.JsonConverters;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class MediaIdentificationData : SubsystemData<MediaIdentificationData>
{
    public enum DurationKind
    {
        Duration,
        ApproximateDuration,
        DurationlessStream,
        Error,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DurationKind? Kind { get; set; }

    [JsonConverter(typeof(JsonNullableConverter<JsonTimeSpanConverter, TimeSpan>))]
    public TimeSpan? Duration { get; set; }
    public MediaInfo? MediaInfo { get; set; }

    public string? RawData { get; set; }
    public string? Error { get; set; }
}

public class MediaInfo
{
    public bool HasVideo { get; set; }
    public bool IsPackaged { get; set; }
}
