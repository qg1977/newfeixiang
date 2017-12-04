using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.daywork
{
    public static class daywork_one
    {
        #region
        // pro3begin和pro3end表示月份
        // pro3monthbegin和pro3monthend表示工资月份
        // cxfs1为1表示按月份查询，为2表示按工资月份查询
        //ph1表示票号
        //workid表示车间ID
        //perid表示员工ID
        //pprid表示产品ID
        //proid表示月产品ID
        //proce1表示系统工序号
        //proceid表示工序ID
        //waresbid表示设备ID
        //data1表示日期
        //data2表示结束日期
        //ppridall表示所查询的所有产品的ID
        public static DataTable dayworksql(string pro3begin,string pro3end,string pro3monthbegin,string pro3monthend, DateTime data1, DateTime data2, int cxfs1
               ,int ph1,string workid,string perid,string pprid,string proid,int proce1,string proceid,string waresbid)
        {
            DataTable dt=null;

            string sqlstring= "select ID,月产品ID,票号,姓名 姓名ID,姓名=(select ISNULL(姓名,'') from person where ID=days.姓名),车间名称=(select 公司名称 from customer where ID=days.车间)"
                   + ",产品ID=ISNULL((select 产品ID from productionmonth where ID=days.月产品ID),'0')"
                   + ",产品名称=(select 产品名称 from pproduct where ID=(select 产品ID from productionmonth where ID=days.月产品ID))"
                   + ",规格=(select 规格 from pproduct where ID=(select 产品ID from productionmonth where ID=days.月产品ID))"
                   + ",设备名称=(select 名称 from warehouse where ID=days.设备ID),型号=(select 规格 from warehouse where ID=days.设备ID)"
                    + ",工序ID,工序号 系统工序号,工序号=ISNULL((select 车间工序号 from process where ID=days.工序ID),'')"
                   + ",完工数,工废,料废,机废,调试废品,(完工数-工废-料废-机废-调试废品) 合格数,days.工时,convert(varchar(10),日期,120) 日期,月份,工资月份,计算月份,属性,纳入成本"
                    + ",操作员 操作员ID,操作员=ISNULL((select 姓名 from person where ID=days.操作员),'')"
                    + ",班次 班次ID,班次=ISNULL((select 班次 from wclass where ID=days.班次),'')"
                    + ",ISNULL(压铸工,'0') 压铸工ID,压铸工=ISNULL((select 姓名 from person where ID=days.压铸工),'')"
                    + ",生产状态=(case when 属性=1 then '月初数' when 属性=3 then '只计算工资' when 属性=4 then '只计算数量' when 属性=6 then '二次生产' else '' end)"
                    + ",ISNULL(批次号,'') 批次号"
                    +",工序号 工序号ID,月份 月份ID,1 总排序"
                   + " from daywork days where 属性 in (0,3,6,4,7) and  确定=5" ;
            switch(cxfs1)
            {
                case 1:
                    if (pro3begin.NotIsNullOrEmpty())
                    { sqlstring=sqlstring+ "and 月份 >= '"+pro3begin+"'"; }
                    if (pro3end.NotIsNullOrEmpty())
                    { sqlstring = sqlstring + "and 月份 <= '" + pro3end + "'"; }
                    break;
                case 2:
                    if (pro3monthbegin.NotIsNullOrEmpty())
                    { sqlstring = sqlstring + "and 工资月份 >= '" + pro3monthbegin + "'"; }
                    if (pro3monthend.NotIsNullOrEmpty())
                    { sqlstring = sqlstring + "and 工资月份 <= '" + pro3monthend + "'"; }
                    break;
                case 3:
                    
                     sqlstring = sqlstring + "and 日期 >= '" + data1.ToShortDateString().ToString() + "'"; 
                     sqlstring = sqlstring + "and 日期 <= '" + data2.ToShortDateString().ToString() + "'"; 
                    break;
            }
            if (ph1>0)
            { sqlstring = sqlstring + " and 票号=" + ph1.ToString(); }
            if (workid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 车间 in (" + workid.Trim() + ")"; }
            if (perid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 姓名 in (" + perid.Trim() + ")"; }
            if (pprid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 产品ID in (" + pprid.Trim() + ")"; }
            if (proid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 月产品ID in (" + proid.Trim() + ")"; }
            if (proce1>0)
            { sqlstring = sqlstring + " and 工序号=" + proce1.ToString(); }
            if (proceid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 工序ID in (" + proceid.Trim() + ")"; }
            if (waresbid.NotIsNullOrEmpty())
            { sqlstring = sqlstring + " and 设备ID in (" + waresbid.Trim() + ")"; }

            dt=return_select(sqlstring);

            dt.DefaultView.Sort = "票号";

            return dt;
        }
        #endregion


//结束
    }
}


