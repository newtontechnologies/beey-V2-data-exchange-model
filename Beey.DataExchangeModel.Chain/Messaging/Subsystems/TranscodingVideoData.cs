namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class TranscodingVideoData : SubsystemData<TranscodingVideoData>
{
    public string Record { get; init; } = default!;
}
