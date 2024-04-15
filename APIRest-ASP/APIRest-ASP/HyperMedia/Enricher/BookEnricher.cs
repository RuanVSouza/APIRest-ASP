using APIRest_ASP.Data.VO;
using APIRest_ASP.HyperMedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace APIRest_ASP.HyperMedia.Enricher
{
    public class BookEnricher : ContentResponseEnricher<BookVO>
    {

        private readonly object _lock = new object();

        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/book/v1";
            string link = getLink(content.Id, urlHelper, path);
            
            //Verbo GET
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });
            
            //Verbo POST
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost,
            });

            //Verbo PUT
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut,
            });
            return null;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2f", "/").ToString();
            }
        }
    }
}
