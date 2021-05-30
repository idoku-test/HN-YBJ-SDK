using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class SignInReq
    {
        public string opter_no { get; set; }

        public string mac { get; set; }

        public string ip { get; set; }

    }

    public class SignInResp
    {
        public DateTime sign_time { get; set; }
        public string sign_no { get; set; }
    }
}
