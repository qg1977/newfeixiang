using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.customercoding
{
    class customercodingsubbill
    {
        /// 生成一个凭证的汇总表
        /// </summary>   
        /// <param name="pro3begin">开始月份</param>  
        /// <param name="pro3end">结束月份</param>  
        /// <param name="pzsubid">查询的财务科目ID</param>   
        /// <param name="monthjytt">为为表示查询一般的业务流程，为1表示是为了扎帐进行查询，这时accountacc的查询凭证信息隐藏模式应该为3</param>  
        /// <param name="wfilialeid">是“企业”还是“学校”</param>  
        /// <returns></returns>   
        private DataTable customercodingsubbillother(string pro3begin, string pro3end, string pzsubid, int monthjytt,string wfilialeid)
        {
            DataTable dt_subbill = null;
            WaitFormService.Show();
            WaitFormService.SetText("正在查询凭证信息,请稍候…………");
            try
            {
                DataTable dt;
                DataRow dt_row = null;//增加拷贝记录时用到

                accountacc.accountacc_one accone = new accountacc.accountacc_one();
                string subfialtemp1 = "";
                if (monthjytt==1)
                { subfialtemp1 = "3"; }
                else
                { subfialtemp1 = "5"; }
                DataTable dt_subbillx1 = accone.accountaccone(pro3begin, pro3end, "", pzsubid, "", "", "", "", subfialtemp1, "", "", "", "1");

                dt_subbill = dt_subbillx1.DefaultView.ToTable(true, "ID", "票据号", "凭证号", "附件数", "日期", "月份", "状态ID", "状态", "类型ID", "凭证类型", "属性ID", "属性中文"
                    , "主管ID", "财务主管", "制单ID", "制单", "审核ID", "审核", "记帐ID", "记帐", "分ID"
                    , "引用属性", "公司ID", "员工ID", "产品ID"
                     , "摘要", "科目ID", "反科目ID", "次科目借贷", "借贷方向", "数量");
                dt_subbill.Clear();//清除表中的所有记录
                DataColumn dc1 = new DataColumn("科目名称", Type.GetType("System.String"));
                dt_subbill.Columns.Add(dc1);
                dc1 = new DataColumn("借方金额", Type.GetType("System.Decimal"));
                dt_subbill.Columns.Add(dc1);
                dc1 = new DataColumn("贷方金额", Type.GetType("System.Decimal"));
                dt_subbill.Columns.Add(dc1);
                dc1 = new DataColumn("排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 1;
                dt_subbill.Columns.Add(dc1);


                DataRow[] row_1 = dt_subbillx1.Select("借贷方向=" + 1);
                for(int i=0;i<row_1.Count();i++)
                {
                    dt_row = dt_subbill.NewRow();

                    dt_subbill.Rows.Add(dt_row);
                }
            }

            catch (Exception ex)
            {
                ex.errormess();
            }

            WaitFormService.Close();
            return dt_subbill;
        }

//结束
    }
}
