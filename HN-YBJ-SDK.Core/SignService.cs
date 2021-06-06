using NY_YBJ_SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HN_YBJ_SDK.Core
{
    public class SignService : ServiceBase
    {
        private const string SIGN_IN = "9001";

        private const string SIGN_OUT = "9002";


        public SignService()
        {

        }

        /// <summary>
        /// 9001-签到
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SignInResp SignIn(SignInReq req)
        {
            var url = base.GenApiUrl(SIGN_IN);
            base.PreAction(SIGN_IN);
            return base.SignIn(url, req);
        }


        /// <summary>
        /// 签出
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SignOutResp SignOut(SignOutReq req)
        {
            var url = base.GenApiUrl(SIGN_OUT);
            base.PreAction(SIGN_OUT);
            return base.SignOut(url, req);
        }
    }
}
