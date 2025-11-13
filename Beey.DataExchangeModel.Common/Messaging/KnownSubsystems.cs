using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;
using static Beey.DataExchangeModel.Messaging.KnownSubsystems.ChainControl;

namespace Beey.DataExchangeModel.Messaging;



public static partial class KnownSubsystems
{
    [JsonSerializable(typeof(PanicMessage))]
    [JsonSerializable(typeof(ChainStatusMessage))]
    [JsonSerializable(typeof(ChainCommandMessage))]
    [JsonSerializable(typeof(TracingMessage))]
    [JsonSerializable(typeof(StartedMessage))]
    [JsonSerializable(typeof(CompletedMessage))]
    [JsonSerializable(typeof(FailedMessage))]
    [JsonSerializable(typeof(ProgressMessage))]
    public partial class KnownSubsystemsBaseContext : JsonSerializerContext { };

    public static partial class Diarization
    {
        public static string Name => KnownSubsystemNames.DiarizationSubsystem;
    }

    public static partial class RawDiarization
    {
        public static string Name => KnownSubsystemNames.RawDiarizationSubsystem;
    }

    public static partial class VoiceprintAggregation
    {
        public static string Name => KnownSubsystemNames.VoiceprintAggregation;
    }

    public static partial class Upload
    {
        public static string Name => KnownSubsystemNames.UploadSubsystem;
    }

    public static partial class TranscriptionTracking
    {
        public static string Name => KnownSubsystemNames.TranscriptionTracking;
    }

    public static partial class TranscriptionTimeLogging
    {
        public static string Name => KnownSubsystemNames.TranscriptionTimeLogging;
    }

    public static partial class TranscriptionCreation
    {
        public static string Name => KnownSubsystemNames.TranscriptionCreation;
    }

    public static partial class MediaFilePackaging
    {
        public static string Name => KnownSubsystemNames.MediaFilePackagingSubsystem;
    }

    public static partial class CreditReservation
    {
        public static string Name => KnownSubsystemNames.CreditReservation;
    }

    public static partial class MediaFileIndexing
    {
        public static string Name => KnownSubsystemNames.MediaFileIndexingSubsystem;
    }

    public static partial class MediaIdentification
    {
        public static string Name => KnownSubsystemNames.MediaIdentificationSubsystem;
    }

    public static partial class ProjectStatusMonitor
    {
        public static string Name => KnownSubsystemNames.ProjectStatusMonitor;
    }

    public static partial class Recognition
    {
        public static string Name => KnownSubsystemNames.RecognitionSubsystem;
    }

    public static partial class RawRecognition
    {
        public static string Name => KnownSubsystemNames.RawRecognitionSubsystem;
    }

    public static partial class LiveTranscriptionStreaming
    {
        public static string Name => KnownSubsystemNames.LiveTranscriptionStreamingSubsystem;
    }

    public static partial class SpeakerId
    {
        public static string Name => KnownSubsystemNames.SpeakerIdentificationSubsystem;
    }

    public static partial class Spp
    {
        public static string Name => KnownSubsystemNames.SppSubsystem;
    }

    public static partial class TranscodingVideo
    {
        public static string Name => KnownSubsystemNames.TranscodingVideoSubsystem;
    }

    public static partial class TranscodingAudio
    {
        public static string Name => KnownSubsystemNames.TranscodingAudioSubsystem;
    }

    public static partial class TranscriptionQueueTracking
    {
        public static string Name => KnownSubsystemNames.TranscriptionQueueTrackingSubsystem;
    }

    public static partial class LowQualityAudio
    {
        public static string Name => KnownSubsystemNames.LowQualityAudioSubsystem;
    }

    public static partial class SceneDetection
    {
        public static string Name => KnownSubsystemNames.SceneDetectionSubsystem;
    }

    public static partial class ChainControl
    {
        public static string Name => KnownSubsystemNames.ChainControl;
    }

    public static partial class TranscriptionStreaming
    {
        public static string Name => KnownSubsystemNames.TranscriptionStreamingSubsystem;
    }

    public static partial class LiveSubtitlesStreaming
    {
        public static string Name => KnownSubsystemNames.LiveSubtitlesStreamingSubsystem;
    }

    public static partial class ProjectUpdates
    {
        public static string Name => KnownSubsystemNames.ProjectUpdates;
    }

    public static partial class NanoGrid
    {
        public static string Name => KnownSubsystemNames.NanoGridCombinedSubsystem;
    }
}
