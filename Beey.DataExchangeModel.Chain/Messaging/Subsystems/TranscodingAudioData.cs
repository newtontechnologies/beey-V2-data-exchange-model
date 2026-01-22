namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class TranscodingAudioData : SubsystemData<TranscodingAudioData>
{
    public string Record { get; init; } = default!;
}
