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
        public string mdtrt_cert_type { get; set; }

        public string mdtrt_cert_no { get; set; }

        public string card_sn { get; set; }

        public DateTime begntime { get; set; }

        public string psn_cert_type { get; set; }

        public string psn_name { get; set; }

    }         
}
