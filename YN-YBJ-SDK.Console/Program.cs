using FD.Util.Json;
using FD.Util.Network;
using HN_YBJ_SDK.Core;
using NY_YBJ_SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YN_YBJ_SDK.App
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine(".....请求测试......");
			try
			{


				BaseReq req = new BaseReq();

				req.infno = "9001";
				//msgid 
				var ori_code = "H43072600035";
				req.msgid = string.Format("{0}{1}{2}", ori_code, DateTime.Now.ToString("yyyyMMddHHmmss"), new Random().Next(1000, 9999));
				req.mdtrtarea_admvs = "430726";
				req.insuplc_admdvs = "430726";
				req.recer_sys_code = "MBS_LOCAL";
				req.dev_no = "";
				req.dev_safe_info = "";
				req.cainfo = "";
				req.signtype = "SM2";
				req.infver = "V1.0";
				req.opter_type = "1";
				req.opter = "999999";
				req.opter_name = "系统管理员";
				req.inf_time = DateTime.Now;
				req.fixmedins_code = "H43072600035";
				req.fixmedins_name = "石门县人民医院";
				req.sign_no = "12345678";

				//infno->sign_no
				SignService signService = new SignService();
				Console.WriteLine("时间戳:" + Math.Floor(signService.GetTime(DateTime.Now)).ToString());
				signService.BaseReq = req;
				var signReq = new SignInReq()
				{
					signIn = new SignIn
					{
						ip = IPHelper.GetLocalIPAddress(),
						mac = MacHelper.GetMacAddress(),
						opter_no = "999999"
					}
				};

				Console.WriteLine("...执行签到.....");
				var infno = signService.SignIn(signReq);
				Console.WriteLine("签到返回:");
				var infno_resp = JsonHelper.Instance.Serialize(infno);
				Console.WriteLine(infno_resp);
				Console.WriteLine("...签到执行完毕....");
				//user_info
				BaseInformationService infoService = new BaseInformationService();
				var userReq = new UserInfoReq()
				{
					 data = new UserInfo
					 {
						 mdtrt_cert_type = "02",
						 psn_cert_type = "02",
						 mdtrt_cert_no = "430703199403089811",
						 certno = "430703199403089811",
						 psn_name = "邓枫雨",
						 begntime = DateTime.Now,
					 }
				};
				req.sign_no = infno.output.signinoutb.sign_no;
				req.infno = "1101";
				infoService.BaseReq = req;
				Console.WriteLine("...执行获取人员信息.....");
				var user = infoService.GetUserInfo(userReq);
				Console.WriteLine("人员身份证:" + user.output.baseinfo.psn_no);
				
				Console.WriteLine("...执行获取人员信息完毕.....");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.Read();
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
