namespace MaaldoCom.Cli.Infrastructure.MaaldoComApi;

public abstract class BaseService(IMaaldoApiClient apiClient)
{
    protected readonly IMaaldoApiClient ApiClient = apiClient;
}

