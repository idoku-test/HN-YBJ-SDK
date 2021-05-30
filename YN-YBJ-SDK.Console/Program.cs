using FD.Util.Network;
using HN_YBJ_SDK.Core;
using NY_YBJ_SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YN_YBJ_SDK.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseReq req = new BaseReq();


            req.infon = "1001";

            //msgid 
            var ori_code = "000000000001";
            req.msgid = string.Format("{0}{1}{2}", ori_code, DateTime.Now.ToString("yyyyMMddHHmmss"),1234);


            req.mdtrtarea_admvs = "10000";


            req.insuplc_admdvs = "10000";


            req.recer_sys_code = "MBS_LOCAL";
           
            req.dev_no = "";
            req.dev_safe_info = "";

            //
            req.cainfo = "";
            req.signtype = "";

            req.infver = "";

            req.opter_type = "1";

            req.opter = "01";

            req.opter_name = "张三";

            req.inf_time = DateTime.Now;

            //infno->sign_no
            SignService signService = new SignService();
            var signReq = new SignInReq()
            {
                ip = IPHelper.GetLocalIPAddress(),
                mac = MacHelper.GetMacAddress(),
                opter_no = "doku"
            };
            var infno = signService.SignIn(signReq);

            req.sign_no = infno.sign_no;
            
            






        }
    }
}
