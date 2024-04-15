using Microsoft.AspNetCore.Mvc.Filters;

namespace APIRest_ASP.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
