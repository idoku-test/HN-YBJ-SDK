using FD.Util;
using FD.Util.Crypto;
using FD.Util.Http;
using FD.Util.Json;
using NY_YBJ_SDK.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public  abstract class ServiceBase
    {
        public  readonly string _api_url = ConfigurationManager.AppSettings["api_url"];
        public  readonly string _api_app_code = ConfigurationManager.AppSettings["api_app_code"];

       

        public  readonly string _api_version = ConfigurationManager.AppSettings["api_version"];
        public  readonly string _api_access_key = ConfigurationManager.AppSettings["api_access_key"];
        public  readonly string _api_secreKey = ConfigurationManager.AppSettings["api_secreKey"];

        public string _api_timestamp { get; set; }

        public BaseReq BaseReq { get; set; }

        public Dictionary<string, string> Headers { get; set; }
        
        static HttpHelper _httpHelper = new HttpHelper();        
                
        public ServiceBase()
        {
            _api_timestamp = Math.Round(this.GetTime()).ToString();
            Headers = new Dictionary<string, string>();
        }

        public string GenApiUrl(string api_name)
        {
            return string.Format("{0}{1}/{2}", _api_url, _api_app_code, api_name);
        }

        /// <summary>
        /// 签入
        /// </summary>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        protected SignInResp SignIn(string url, SignInReq req)
        {
            try
            {
                var result = _httpHelper.Post(req, Headers, url);
                return JsonHelper.Instance.Deserialize<SignInResp>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 签出
        /// </summary>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        protected SignOutResp SignOut(string url, SignOutReq req)
        {
            try
            {
                var result = _httpHelper.Post(req, Headers, url);
                return JsonHelper.Instance.Deserialize<SignOutResp>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        protected string Post(string url, object param)
        {
            try
            {            
                return _httpHelper.Post(BaseReq, Headers, url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

        protected void PreAction(string api_name)
        {
            Headers.Add("_api_name", api_name);
            Headers.Add("_api_version", _api_version);
            Headers.Add("_api_access_key", _api_access_key);
            Headers.Add("_api_access_key", SignCalc(api_name));
        }

        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="api_name"></param>
        /// <returns></returns>
        private string SignCalc(string api_name)
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
