using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;
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
            MessageType.Progress => JsonSerializer.Deserialize<ProgressMessage>(jMessage),
            MessageType.Failed => JsonSerializer.Deserialize<FailedMessage>(jMessage),
            MessageType.Completed => JsonSerializer.Deserialize<CompletedMessage>(jMessage),
            MessageType.Panic => JsonSerializer.Deserialize<PanicMessage>(jMessage),
            MessageType.Tracing => JsonSerializer.Deserialize<TracingMessage>(jMessage),
            MessageType.ChainStatus => JsonSerializer.Deserialize<ChainStatusMessage>(jMessage),
            MessageType.ChainCommand => JsonSerializer.Deserialize<ChainCommandMessage>(jMessage),
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
                JsonSerializer.Serialize(writer, (ProgressMessage)value, KnownSubsystemsBaseContext.Default.ProgressMessage);
                return;

            case MessageType.Failed:
                JsonSerializer.Serialize(writer, (FailedMessage)value, KnownSubsystemsBaseContext.Default.FailedMessage);
                return;

            case MessageType.Completed:
                JsonSerializer.Serialize(writer, (CompletedMessage)value, KnownSubsystemsBaseContext.Default.CompletedMessage);
                return;

            case MessageType.ChainStatus:
                JsonSerializer.Serialize(writer, (ChainStatusMessage)value, KnownSubsystemsBaseContext.Default.ChainStatusMessage);
                return;

            case MessageType.ChainCommand:
                JsonSerializer.Serialize(writer, (ChainCommandMessage)value, KnownSubsystemsBaseContext.Default.ChainCommandMessage);
                return;

            case MessageType.Panic:
                JsonSerializer.Serialize(writer, (PanicMessage)value, KnownSubsystemsBaseContext.Default.PanicMessage);
                return;

            case MessageType.Tracing:
                JsonSerializer.Serialize(writer, (TracingMessage)value, KnownSubsystemsBaseContext.Default.TracingMessage);
                return;
        }
        throw new NotImplementedException($"Unknown message {value}");
    }
}
