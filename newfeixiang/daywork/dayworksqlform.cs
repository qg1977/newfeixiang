using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.daywork
{
    class dayworksqlform
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
        public static DataTable dayworksql_form(string pro3begin, string pro3end, string pro3monthbegin, string pro3monthend, DateTime data1, DateTime data2, int cxfs1
               , int ph1, string workid, string perid, string pprid, string proid, int proce1, string proceid, string waresbid)
        {
            DataTable dt = null;

            dt = daywork_one.dayworksql( pro3begin,  pro3end,  pro3monthbegin,  pro3monthend,  data1,  data2,  cxfs1
               ,  ph1,  workid,  perid,  pprid,  proid,  proce1,  proceid,  waresbid);


            var query = from t in dt.AsEnumerable()
                        group t by new { t1 = t.Field<Int64>("月产品ID"), t2 = t.Field<decimal>("系统工序号"), t3 = t.Field<string>("工序号"), t4 = t.Field<Int64>("姓名ID"), t5 = t.Field<string>("月份") } into m
                        select new
                        {
                            月产品ID = m.Key.t1,
                            系统工序号 = m.Key.t2,
                            工序号 = m.Key.t3,
                            姓名ID = m.Key.t4,
                            月份 = m.Key.t5,
                            完工数 = m.Sum(n => n.Field<decimal>("完工数")),
                            工废 = m.Sum(n => n.Field<decimal>("工废")),
                            料废 = m.Sum(n => n.Field<decimal>("料废")),
                            机废 = m.Sum(n => n.Field<decimal>("机废")),
                            调试废品 = m.Sum(n => n.Field<decimal>("调试废品")),
                            合格数 = m.Sum(n => n.Field<decimal>("合格数")),
                            工时 = m.Sum(n => n.Field<decimal>("工时")),
                            班次 = "班次：" + m.Count().ToString() + "个"
                            //house = m.First().Field<string>("house"),
                            //rowcount = m.Count()
                        };
            DataTable dtx = Cs_Datatable.ToDataTable(query.ToList());

            DataRow dr2 = null;
            foreach (DataRow row in dtx.Rows)
            {
                dr2 = dt.NewRow();
                dr2["ID"] = 0;
                dr2["月份ID"] = row["月份"];
                dr2["月产品ID"] = row["月产品ID"];
                dr2["系统工序号"] = row["系统工序号"];
                dr2["姓名ID"] = row["姓名ID"];
                dr2["完工数"] = row["完工数"];
                dr2["工废"] = row["工废"];
                dr2["料废"] = row["料废"];
                dr2["机废"] = row["机废"];
                dr2["调试废品"] = row["调试废品"];
                dr2["合格数"] = row["合格数"];
                dr2["工时"] = row["工时"];
                dr2["日期"] = row["班次"];
                dr2["总排序"] = 2;
                dr2["规格"] = "合计：";
                dt.Rows.Add(dr2);
            }

            DataView dataView = dt.DefaultView;
            DataTable dt_Distinct = dataView.ToTable(true, "月份ID", "月产品ID", "系统工序号", "姓名ID");//注：其中ToTable（）的第一个参数为是否DISTINCT
            foreach (DataRow row in dt_Distinct.Rows)
            {
                dr2 = dt.NewRow();
                dr2["月份ID"] = row["月份ID"];
                dr2["月产品ID"] = row["月产品ID"];
                dr2["系统工序号"] = row["系统工序号"];
                dr2["姓名ID"] = row["姓名ID"];
                dr2["总排序"] = 3;
                dt.Rows.Add(dr2);
            }
            dt.DefaultView.Sort = "月份ID,月产品ID,系统工序号,姓名ID,总排序";
            return dt;
        }
        #endregion

        //结束
    }
}
