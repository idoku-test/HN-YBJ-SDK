using NY_YBJ_SDK.Model;
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

        private const string GET_ORG_INFO = "1201";
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

        /// <summary>
        /// 1201-获取机构信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public dynamic GetOrzInfo(UserInfoReq req)
        {
            var url = base.GenApiUrl(GET_ORG_INFO);
            base.PreAction(GET_ORG_INFO);
            return Post(url, req);
        }



    }
}
