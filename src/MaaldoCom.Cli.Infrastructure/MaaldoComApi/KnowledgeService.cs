namespace MaaldoCom.Cli.Infrastructure.MaaldoComApi;

public class KnowledgeService(IMaaldoApiClient apiClient) : BaseService(apiClient), IKnowledgeService
{
    public async Task<IEnumerable<Knowledge>> ListKnowledgeAsync()
        => (await ApiClient.ListKnowledge()).ToModels();

    public async Task<Knowledge> GetRandomKnowledgeAsync()
    {
        var x = await ApiClient.GetRandomKnowledge();
        var y = x.ToModel();

        return y;
    }
}
