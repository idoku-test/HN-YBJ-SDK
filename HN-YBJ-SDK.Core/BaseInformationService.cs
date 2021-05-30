using NY_YBJ_SDK.Model;
using FD.Util.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public class BaseInformationService : ServiceBase
    {
        private const string GET_USER_INFO =  "1101";

        public BaseInformationService()
        {

        }


        /// <summary>
        /// 1101-获取用户信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public dynamic GetUserInfo(UserInfoReq req)
        {
            var url = base.GenApiUrl(GET_USER_INFO);
            base.PreAction(GET_USER_INFO);
            return Post(url, req);
        }
        

        
    }
}
