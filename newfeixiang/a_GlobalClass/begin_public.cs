using System.Data;

using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang.a_GlobalClass
{
    class begin_public
    {

        public static void begin_public_other()
        {
            string sqlstring = "select MAX(months) months from allmax";
            DataTable dt = return_select(sqlstring);
            begin_class.allmax = dt.Rows[0]["months"].ToString();
            begin_class.public_pro3begin = begin_class.allmax;
            begin_class.public_pro3end = begin_class.allmax;


            sqlstring = "select ID from customer where 公司名称 = '丹江口市飞翔汽车零部件有限公司' and 删除 = 0";
            dt = return_select(sqlstring);
            begin_class.cusfxidall = "0";
            if (dt.Rows.Count > 0)
            { begin_class.cusfxidall = dt.Rows[0]["ID"].ToString(); }
        }


        public static void begin_public_1()
        {
            string sqlstring = "select * from outmoneylx where 删除=0";
            DataTable dt = return_select(sqlstring);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["考核名称"].ToString().Trim();

                if (khname == "考勤扣款") { begin_class.outmoneylxid1 = ouid; }
                if (khname == "课时工资") { begin_class.outmoneylxid2 = ouid; }
                if (khname == "其它补款") { begin_class.outmoneylxid3 = ouid; }
                if (khname == "事假扣款") { begin_class.outmoneylxid4 = ouid; }
                if (khname == "车间补款") { begin_class.outmoneylxid5 = ouid; }
                if (khname == "旷工扣款") { begin_class.outmoneylxid6 = ouid; }
                if (khname == "其它扣款") { begin_class.outmoneylxid7 = ouid; }
                //if (khname == "五项检查") { begin_class.outmoneylxid8 = ouid; }
                if (khname == "特殊工补贴") { begin_class.outmoneylxid9 = ouid; }
                if (khname == "夜班补贴") { begin_class.outmoneylxid10 = ouid; }
                //if (khname == "内废考核") { begin_class.outmoneylxid11 = ouid; }
                //if (khname == "外废扣款") { begin_class.outmoneylxid12 = ouid; }
                if (khname == "车间扣款") { begin_class.outmoneylxid15 = ouid; }
                if (khname == "绩效工资") { begin_class.outmoneylxid16 = ouid; }
                if (khname == "其它补贴") { begin_class.outmoneylxid17 = ouid; }
                if (khname == "福利扣款") { begin_class.outmoneylxid19 = ouid; }
                if (khname == "劳务员工补贴") { begin_class.outmoneylxid26 = ouid; }

                if (khname == "教职工基本工资") { begin_class.outmoneysfglid1 = ouid; }
                if (khname == "劳务工资") { begin_class.outmoneysfglid3 = ouid; }
                if (khname == "教职工福利工资") { begin_class.outmoneysfglid5 = ouid; }
                if (khname == "劳务福利工资") { begin_class.outmoneysfglid6 = ouid; }
                if (khname == "派遣员工基本工资") { begin_class.outmoneysfglid7 = ouid; }
                if (khname == "派遣员工福利工资") { begin_class.outmoneysfglid8 = ouid; }
                if (khname == "残疾人基本工资") { begin_class.outmoneysfglid9 = ouid; }
            }
        }


        public static void begin_public_2()
        {
            string sqlstring = "select ID,考核名称 from wtemp";
            DataTable dt = return_select(sqlstring);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["考核名称"].ToString().Trim();

                if (khname == "毛坯考核") { begin_class.wtempid1 = ouid; }
                if (khname == "钢材考核") { begin_class.wtempid2 = ouid; }
                if (khname == "其它辅材") { begin_class.wtempid3 = ouid; }
                if (khname == "合金考核") { begin_class.wtempid4 = ouid; }

            }
        }


        public static void begin_public_5()
        {
            string sqlstring = "select ID, 方式 from wmode where 方式 in ('入库','出库')";
            DataTable dt = return_select(sqlstring);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["方式"].ToString().Trim();

                if (khname == "出库") { begin_class.wmodeid2 = ouid; }
                if (khname == "入库") { begin_class.wmodeid4 = ouid; }

            }
        }


        public static void begin_public_6()
        {
            string sqlstring = "select ID,分公司名称 from wfiliale where 删除=0";
            DataTable dt = return_select(sqlstring);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["分公司名称"].ToString().Trim();

                if (khname == "企业") { begin_class.wfilialeid1 = ouid; begin_class.wfilialename1 = khname; }
                if (khname == "学校") { begin_class.wfilialeid2 = ouid; begin_class.wfilialename2 = khname; }
                if (khname == "劳务公司") { begin_class.wfilialeid3 = ouid; begin_class.wfilialename3 = khname; }
                if (khname == "崇文教育") { begin_class.wfilialeid4 = ouid; begin_class.wfilialename4 = khname; }
                if (khname == "压铸有色") { begin_class.wfilialeid5 = ouid; begin_class.wfilialename5 = khname; }
                if (khname == "食堂宾馆") { begin_class.wfilialeid6 = ouid; begin_class.wfilialename6 = khname; }
                if (khname == "飞创电子") { begin_class.wfilialeid7 = ouid; begin_class.wfilialename7 = khname; }
            }
        }


        public static void begin_public_11()
        {
            string sqlstring = "select ISNULL(ID,'0') ID,ISNULL(类型名称,'') 类型名称 from wcodingtype where 删除=0";
            DataTable dt = return_select(sqlstring);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["类型名称"].ToString().Trim();

                if (khname == "科目编码") { begin_class.wcoding_typeid1 = ouid; }
                if (khname == "公司编码") { begin_class.wcoding_typeid2 = ouid;  }
                if (khname == "部门编码") { begin_class.wcoding_typeid4 = ouid;  }
                if (khname == "文件编码") { begin_class.wcoding_typeid7 = ouid; }
              }
        }


        public static void begin_public_13()
        {
            string sqlstring = "select ID,凭证类型 from wcodingtypepz where 删除=0 and 科目ID='" +begin_class.wcoding_typeid1 + "'";
            DataTable dt = return_select(sqlstring);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ouid = dt.Rows[i]["ID"].ToString().Trim();
                string khname = dt.Rows[i]["凭证类型"].ToString().Trim();

                if (khname == "收款凭证") { begin_class.wcodingtypepzid1 = ouid; begin_class.wcodingtypepzname1 = khname; }
                if (khname == "付款凭证") { begin_class.wcodingtypepzid2 = ouid; begin_class.wcodingtypepzname2 = khname; }
                if (khname == "转帐凭证") { begin_class.wcodingtypepzid3 = ouid; begin_class.wcodingtypepzname3 = khname; }
            }
        }



        //结束
    }
}
