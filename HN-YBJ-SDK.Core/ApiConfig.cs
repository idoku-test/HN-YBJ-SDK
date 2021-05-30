using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public  class ApiConfig
    {
        public static readonly string _api_url = ConfigurationManager.AppSettings["api_url"];
        public static readonly string _api_app_code = ConfigurationManager.AppSettings["api_app_code"];

        public static readonly string _api_app_url = string.Format("{0}{1}/", _api_url, _api_app_code);

        public static readonly string _api_version = ConfigurationManager.AppSettings["api_version"];
        public static readonly string _api_access_key = ConfigurationManager.AppSettings["api_access_key"];
        public static readonly string _api_secreKey = ConfigurationManager.AppSettings["api_secreKey"];
    }
}
