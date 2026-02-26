namespace MaaldoCom.Cli.Infrastructure.MaaldoComApi;

public class SystemService(IMaaldoApiClient apiClient) : BaseService(apiClient), ISystemService
{

}
