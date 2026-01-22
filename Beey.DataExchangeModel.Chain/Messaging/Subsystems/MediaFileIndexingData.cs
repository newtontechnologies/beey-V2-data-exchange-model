namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class MediaFileIndexingData : SubsystemData<MediaFileIndexingData>
{
    public enum DataEnum { AudioAvailable, VideoAvailable, HeaderAvailable, Record }

    public DataEnum Data { get; set; }
    public string Record { get; set; }
}
