using System.Collections.Immutable;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;

namespace Beey.DataExchangeModel.Messaging;



public static partial class KnownSubsystems
{
    [JsonSerializable(typeof(StartedMessage))]
    [JsonSerializable(typeof(CompletedMessage))]
    [JsonSerializable(typeof(FailedMessage))]
    [JsonSerializable(typeof(ProgressMessage))]
    public partial class KnownSubsystemsBaseContext : JsonSerializerContext { };

    public static partial class Diarization
    {
        [JsonSerializable(typeof(Progress))]
        public partial class DiarizationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.DiarizationSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class RawDiarization
    {
        [JsonSerializable(typeof(Progress))]
        public partial class RawDiarizationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.RawDiarizationSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class VoiceprintAggregation
    {
        [JsonSerializable(typeof(Progress))]
        public partial class VoiceprintAggregationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.VoiceprintAggregation;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class Upload
    {
        [JsonSerializable(typeof(Progress))]
        public partial class UploadSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.UploadSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscriptionTracking
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscriptionTrackingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionTracking;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscriptionTimeLogging
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscriptionTimeLoggingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionTimeLogging;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscriptionCreation
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscriptionCreationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionCreation;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class MediaFilePackaging
    {
        [JsonSerializable(typeof(Progress))]
        public partial class MediaFilePackagingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.MediaFilePackagingSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class CreditReservation
    {
        [JsonSerializable(typeof(Progress))]
        public partial class CreditReservationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.CreditReservation;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class MediaFileIndexing
    {
        [JsonSerializable(typeof(Progress))]
        public partial class MediaFileIndexingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.MediaFileIndexingSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class MediaIdentification
    {
        [JsonSerializable(typeof(Progress))]
        public partial class MediaIdentificationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.MediaIdentificationSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class ProjectStatusMonitor
    {
        [JsonSerializable(typeof(Progress))]
        public partial class ProjectStatusMonitorSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.ProjectStatusMonitor;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class Recognition
    {
        [JsonSerializable(typeof(Progress))]
        public partial class RecognitionSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.RecognitionSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class RawRecognition
    {
        [JsonSerializable(typeof(Progress))]
        public partial class RawRecognitionSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.RawRecognitionSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class LiveTranscriptionStreaming
    {
        [JsonSerializable(typeof(Progress))]
        public partial class LiveTranscriptionStreamingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.LiveTranscriptionStreamingSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class SpeakerId
    {
        [JsonSerializable(typeof(Progress))]
        public partial class SpeakerIdentificationSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.SpeakerIdentificationSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class Spp
    {
        [JsonSerializable(typeof(Progress))]
        public partial class SppSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.SppSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscodingVideo
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscodingVideoSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscodingVideoSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscodingAudio
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscodingAudioSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscodingAudioSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class TranscriptionQueueTracking
    {
        [JsonSerializable(typeof(StartedMessage))]
        public partial class TranscriptionQueueTrackingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionQueueTrackingSubsystem;
    }

    public static partial class LowQualityAudio
    {
        [JsonSerializable(typeof(StartedMessage))]
        public partial class LowQualityAudioSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.LowQualityAudioSubsystem;
    }

    public static partial class SceneDetection
    {
        [JsonSerializable(typeof(StartedMessage))]
        public partial class SceneDetectionSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.SceneDetectionSubsystem;
    }

    public static partial class ChainControl
    {
        [JsonSerializable(typeof(FailedMessage))]
        [JsonSerializable(typeof(PanicMessage))]
        [JsonSerializable(typeof(Status))]
        [JsonSerializable(typeof(Command))]
        [JsonSerializable(typeof(TracingMessage))]
        public partial class ChainControlSerializerContext : JsonSerializerContext { }

        public static string Name => KnownSubsystemNames.ChainControl;
        public sealed record Status(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, StatusNode? Statuses) : ChainStatusMessage(Id, Index, ProjectId, ChainId, Sent, Statuses);
        public sealed record Command(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, ChainCommand Command) : ChainCommandMessage(Id, Index, ProjectId, ChainId, Sent, Command);
    }

    public static partial class TranscriptionStreaming
    {
        [JsonSerializable(typeof(Progress))]
        public partial class TranscriptionStreamingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionStreamingSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class LiveSubtitlesStreaming
    {
        [JsonSerializable(typeof(Progress))]
        public partial class LiveSubtitlesStreamingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.LiveSubtitlesStreamingSubsystem;
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }

    public static partial class ProjectUpdates
    {
        [JsonSerializable(typeof(Progress))]
        public partial class ProjectUpdatesSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.ProjectUpdates;
        public sealed record Progress(int? ProjectId, int? ChainId, JsonNode Data)
            : ProgressMessage(-1, new SubsystemNodeIndex(), ProjectId, ChainId, Name, DateTimeOffset.Now, Data);
    }

    public static partial class NanoGrid
    {
        [JsonSerializable(typeof(Progress))]
        public partial class NanoGridSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.NanoGridCombinedSubsystem;

        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, ChainId, Name, Sent, Data);
    }
}
