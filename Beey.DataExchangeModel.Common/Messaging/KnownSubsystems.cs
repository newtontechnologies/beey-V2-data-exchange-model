namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystems
{
    public const string Upload = "Upload";
    public const string MediaIdentification = "MediaIdentification";
    public const string TranscodingVideo = "TranscodingVideo";
    public const string TranscodingAudio = "TranscodingAudio";
    public const string MediaFileIndexing = "MediaFileIndexing";
    public const string MediaFilePackaging = "MediaFilePackaging";
    public const string Recognition = "Recognition";
    public const string Diarization = "Diarization";

    public const string RawRecognition = "RawRecognition";
    public const string RawDiarization = "RawDiarization";

    public const string NanoGridCombined = "NanoGrid";

    public const string SpeakerIdentification = "SpeakerIdentification";
    public const string Spp = "Spp";

    public const string TranscriptionStreaming = "TranscriptionStreaming";
    public const string LiveSubtitlesStreaming = "LiveSubtitlesStreaming";
    public const string LiveTranscriptionStreaming = "LiveTranscriptionStreaming";

    public const string TranscriptionTracking = "TranscriptionTracking";
    public const string TranscriptionTimeLogging = "TranscriptionTimeLogging";
    public const string TranscriptionCreation = "TranscriptionCreation";
    public const string ProjectStatusMonitor = "ProjectStatusMonitor";
    public const string VoiceprintAggregation = "VoiceprintAggregation";
    public const string TranscriptionQueueTracking = "TranscriptionQueueTracking";
    public const string LowQualityAudio = "LowQualityAudio";
    public const string SceneDetection = "SceneDetection";

    public const string TranscodingGroup = "Transcoding";
    public const string TranscribingGroup = "Transcribing";
    public const string RecognitionGroup = "Recognition";
    public const string PostprocessingGroup = "Posprocessing";
    public const string PackagingGroup = "Packaging";
    public const string TextCreationGroup = "TextCreation";
    public const string ChainControl = "ChainControl";

    // Virtual subsystems
    public const string CreditReservation = "CreditReservation";

    public const string ProjectUpdates = "ProjectUpdates";
}
