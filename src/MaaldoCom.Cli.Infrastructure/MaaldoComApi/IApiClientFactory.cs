namespace MaaldoCom.Cli.Infrastructure.MaaldoComApi;

public interface IApiClientFactory
{
    IMaaldoApiClient CreateClient(ApiEnvironment environment);
}
