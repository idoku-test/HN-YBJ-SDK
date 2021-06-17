using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class UserInfoReq
    {
        public UserInfo data { get; set; }
    }           

    public class UserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string mdtrt_cert_type { get; set; }

        public string mdtrt_cert_no { get; set; }

        public string card_sn { get; set; }

        public DateTime begntime { get; set; }

        public string certno { get; set; }

        public string psn_cert_type { get; set; }

        public string psn_name { get; set; }
    }

    public class UserInfoResp
    {
        public BaseInfo baseinfo { get; set; }

        public List<InsuInfo> insuinfo { get; set; }

        public List<IdetInfo> idetinfo { get; set; }
    }

    public class BaseInfo
    {
        public string psn_no { get; set; }
    }

    public class InsuInfo
    {
        public string certno { get; set; }
    }


    public class IdetInfo
    {
        public string psn_idet_type { get; set; }
    }
}
