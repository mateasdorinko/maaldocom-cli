namespace MaaldoCom.Cli.Infrastructure.MaaldoComApi;

public interface IApiClientFactory
{
    IMaaldoApiClient CreateClient(ApiEnvironment environment);
    IKnowledgeService GetKnowledgeService();
    IMediaAlbumService GetMediaAlbumService();
    ISystemService GetSystemService();
    ITagService GetTagService();
}
