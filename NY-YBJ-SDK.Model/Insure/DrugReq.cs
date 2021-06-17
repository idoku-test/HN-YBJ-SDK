using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NY_YBJ_SDK.Model.Insure
{
    public class DrugReq
    {
        public DrugInfo druginfo { get; set; }

        public List<DrugDetail> drugdetail { get; set; }
    }

    public class DrugInfo
    {
        public string psn_no { get; set; }

    }


    public class DrugDetail
    {
        public string feedetl_sn { get; set; }
    }




}
