using System.Text.Json.Serialization;
using Backend.Messaging.Chain;

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
}
