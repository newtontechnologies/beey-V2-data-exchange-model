using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging;

using static Beey.DataExchangeModel.Messaging.KnownSubsystems;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

public class MessageJsonConverterWithTypeDiscriminator : JsonConverter<Message>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(Message).IsAssignableFrom(typeToConvert);

    public override Message? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        MessageType messageType;
        string? subsystem;
        JsonObject jMessage = (JsonObject)(JsonNode.Parse(ref reader) ?? throw new JsonException());

        if (!(jMessage.TryGetPropertyValue(nameof(Message.Type), out var jType)
            && jType is JsonValue vType
            && vType.TryGetValue<string>(out var sType)
            && Enum.TryParse<MessageType>(sType, out messageType)
            ))
            throw new JsonException();

        if (!(jMessage.TryGetPropertyValue(nameof(Message.Subsystem), out var jSubsystem)
            && jSubsystem is JsonValue vSubsystem
            && vSubsystem.TryGetValue<string>(out subsystem)
            && subsystem != null)
            )
            throw new JsonException();

        return messageType switch
        {
            MessageType.Started => JsonSerializer.Deserialize<StartedMessage>(jMessage),
            MessageType.Progress => DiscriminateProgressMessage(jMessage, options, subsystem),
            MessageType.Failed => JsonSerializer.Deserialize<FailedMessage>(jMessage),
            MessageType.Completed => JsonSerializer.Deserialize<CompletedMessage>(jMessage),
            MessageType.Panic => JsonSerializer.Deserialize<PanicMessage>(jMessage),
            MessageType.Tracing => JsonSerializer.Deserialize<TracingMessage>(jMessage),
            MessageType.ChainStatus => JsonSerializer.Deserialize<ChainControl.Status>(jMessage),
            MessageType.ChainCommand => JsonSerializer.Deserialize<ChainControl.Command>(jMessage),
            _ => throw new JsonException($"Unknown messageType: {messageType}"),
        };
    }

    public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        switch (value.Type)
        {
            case MessageType.Started:
                JsonSerializer.Serialize(writer, (StartedMessage)value, KnownSubsystemsBaseContext.Default.StartedMessage);
                return;

            case MessageType.Progress:
                DiscriminateProgressMessage(writer, value, options);
                return;

            case MessageType.Failed:
                JsonSerializer.Serialize(writer, (FailedMessage)value, KnownSubsystemsBaseContext.Default.FailedMessage);
                return;

            case MessageType.Completed:
                JsonSerializer.Serialize(writer, (CompletedMessage)value, KnownSubsystemsBaseContext.Default.CompletedMessage);
                return;

            case MessageType.ChainStatus:
                JsonSerializer.Serialize(writer, (ChainControl.Status)value, ChainControl.ChainControlSerializerContext.Default.Status);
                return;

            case MessageType.ChainCommand:
                JsonSerializer.Serialize(writer, (ChainControl.Command)value, ChainControl.ChainControlSerializerContext.Default.Command);
                return;

            case MessageType.Panic:
                JsonSerializer.Serialize(writer, (PanicMessage)value, ChainControl.ChainControlSerializerContext.Default.PanicMessage);
                return;

            case MessageType.Tracing:
                JsonSerializer.Serialize(writer, (TracingMessage)value, ChainControl.ChainControlSerializerContext.Default.TracingMessage);
                return;
        }
        throw new NotImplementedException($"Unknown message {value}");
    }

    static void DiscriminateProgressMessage(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        var subsystem = value.Subsystem;
        if (subsystem == Diarization.Name)
        {
            JsonSerializer.Serialize(writer, (Diarization.Progress)value, Diarization.DiarizationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == VoiceprintAggregation.Name)
        {
            JsonSerializer.Serialize(writer, (VoiceprintAggregation.Progress)value, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Upload.Name)
        {
            JsonSerializer.Serialize(writer, (Upload.Progress)value, Upload.UploadSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTracking.Progress)value, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionTimeLogging.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTimeLogging.Progress)value, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionCreation.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionCreation.Progress)value, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaFilePackaging.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFilePackaging.Progress)value, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == CreditReservation.Name)
        {
            JsonSerializer.Serialize(writer, (CreditReservation.Progress)value, CreditReservation.CreditReservationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaFileIndexing.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFileIndexing.Progress)value, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaIdentification.Name)
        {
            JsonSerializer.Serialize(writer, (MediaIdentification.Progress)value, MediaIdentification.MediaIdentificationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == ProjectStatusMonitor.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectStatusMonitor.Progress)value, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Recognition.Name)
        {
            JsonSerializer.Serialize(writer, (Recognition.Progress)value, Recognition.RecognitionSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == SpeakerId.Name)
        {
            JsonSerializer.Serialize(writer, (SpeakerId.Progress)value, SpeakerId.SpeakerIdentificationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Spp.Name)
        {
            JsonSerializer.Serialize(writer, (Spp.Progress)value, Spp.SppSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscodingVideo.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingVideo.Progress)value, TranscodingVideo.TranscodingVideoSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscodingAudio.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingAudio.Progress)value, TranscodingAudio.TranscodingAudioSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == RawDiarization.Name)
        {
            JsonSerializer.Serialize(writer, (RawDiarization.Progress)value, RawDiarization.RawDiarizationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == RawRecognition.Name)
        {
            JsonSerializer.Serialize(writer, (RawRecognition.Progress)value, RawRecognition.RawRecognitionSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionStreaming.Progress)value, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == LiveSubtitlesStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (LiveSubtitlesStreaming.Progress)value, LiveSubtitlesStreaming.LiveSubtitlesStreamingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == ProjectUpdates.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectUpdates.Progress)value, ProjectUpdates.ProjectUpdatesSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == NanoGrid.Name)
        {
            JsonSerializer.Serialize(writer, (NanoGrid.Progress)value, NanoGrid.NanoGridSerializerContext.Default.Progress);
            return;
        }

        JsonSerializer.Serialize(writer, value, KnownSubsystemsBaseContext.Default.ProgressMessage);
    }

    static ProgressMessage? DiscriminateProgressMessage(JsonObject jMessage, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize<Diarization.Progress>(jMessage);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize<VoiceprintAggregation.Progress>(jMessage);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize<Upload.Progress>(jMessage);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionTracking.Progress>(jMessage);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize<TranscriptionTimeLogging.Progress>(jMessage);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize<TranscriptionCreation.Progress>(jMessage);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize<MediaFilePackaging.Progress>(jMessage);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize<CreditReservation.Progress>(jMessage);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize<MediaFileIndexing.Progress>(jMessage);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize<MediaIdentification.Progress>(jMessage);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize<ProjectStatusMonitor.Progress>(jMessage);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize<Recognition.Progress>(jMessage);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize<SpeakerId.Progress>(jMessage);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize<Spp.Progress>(jMessage);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize<TranscodingVideo.Progress>(jMessage);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize<TranscodingAudio.Progress>(jMessage);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize<RawRecognition.Progress>(jMessage);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize<RawDiarization.Progress>(jMessage);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize<TranscriptionStreaming.Progress>(jMessage);
        if (subsystem == LiveSubtitlesStreaming.Name)
            return JsonSerializer.Deserialize<LiveSubtitlesStreaming.Progress>(jMessage);
        if (subsystem == ProjectUpdates.Name)
            return JsonSerializer.Deserialize<ProjectUpdates.Progress>(jMessage);
        if (subsystem == NanoGrid.Name)
            return JsonSerializer.Deserialize<NanoGrid.Progress>(jMessage);

        return JsonSerializer.Deserialize<ProgressMessage>(jMessage);
    }
}
