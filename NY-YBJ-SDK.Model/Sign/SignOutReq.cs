using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class SignOutReq
    {
        public DateTime sign_time { get; set; }

        public string sign_no { get; set; }
    }


    public class SignOutResp
    {

        public DateTime sign_time { get; set; }
        
    }
}
