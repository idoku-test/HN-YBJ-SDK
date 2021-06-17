using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class SignInReq
    {

        public  SignIn signIn { get; set; }
        
    }

    public class SignIn
    {
        public string opter_no { get; set; }

        public string mac { get; set; }

        public string ip { get; set; }
    }

    public class SignInResp
    {
        public SignInOut signinoutb { get; set; }
     
    }


    public class SignInOut
    {
        public DateTime sign_time { get; set; }
        public string sign_no { get; set; }

    }
}
