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

/*
 * 人员信息输入:
 {
	"infno": "1101",
	"msgid": "H00000000001202001041235391234",
	"insuplc_admdvs": "100000",
	"mdtrtarea_admvs": "100000",
	"recer_sys_code": "MBS_LOCAL",
	"dev_no": "",
	"dev_safe_info": "",
	"cainfo": "",
	"infver": "V1.0",
	"opter_type": "1",
	"opter": "01",
	"opter_name": "张三",
	"inf_time": "2020-01-04 12:35:39",
	"fixmedins_code": "100001",
	"fixmedins_name": "第一人民医院",
	"sign_no": "79faf82271944fe38c4f1d99be71bc9c",
	"input": {
		"data": {
			"psn_cert_type": "2",
			"certno": "510000202001010000",
			"psn_name": "李四",
			"begntime": "2020-01-01"
		}
	}
}
 *人员信息输出
 {
	"infcode": "1",
	"inf_refmsgid": "000000202001041235391234567890",
	"refmsg_time": "20200201133411352",
	"respond_time": "20200202133731456",
	"err_msg": "",
	"output": {
		"baseinfo": {
			"psn_no": "131000202001001",
			"psn_cert_type": "2",
			"certno": "510000202001010000",
			"psn_name": "李四",
			"gend": "1",
			"naty": "01",
			"brdy": "2020-01-01",
			"age": 18
		},
		"insuinfo": {
			"psn_insu_rlts_id": "133241523001001",
			"balc": 5000,
			"insutype": "310",
			"psn_type": "1001",
			"cvlserv_flag": "0",
			"insu_admdvs": "131002",
			"emp_name": "测试单位"
		},
		"idetinfo": [{
				"psn_idet_type": "1",
				"psn_type_lv": "1",
				"memo": "",
				"begntime": "2020-01-01 00:00:00",
				"endtime": ""
			},
			{
				"psn_idet_type": "2",
				"psn_type_lv": "1",
				"memo": "",
				"begntime": "2020-01-01 00:00:00",
				"endtime": ""
			}
		]
	}
}
     */
