using APIRest_ASP.Data.VO;
using APIRest_ASP.HyperMedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace APIRest_ASP.HyperMedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {

        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person";
            string link = getLink(content.Id, urlHelper, path);
            
            //Verbo GET
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });
            
            //Verbo POST
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost,
            });

            //Verbo PUT
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut,
            });

            //Verbo DELETE
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int",
            });

            return Task.CompletedTask;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2f", "/").ToString();
            }
        }
    }
}
