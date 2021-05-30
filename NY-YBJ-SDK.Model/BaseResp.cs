using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class BaseResp
    {
        public int infcode { get; set; }

        public string inf_refmsgid { get; set; }

        public string refmsg_time { get; set; }

        public string respond_time { get; set; }

        public string err_msg { get; set; }

        public string output { get; set; }

    }
}
