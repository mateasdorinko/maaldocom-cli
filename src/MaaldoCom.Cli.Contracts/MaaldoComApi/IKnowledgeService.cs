namespace MaaldoCom.Cli.Contracts.MaaldoComApi;

public interface IKnowledgeService
{
    Task<IEnumerable<Knowledge>> ListKnowledgeAsync();
    Task<Knowledge> GetRandomKnowledgeAsync();
}
