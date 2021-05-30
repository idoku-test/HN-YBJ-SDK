using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public class ApiRequest
    {
        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string,string> Params { get; set; }

        public Encoding ContentEncoding { get; set; }

        public HttpRequestMessage ApiGenRequest { get; set; }

        public HttpMethod Method { get; set; }

        public Uri Uri { get; set; }

        private ApiRequest()
        {

            Headers = new Dictionary<string, string>();
            Params = new Dictionary<string, string>();
            ContentEncoding = Encoding.UTF8;
            Method = HttpMethod.Get;
        }

        public ApiRequest(string url):this()
        {
            Uri = new Uri(url);
        }


        public HttpRequestMessage Request(HttpRequestMessage request)
        {
            request = new HttpRequestMessage()
            {
                RequestUri = Uri,
                Method = Method,
            };

            foreach (var header in Headers)
            {
                request.Headers.Add(header.Key, header.Value);
               
            }
        }

    }
}
