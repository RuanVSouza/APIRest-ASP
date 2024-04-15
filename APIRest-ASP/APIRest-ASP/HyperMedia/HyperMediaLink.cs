using System.Text;

namespace APIRest_ASP.HyperMedia
{
    public class HyperMediaLink
    {
        public string Rel {  get; set; }    
        private string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2f", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string href; //somente para manipular internamente  
        public string Type {  get; set; }    
        public string Action { get; set; }
    }
}
