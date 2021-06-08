using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class BaseResp<T>
    {
        /// <summary>
        /// 交易状态码
        /// </summary>
        public int infcode { get; set; }

        /// <summary>
        /// 接收方报文ID
        /// </summary>
        public string inf_refmsgid { get; set; }

        /// <summary>
        /// 接收报文时间
        /// </summary>
        public string refmsg_time { get; set; }

        /// <summary>
        /// 响应报文时间
        /// </summary>
        public string respond_time { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string err_msg { get; set; }

        /// <summary>
        /// 交易输出
        /// </summary>
        public T output { get; set; }

    }
}
