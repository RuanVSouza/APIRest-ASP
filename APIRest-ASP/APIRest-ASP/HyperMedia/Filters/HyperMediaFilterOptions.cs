using APIRest_ASP.Hypermedia.Abstract;

namespace APIRest_ASP.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set;} = new List<IResponseEnricher>();

    }
}
