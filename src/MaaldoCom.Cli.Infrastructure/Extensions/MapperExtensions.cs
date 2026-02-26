using ApiModels = MaaldoCom.Cli.Infrastructure.MaaldoComApi;

namespace MaaldoCom.Cli.Infrastructure.Extensions;

public static class MapperExtensions
{
    extension<TModel>(TModel model) where TModel : BaseModel
    {
        private TModel MapFromApi<TApiModel>(TApiModel apiModel) where TApiModel : ApiModels.BaseModel
        {
            model.Id = apiModel.Id;
            return model;
        }
    }

    public static IEnumerable<Knowledge> ToModels(this IEnumerable<ApiModels.GetKnowledgeResponse> apiModels)
        => apiModels.Select(m => m.ToModel()).ToList();

    public static Knowledge ToModel(this ApiModels.GetKnowledgeResponse apiModel)
    {
        var model = new Knowledge().MapFromApi(apiModel);
        model.Title = apiModel.Title;
        model.Quote = apiModel.Quote;

        return model;
    }
}
