using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.wcoding
{
    class wcodingfinance
    {

        /// </summary>得到财务科目的编码的详细信息
        /// <param name="pro3">月份,暂无用</param>  
        /// <param name="typeid">表wcodingtype中的ID,此得为“科目编码”</param>  
        /// <param name="typesubid">次科目ID,是"资产类"还是"负债类"</param>  
        /// <param name="wfilialeid">是"企业"还是"学校"</param>
        /// <return >
        private DataTable wcodingfinancetreesql1sub(string pro3,string typeid,string typesubid,string wfilialeid)
        {
            DataTable dt_sub = null;
            try
            {           
                string sqlstring = "select ISNULL(表名称,'') 表名称,ISNULL(类型名称,'') 科目类型 from wcodingtype where ID='" + typeid + "'";
                DataTable dt = return_select(sqlstring);
                if (dt.Rows.Count <= 0) { throw new Exception("在表'wcodingtype'中没有查到相应的记录!"); }

                string sqlwcodingdbf = dt.Rows[0]["表名称"].ToString();


                sqlstring = "select ID,编码,ISNULL(上级ID,'0') 上级ID,上级编码,级数,名称,拼音,LTRIM(RTRIM(编码))+' '+LTRIM(RTRIM(名称))+'                                                                ' 编码名称"
                     + ",科目ID,科目名称,次科目ID,次科目名称,次科目借贷=ISNULL((select 借贷方向 from wcodingtypesub where ID=temp.次科目ID),0)"
                     + ",引用属性,公司ID,员工ID,产品ID,大类ID,资产ID,借贷方向,方向"
                     + ",辅助核算,帐本模式,帐本借贷,成本科目ID,分公司ID"
                     + " from ("
                     + "select ID,ISNULL(编码,'') 编码,上级ID,上级编码=ISNULL((select 编码 from " + sqlwcodingdbf.Trim() + " where ID=cus.上级ID),''),级数,分公司ID"
                     + ",科目ID,科目名称=ISNULL((select 类型名称 from wcodingtype where ID=cus.科目ID),'')"
                     + ",ISNULL(次科目ID,'0') 次科目ID,次科目名称=ISNULL((select 次科目名称 from wcodingtypesub where ID=cus.次科目ID),'')"
                     + ",名称=ISNULL("
                     + "(case when 引用属性=0 then 名称"
                     + " when 引用属性=1 then (select 公司名称 from customer where ID=cus.公司ID)"
                     + " when 引用属性=2 then (select 姓名 from person where ID=cus.员工ID)"
                     + " when 引用属性=3 then (select 类型名称 from wcodingtypegdzc where ID=cus.资产ID)"
                     + " when 引用属性=4 then (select 产品名称 from pproduct where ID=cus.产品ID)"
                     + " when 引用属性=5 then (select 大类 from types1 where ID=cus.大类ID)"
                     + " else '' end)"
                     + ",'')"
                     + ",拼音=ISNULL("
                     + "(case"
                     + " when 引用属性=0 then 拼音"
                     + " when 引用属性=1 then (select 拼音 from customer where ID=cus.公司ID)"
                     + " when 引用属性=2 then (select 拼音 from person where ID=cus.员工ID)"
                     + " when 引用属性=4 then (select 拼音 from pproduct where ID=cus.产品ID)"
                     + " when 引用属性=5 then (select 拼音 from types1 where ID=cus.大类ID)"
                     + " else '' "
                     + "end)"
                     + ",'')"
                     + ",引用属性,公司ID,员工ID,产品ID,大类ID,资产ID,借贷方向,方向=(case when 借贷方向=1 then '借' when 借贷方向=2 then '贷' else '' end),辅助核算,帐本模式,帐本借贷,ISNULL(成本科目ID,'0') 成本科目ID"
                     + " from " + sqlwcodingdbf.Trim() + " cus where 科目ID='" + typeid.Trim() + "'"
                     + " and 开始月份<='" + pro3 + "' and (结束月份>'" + pro3 + "' or 结束月份 is null)";

                if (wfilialeid.Trim() != "")
                { sqlstring = sqlstring + " and 分公司ID in (" + wfilialeid + ")"; }
                if (typesubid.Trim() != "")
                { sqlstring = sqlstring + " and 次科目ID='" + typesubid + "'"; }

                sqlstring = sqlstring + ") temp";

                dt_sub = return_select(sqlstring);

                
            }
            catch (Exception ex)
            {
                throw new Exception("查询数据库出错!");
            }
            return dt_sub;

        }

        /// </summary>将“公司编码”或“财务编码”生成的表汇总一下
        /// <param name="pro3">月份,暂无用</param>  
        /// <param name="typeid">表wcodingtype中的ID,是“公司编码”还是“科目编码”</param>  
        /// <param name="typesubid">次科目ID,是"资产类"还是"负债类"</param>  
        /// <param name="wfilialeid">是"企业"还是"学校"</param>
        /// <return >
        public  DataTable wcodingfinancetreesql1(string pro3, string typeid, string typesubid, string wfilialeid)
        {
            DataTable dt_sql1 = null;
            try
            {
                if (typeid.Trim() == begin_class.wcoding_typeid1.Trim())
                {
                    dt_sql1 = wcodingfinancetreesql1sub(pro3, typeid, typesubid, wfilialeid);
                }

                DataColumn dc1 = new DataColumn("名称全称", Type.GetType("System.String"));
                dc1.DefaultValue = "";
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("编码加名称", Type.GetType("System.String"));
                dc1.DefaultValue = "";
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("是否末端", Type.GetType("System.Int32"));
                dc1.DefaultValue =0;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("序号", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("节点", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("展开", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("显示", Type.GetType("System.Int32"));
                dc1.DefaultValue = 1;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("排序最后", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_sql1.Columns.Add(dc1);
                dc1 = new DataColumn("横线长度", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_sql1.Columns.Add(dc1);

                DataRow[] dtrow = dt_sql1.Select("编码=''");
                foreach (DataRow row in dtrow) { dt_sql1.Rows.Remove(row); }

                DataView dataView = dt_sql1.DefaultView;
                dataView.Sort = "编码";
                dt_sql1 = dataView.ToTable();

                DataTable dt_temp = dt_sql1.Copy();
                foreach (DataRow row in dt_temp.Rows)
                {
                    string id = row["ID"].ToString();
                    string top_id = row["上级ID"].ToString();
                    string bm1 = row["编码"].ToString();

                    DataRow[] row_temp = dt_sql1.Select("ID='" + top_id + "'");
                    string mcqc = "";
                    string py = "";
                    if (row_temp.Count() > 0)
                    {
                        mcqc = row_temp[0]["名称全称"].ToString();
                        py = row_temp[0]["拼音"].ToString();
                    }
                    if (mcqc.Trim() != "")
                    {
                        DataRow[] row_temp_1 = dt_sql1.Select("ID='" + id + "' and 上级ID='" + top_id + "'");
                        for (int i = 0; i < row_temp_1.Count(); i++)
                        {
                            row_temp_1[i]["名称全称"] = mcqc.Trim() + "\\" + row_temp_1[i]["名称"].ToString().Trim();
                            row_temp_1[i]["编码加名称"] = bm1.Trim() + "-" + mcqc.Trim() + "\\" + row_temp_1[i]["名称"].ToString().Trim();
                            row_temp_1[i]["拼音"] = py.Trim() + "-" + row_temp_1[i]["拼音"].ToString().Trim();
                        }
                    }
                    else
                    {
                        DataRow[] row_temp_2 = dt_sql1.Select("ID='" + id + "'");
                        for (int i = 0; i < row_temp_2.Count(); i++)
                        {
                            row_temp_2[i]["名称全称"] = row_temp_2[i]["名称"].ToString().Trim();
                            row_temp_2[i]["编码加名称"] = bm1.Trim() + "-" + row_temp_2[i]["名称"].ToString().Trim();
                        }
                    }
                }

                for(int i=0;i<dt_sql1.Rows.Count;i++)
                { dt_sql1.Rows[i]["拼音"] = dt_sql1.Rows[i]["编码"].ToString().Trim() + " " + dt_sql1.Rows[i]["拼音"].ToString().Trim(); }
            }
            catch (Exception ex)
            {
                throw new Exception("查询数据库出错!");
            }


            return dt_sql1;
        }


        /// </summary>根据已经获得所有信息的科目编码，将该科目表生成“○”“●”等符号
        /// <param name="treedbf">从"wcodingfinancetreesql1"中生成的表</param>  
        /// <param name="treeyc">有时是不需要隐藏全部节点的，为0表示不隐藏，为1表示隐藏</param>   
        /// <param name="wfilialeid">是"企业"还是"学校"</param>
        /// <return >
        public DataTable wcodingfinancetreesql2(DataTable treedbf,int treeyc, string wfilialeid)
        {
            DataTable dt_sql2 = null;
            try
            {
                DataView dataView = treedbf.DefaultView;
                dataView.Sort = "分公司ID,编码";
                dt_sql2 = dataView.ToTable();

                //将即不是首节点，也不是末端节点的节点标注出来
                for (int i=0;i<dt_sql2.Rows.Count;i++)
                {
                    string top_id = dt_sql2.Rows[i]["上级ID"].ToString();

                    DataRow[] row_temp = dt_sql2.Select("ID='"+top_id+ "' and 是否末端=0");
                    for(int j=0;j< row_temp.Count();j++)
                    {
                        row_temp[j]["节点"] = 1;
                        row_temp[j]["展开"] = 1;
                    }
                }
                //将即不是首节点，也不是末端节点的节点标注出来

                //DataRow[] row_temp_1 = dt_sql2.Select("上级ID>'0'");
                DataView v = dt_sql2.DefaultView;
                DataTable dt_temp = v.ToTable(true, "上级ID");

                for(int i=0;i< dt_temp.Rows.Count;i++)
                {
                    string top_id = dt_temp.Rows[i]["上级ID"].ToString();

                    string max_bm = dt_sql2.Compute("max(编码)", "上级ID='" + top_id + "'").ToString();
       
                    DataRow[] row_temp_2 = dt_sql2.Select("编码='" + max_bm+"'");
                    if (row_temp_2.Count() > 0)
                    {
                        for (int j = 0; j < row_temp_2.Count(); j++)
                        { row_temp_2[j]["排序最后"] = 1; }
                     }
                }

                dt_temp = dt_sql2.Copy();              
                for(int i=0;i< dt_temp.Rows.Count;i++)
                {
                    string id= dt_temp.Rows[i]["ID"].ToString();
                    string top_id = dt_temp.Rows[i]["上级ID"].ToString();
                    if (top_id.Trim()!="0")
                    {
                        DataRow[] row_temp_3 = dt_sql2.Select("ID='" + top_id + "'");
                        if (row_temp_3.Count()>0)
                        {
                            int x_long = row_temp_3[0]["横线长度"].ToString().ToInt();
                            string space_c = "";
                            if (x_long <= 0) { x_long = 4; }
                            for(int j = 0; j < x_long/2; j++) { space_c = space_c + " "; }

                            DataRow[] row_temp_4 = dt_sql2.Select("ID='" + id + "'");
                            row_temp_4[0]["编码名称"] = space_c + " ├┈" + row_temp_4[0]["编码名称"].ToString().Trim();
                            row_temp_4[0]["横线长度"] = x_long+4;
                        }
                    }
                }

                DataRow[] row_temp_5 = dt_sql2.Select("排序最后=1");
                for(int i=0;i<row_temp_5.Count();i++)
                { row_temp_5[i]["编码名称"] = row_temp_5[i]["编码名称"].ToString().Replace("├", "└"); }

                if (treeyc==1)
                {
                    DataRow[] row_temp_6 = dt_sql2.Select("节点=1");
                    for(int i=0;i< row_temp_6.Count();i++)
                    { row_temp_6[i]["展开"] = 0; }

                    DataRow[] row_temp_6x = dt_sql2.Select("上级ID not in ('0')");
                    for (int i = 0; i < row_temp_6x.Count(); i++)
                    { row_temp_6x[i]["显示"] = 0; }
                }

                DataRow[] row_temp_7 = dt_sql2.Select("节点=1 and 展开=1");
                for(int i=0;i<row_temp_7.Count();i++)
                {
                    row_temp_7[i]["编码名称"] = row_temp_7[i]["编码名称"].ToString().Replace("├", "○");
                    row_temp_7[i]["编码名称"] = row_temp_7[i]["编码名称"].ToString().Replace("└", "○");
                }

                DataRow[] row_temp_8 = dt_sql2.Select("节点=1 and 展开=0");
                for (int i = 0; i < row_temp_8.Count(); i++)
                {
                    row_temp_8[i]["编码名称"] = row_temp_8[i]["编码名称"].ToString().Replace("├", "●");
                    row_temp_8[i]["编码名称"] = row_temp_8[i]["编码名称"].ToString().Replace("└", "●");
                }

                DataTable dt_temp_1 = v.ToTable(true, "上级ID");
                for(int i=0;i<dt_temp_1.Rows.Count;i++)
                {
                    string top_id = dt_temp_1.Rows[i]["上级ID"].ToString();
                    if (top_id!="0")
                    {
                        DataRow[] row_temp_9 = dt_sql2.Select("ID='" + top_id + "' and 展开=1 and 上级ID='0'");
                        if (row_temp_9.Count() > 0) { row_temp_9[0]["编码名称"] = "○"+ row_temp_9[0]["编码名称"]; }

                        DataRow[] row_temp_10 = dt_sql2.Select("ID='" + top_id + "' and 展开=0 and 上级ID='0'");
                        if (row_temp_10.Count() > 0) { row_temp_10[0]["编码名称"] = "●" + row_temp_10[0]["编码名称"]; }
                    }
                }

                dataView = dt_sql2.DefaultView;
                dataView.Sort = "分公司ID,编码";
                dt_sql2 = dataView.ToTable();
            }

            catch (Exception ex)
            {
                throw new Exception("查询数据库出错!");
            }


            return dt_sql2;
        }


        /// </summary>将"科目编码"生成的表进行汇总(来自"wcodingfinancetreesql1"和"wcodingfinancetreesql2")
        /// <param name="pro3">月份,暂无用</param>  
        /// <param name="typeid">表wcodingtype中的ID,是“公司编码”还是“科目编码”</param>  
        /// <param name="typesubid">次科目ID,是"资产类"还是"负债类"</param>  
        /// <param name="treeyc">有时是不需要隐藏全部节点的，为0表示不隐藏，为1表示隐藏</param>   
        /// <param name="wfilialeid">是"企业"还是"学校"</param>
        /// <return >
        public DataTable wcodingfinancetreesql3(string pro3, string typeid, string typesubid, int treeyc, string wfilialeid)
        {
            //WaitFormService.Show();
            WaitFormService.SetText("正在查询编码数据库，请稍候…………");

            DataTable dt_sql3 = null;
            try
            {
                DataTable dt_sql1 = wcodingfinancetreesql1(pro3, typeid, typesubid, wfilialeid);

                dt_sql3 = wcodingfinancetreesql2(dt_sql1, treeyc, wfilialeid);
            }
            catch (Exception ex)
            {
                throw new Exception("查询数据库出错!");
            }

            //WaitFormService.Close();

            return dt_sql3;
        }


        /// </summary>将"科目编码"生成的表进行汇总(来自"wcodingfinancetreesql1"和"wcodingfinancetreesql2")
        /// <param name="pro3">月份,暂无用</param>  
        /// <param name="typeid">表wcodingtype中的ID,是“公司编码”还是“科目编码”</param>   
        /// <param name="treeyc">有时是不需要隐藏全部节点的，为0表示不隐藏，为1表示隐藏</param>   
        /// <param name="wfilialeid">是"企业"还是"学校"</param>
        /// <return >
        public DataTable wcodingfinancetreesql4(string pro3, string typeid, int treeyc, string wfilialeid)
        {
            DataTable dt_sql4 = null;
            try
            {
                string sqlstring= "select isnull(分公司ID,'0') 分公司ID,ISNULL(ID, '0') 次科目ID from wcodingtypesub where 科目ID = '"+ typeid + "' and 删除 = 0";
                if (wfilialeid.Trim() != "")
                { sqlstring = sqlstring + " and 分公司ID in (" + wfilialeid + ")"; }

                DataTable dt = return_select(sqlstring);

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string wfilid= dt.Rows[i]["分公司ID"].ToString();
                    string subid = dt.Rows[i]["次科目ID"].ToString();

                    DataTable dt_sql3 = wcodingfinancetreesql3(pro3, typeid, subid, treeyc, wfilialeid);
                    if (i == 0) { dt_sql4 = dt_sql3.Copy(); }
                    else { dt_sql4.Merge(dt_sql3); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询数据库出错!");
            }


            return dt_sql4;
        }

        //结束
    }
}
