namespace MaaldoCom.Cli.Contracts.MediaMetaData;

public interface IMediaMetaDataCreator
{
    Task CreateMediaMetaDataFilesAsync(string mediaAlbumFolderPath, CancellationToken cancellationToken);
}
