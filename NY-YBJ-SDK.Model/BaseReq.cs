using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY_YBJ_SDK.Model
{
    public class BaseReq
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        public string infno { get; set; }

        /// <summary>
        /// 发送方报文ID
        /// (12)+时间(14)+顺序号(4)
        /// 时间格式：yyyyMMddHHmmss
        /// </summary>
        public string msgid { get; set; }

        /// <summary>
        /// 就医地医保区划
        /// </summary>
        public string mdtrtarea_admvs { get; set; }

        /// <summary>
        /// 参保地医保区划
        /// </summary>
        public string insuplc_admdvs { get; set; }

        /// <summary>
        /// 接收方系统代码
        /// </summary>
        public string recer_sys_code { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string dev_no { get; set; }

        /// <summary>
        /// 设备安全信息
        /// </summary>
        public string dev_safe_info { get; set; }

        /// <summary>
        /// 数字签名信息
        /// </summary>
        public string cainfo { get; set; }


        /// <summary>
        /// 签名类型
        /// </summary>
        public string signtype { get; set; }

        /// <summary>
        /// 接口版本号
        /// </summary>
        public string infver { get; set; }

        /// <summary>
        /// 经办人类别
        /// </summary>
        public string opter_type { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string opter { get; set; }

        /// <summary>
        /// 经办人姓名
        /// </summary>
        public string opter_name { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime inf_time { get; set; }

        /// <summary>
        /// 定点医药机构编号
        /// </summary>
        public string fixmedins_code { get; set; }

        /// <summary>
        /// 定点医药机构名称
        /// </summary>
        public string fixmedins_name { get; set; }

        /// <summary>
        /// 交易签到流水号
        /// </summary>
        public string sign_no { get; set; }

        /// <summary>
        /// 交易输入
        /// </summary>
        
        public dynamic input { get; set; }
    }
}
