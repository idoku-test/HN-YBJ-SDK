using FD.Util;
using FD.Util.Crypto;
using FD.Util.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public abstract class ServiceBase
    {
        private string _api_url = ConfigurationManager.AppSettings["api_url"];
        private  string _api_app_code = ConfigurationManager.AppSettings["api_app_code"];

        private  string _api_version = ConfigurationManager.AppSettings["api_version"];
        private  string _api_access_key = ConfigurationManager.AppSettings["api_access_key"];
        private  string _api_secreKey = ConfigurationManager.AppSettings["api_secreKey"];

        static HttpHelper _httpHelper = new HttpHelper(ConfigurationManager.AppSettings["api_url"]);

        protected string Post(string api_name, Dictionary<string, string> param)
        {
            try
            {
              

                var api = string.Format("/{0}/{1}", _api_app_code, api_name);
                return _httpHelper.Post(param, api);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="api_name"></param>
        /// <returns></returns>
        protected string SignCalc(string api_name)
        {
            var param = new Dictionary<string, string> {
              {"_api_access_key", _api_access_key},
                   {"_api_name", api_name},
                        {"_api_timestamp", Math.Round(this.GetTime()).ToString()},
                             {"_api_version", _api_version},
            };
            

            var sign = HashHelper.HmacSha1(ParseQueryString(param), Encoding.UTF8.GetBytes(_api_secreKey));

            return Convert.ToBase64String(sign.HexStringToHex());
        }

        private decimal GetTime()
        {
            var time = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1));
            return (int)(time.TotalMilliseconds + 0.5);
        }

        /// <summary>
        ///     query dictionary to string
        /// </summary>
        /// <param name="querys"></param>
        /// <returns></returns>
        private string ParseQueryString(Dictionary<string, string> querys)
        {
            if (querys.Count == 0)
                return "";
            return querys
                .Select(pair => pair.Key + "=" + pair.Value)
                .Aggregate((a, b) => a + "&" + b);
        }

    }

}
