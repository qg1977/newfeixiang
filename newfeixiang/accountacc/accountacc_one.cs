using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.accountacc
{
    class accountacc_one
    {

        /// 生成一个凭证的汇总表
        /// </summary>   
        /// <param name="pro3begin">开始月份</param>  
        /// <param name="pro3end">结束月份</param>  
        /// <param name="pzlx">凭证类型"收入凭证""支出凭证""转帐凭证"</param>  
        /// <param name="pzsubid">查询的财务科目ID</param>   
        /// <param name="pzzt">凭证状态,为""表示全部,1=“已制单” 2=“已审核”   4=“帐务主管已审” 5=“已记帐”    9=“作废”</param>  
        /// <param name="pjxh">票据号</param>  
        /// <param name="ph1">票号</param>   
        /// <param name="subfial">
        ///     为1表示不隐藏详细的凭证信息，
        ///      为2表示隐藏详细的凭证信息,
        ///        为3表示隐藏主凭证信息，
        ///          为4表示查询的是该科目对应的科目信息,
        ///             为5时与4的功能相同，
        ///             不同之处是需要将所在科目的借方贷方金额互换（为了查询科目帐本需要）
        /// </param>  
        /// <param name="accidall">凭证总ID</param>  
        /// <param name="accid">凭证ID</param>  
        /// <param name="pchall">凭证的批次号</param>  
        /// <param name="wfilialeid">是“企业”还是“学校”</param>  
        /// <param name="subsx">指代表的凭证的属性ID(表accounttype)</param> 
        /// <returns></returns>   
         #region
        public DataTable accountaccone(string pro3begin,string pro3end,string pzlx,string pzsubid
            ,string pzzt,string pjxh,string ph1,string subsx,string subfial
            ,string accidall,string accid,string pchall,string wfilialeid)
        {

            WaitFormService.Show();
            WaitFormService.SetText("正在查询凭证信息,请稍候…………");

            DataTable dt_accountacc = null;
            try
            {
                string sqlstring;
                DataTable dt;

                DataRow dt_row = null;//增加拷贝记录时用到

                //如果查询的是全部的科目，则直接显示 
                if ((pzsubid=="") && subfial.ToInt() > 2) { subfial = "0"; }
                //科目的编码
                string pzsumbm = "";
                if (pzsubid != "")
                {
                    sqlstring = "select 编码 from customersub where ID='" + pzsubid + "'";
                    dt = return_select(sqlstring);
                    if (dt.Rows.Count > 0)
                    { pzsumbm = dt.Rows[0]["编码"].ToString(); }
                }
                //科目的编码

                sqlstring = "select ISNULL(分公司ID,'0') 分公司ID,分公司名称=ISNULL((select 分公司名称 from wfiliale where ID=accacc.分公司ID),'')"
                    + ",ID,凭证票据号 票据号,凭证票号 凭证号,附件数"
                    + ",ISNULL(原料采购ID,'0') 原料采购ID"
                    + ",convert(varchar(10),日期,120) 日期,月份"
                    + ",状态 状态ID,状态=(case when 状态=0 then '待制单' when 状态=1 then '制单' when 状态=3 then '已审核' when 状态=4 then '已记帐' when 状态=5 then '主管已审' when 状态=9 then '作废' else '' end)"
                    + ",类型ID,凭证类型=ISNULL((select 凭证类型 from wcodingtypepz where iD=accacc.类型ID),'')"
                   + ",属性ID,属性中文=ISNULL((select 中文解释 from accounttype where 凭证属性=accacc.属性ID),'')"
                    + ",主管ID,财务主管=ISNULL((select 姓名 from person where ID=accacc.主管ID),'')"
                    + ",制单ID,制单=ISNULL((select 姓名 from person where ID=accacc.制单ID),'')"
                    + ",审核ID,审核=ISNULL((select 姓名 from person where ID=accacc.审核ID),'')"
                   + ",记帐ID,记帐=ISNULL((select 姓名 from person where ID=accacc.记帐ID),'')"        
                   + " from accountacc accacc where ID is not null";
                if (wfilialeid != "") { sqlstring = sqlstring + " and 分公司ID in (" + wfilialeid + ")"; }
                if (pro3begin != "") { sqlstring = sqlstring + " and 月份>='" + pro3begin + "'"; }
                if (pro3end != "") { sqlstring = sqlstring + " and 月份<='" + pro3end + "'"; }
                if (pzlx != "") { sqlstring = sqlstring + " and 类型ID in (" + pzlx + "'"; }
                if (pzsumbm!="")
                {
                    int bmlen = pzsumbm.Trim().Length;
                    sqlstring = sqlstring + " and ID in (select 凭证总ID from account where 科目ID in (select ID from customersub where substring(LTRIM(RTRIM(编码)),1," + bmlen.ToString() + ")='" + pzsumbm.Trim() + "') and 属性=23)";
                }
                if (pzzt != "") { sqlstring = sqlstring + " and 状态 in (" + pzzt.Trim() + ")"; }
                if (pjxh != "") { sqlstring = sqlstring + " and 凭证票据号 in (" + pjxh + ")"; }
                if (ph1 != "") { sqlstring = sqlstring + " and 票号 in (" + ph1 + ")"; }
                if (accidall != "") { sqlstring = sqlstring + " and ID in (select 凭证总ID from account where ID='" + accidall.Trim() + "')"; }
                if (accid != "") { sqlstring = sqlstring + " and ID in (" + accid.Trim() + ")";}
                if (pchall != "") { sqlstring = sqlstring + " and 凭证批次号 in (" + pchall.Trim() + ")"; }
                if (subsx != "") { sqlstring = sqlstring + " and 属性ID in (" + subsx.Trim() + ")"; }
                DataTable dt_accountaccx1 = return_select(sqlstring);

                DataColumn dc1 = new DataColumn("分ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("摘要", Type.GetType("System.String"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("次科目借贷", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("科目编码", Type.GetType("System.String"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("科目ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("借方科目", Type.GetType("System.String"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("贷方科目", Type.GetType("System.String"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("借方金额", Type.GetType("System.Decimal"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("贷方金额", Type.GetType("System.Decimal"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("借贷方向", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("引用属性", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("公司ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("员工ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("资产ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("产品ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("大类ID", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 1;
                dt_accountaccx1.Columns.Add(dc1);
                //dc1 = new DataColumn("临时金额", Type.GetType("System.Decimal"));
                //dc1.DefaultValue = 0;
                //dt_accountaccx1.Columns.Add(dc1);
                //dc1 = new DataColumn("临时科目", Type.GetType("System.Int64"));
                //dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("数量", Type.GetType("System.Decimal"));
                dc1.DefaultValue = 0;
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("反科目ID", Type.GetType("System.String"));
                dt_accountaccx1.Columns.Add(dc1);
                dc1 = new DataColumn("凭证总排序", Type.GetType("System.Int64"));
                dt_accountaccx1.Columns.Add(dc1);

                DataView dataView = dt_accountaccx1.DefaultView;
                DataTable dt_Distinct = dataView.ToTable(true, "ID", "属性ID", "类型ID", "状态ID","月份");//注：其中ToTable（）的第一个参数为是否distinct
                for(int i=0;i<dt_Distinct.Rows.Count;i++)
                {
                    string dt_dis_id = dt_Distinct.Rows[i]["ID"].ToString();
                    string dt_dis_sxid= dt_Distinct.Rows[i]["属性ID"].ToString();
                    string dt_dis_typeid= dt_Distinct.Rows[i]["类型ID"].ToString();
                    string dt_dis_ztid= dt_Distinct.Rows[i]["状态ID"].ToString();
                    string dt_dis_pro3= dt_Distinct.Rows[i]["月份"].ToString();

                   
                  sqlstring= "select ID,摘要,科目ID,借方科目=(case when 借贷方向=1 then 科目名称 else '' end),贷方科目=(case when 借贷方向=2 then 科目名称 else '' end)"
                       + ",借方金额=(case when 借贷方向=1 then 金额 else 0 end),贷方金额=(case when 借贷方向=2 then 金额 else 0 end),借贷方向,引用属性,公司ID,员工ID,资产ID,产品ID,大类ID"
                       + ",次科目借贷=(select 借贷方向 from wcodingtypesub where ID=(select 次科目ID from customersub where ID=temp.科目ID))"
                       + ",数量"
                       +",科目编码"
                       + " from ("
                       + "select ID,摘要,金额,借贷方向,科目ID,科目编码,LTRIM(RTRIM(科目编码))+' '+LTRIM(RTRIM(名称)) 科目名称,引用属性,公司ID,员工ID,资产ID,产品ID,大类ID,数量"
                       + " from ("
                       + "select ID,ISNULL(原因,'') 摘要,金额,借贷方向,ISNULL(数量,0) 数量"
                       + ",科目ID,科目编码=ISNULL((select 编码 from customersub where ID=acc.科目ID),'')"
                       + ",名称=ISNULL((select "
                       + "(case when 引用属性=0 then 名称"
                       + " when 引用属性=1 then (select 公司名称 from customer where ID=cus.公司ID)"
                       + " when 引用属性=2 then (select 姓名 from person where ID=cus.员工ID)"
                       + " when 引用属性=3 then (select 类型名称 from wcodingtypegdzc where ID=cus.资产ID)"
                       + " when 引用属性=4 then (select 产品名称 from pproduct where ID=cus.产品ID)"
                       + " when 引用属性=5 then (select 大类 from types1 where ID=cus.大类ID)"
                       + " else '' end)"
                       + " from customersub cus where ID=acc.科目ID),'')"
                       + ",引用属性,ISNULL(公司ID,'0') 公司ID,ISNULL(经手人,'0') 员工ID,ISNULL(资产ID,'0') 资产ID,ISNULL(产品ID,'0') 产品ID,ISNULL(大类ID,'0') 大类ID"
                       + " from account acc where 凭证总ID='" + dt_dis_id + "' and 属性=23"
                       + ") temp"
                       + ") temp";
                    dt = return_select(sqlstring);
                    foreach (DataRow row in dt.Rows)
                    {
                        dt_row = dt_accountaccx1.NewRow();
                        dt_row["ID"] = dt_dis_id;
                        dt_row["月份"] = dt_dis_pro3;
                        dt_row["属性ID"] = dt_dis_sxid;
                        dt_row["类型ID"] = dt_dis_typeid;
                        dt_row["状态ID"] = dt_dis_ztid;
                        dt_row["分ID"] = row["ID"];
                        dt_row["摘要"] = row["摘要"];
                        dt_row["次科目借贷"] = row["次科目借贷"];
                        dt_row["科目ID"] = row["科目ID"];
                        dt_row["借方科目"] = row["借方科目"];
                        dt_row["贷方科目"] = row["贷方科目"];
                        dt_row["借方金额"] = row["借方金额"];
                        dt_row["贷方金额"] = row["贷方金额"];
                        dt_row["借贷方向"] = row["借贷方向"];
                        dt_row["引用属性"] = row["引用属性"];
                        dt_row["公司ID"] = row["公司ID"];
                        dt_row["员工ID"] = row["员工ID"];
                        dt_row["资产ID"] = row["资产ID"];
                        dt_row["产品ID"] = row["产品ID"];
                        dt_row["大类ID"] = row["大类ID"];
                        dt_row["数量"] = row["数量"];
                        dt_row["排序"] = 2;
                        dt_row["科目编码"] = row["科目编码"];
                        dt_accountaccx1.Rows.Add(dt_row);
                    }
                }

                #region &&对应的借贷方向的反科目ID
                for(int i=0;i<dt_accountaccx1.Rows.Count;i++)
                {
                    string accidtempid = dt_accountaccx1.Rows[i]["ID"].ToString();
                    int jdfx1= dt_accountaccx1.Rows[i]["借贷方向"].ToString().ToInt();

                    int jdfx_f = 0;
                    if (jdfx1 == 1) { jdfx_f = 2;}
                    if (jdfx1 == 2) { jdfx_f = 1; }

                    sqlstring= "select distinct 科目ID from account where 属性 = 23 and 凭证总ID = '"+accidtempid+"' and 借贷方向 = "+ jdfx_f.ToString();
                    dt = return_select(sqlstring);
                    string km_f_id_all = "";
                    for(int j=0;j<dt.Rows.Count;j++)
                    {
                        string accid_f_tempid = dt.Rows[j]["科目ID"].ToString();
                        if (km_f_id_all.NotIsNullOrEmpty()) { km_f_id_all = km_f_id_all + ","; }
                        km_f_id_all = km_f_id_all.Trim() + accid_f_tempid.Trim();
                    }

                    dt_accountaccx1.Rows[i]["反科目ID"] = km_f_id_all.Trim();
                }
                #endregion

                #region 将表“编码加名称”装到表本表的借方科目或贷方科目名称中
                 dataView = dt_accountaccx1.DefaultView;
                 dt_Distinct = dataView.ToTable(true, "科目ID");//注：其中ToTable（）的第一个参数为是否distinct
                for(int i=0;i<dt_Distinct.Rows.Count;i++)
                {
                    string subidtempid = dt_Distinct.Rows[i]["科目ID"].ToString();
                    if (subidtempid.Trim() == "") { continue; }
               
                    DataRow[] rows = begin_class.dt_cw_prg_all.Select("ID=" + subidtempid);
                    string bmtemp1 = "";
                    if (rows.Count() > 0) { bmtemp1 = rows[0]["编码加名称"].ToString(); }

                    DataRow[] row_1 = dt_accountaccx1.Select("科目ID=" + subidtempid + " and 借贷方向=1");
                    for(int j = 0; j < row_1.Count(); j++) { row_1[j]["借方科目"] = bmtemp1; }
                    DataRow[] row_2 = dt_accountaccx1.Select("科目ID=" + subidtempid + " and 借贷方向=2");
                    for (int j = 0; j < row_2.Count(); j++) { row_2[j]["贷方科目"] = bmtemp1; }
                }
                #endregion

                #region 将排序=2的分记录的借方金额和贷方金额汇总后拷到排序=1的总记录中
                var query = from t in dt_accountaccx1.AsEnumerable()
                            where t.Field<int>("排序") == 2
                            group t by t["ID"] into m                           
                            select new
                            {
                                ID = m.Key,
                                借方金额 = m.Sum(n => n.Field<decimal>("借方金额")),
                                贷方金额 = m.Sum(n => n.Field<decimal>("贷方金额"))
                            };
                dt = Cs_Datatable.ToDataTable(query.ToList());
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string accidtempid = dt.Rows[i]["ID"].ToString();
                    double je1temp1= dt.Rows[i]["借方金额"].ToString().ToDouble();
                    double je1temp2 = dt.Rows[i]["贷方金额"].ToString().ToDouble();

                    if (accidtempid.Trim() == "") { continue; }

                    DataRow[] row_3 = dt_accountaccx1.Select("ID=" + accidtempid + " and 排序=1");
                    for(int j = 0; j < row_3.Count(); j++) { row_3[j]["借方金额"] = je1temp1;row_3[j]["贷方金额"] = je1temp2; }
                }
                #endregion


                #region 如果查询的某一单一科目，则可能该科目的摘要为空，需要将该凭证的摘要拷贝
                if (subfial == "3" || subfial == "4" || subfial == "5")
                {
                    DataRow[] row_4 = dt_accountaccx1.Select("排序=2 and 摘要=''");
                    for (int i = 0; i < row_4.Count(); i++)
                    {
                        string accallidtempid = row_4[i]["ID"].ToString();
                        string subidtempid = row_4[i]["科目ID"].ToString();

                        DataRow[] row_5 = dt_accountaccx1.Select("ID=" + accallidtempid + " and 排序=2 and 摘要 not in ('')");
                        dt = row_5.CopyToDataTable();
                        dt_Distinct = dt.DefaultView.ToTable(true, "摘要");
                        string zyalltemp1 = "";
                        for (int j = 0; j < dt_Distinct.Rows.Count; j++)
                        {
                            if (zyalltemp1.NotIsNullOrEmpty()) { zyalltemp1 = zyalltemp1.Trim() + "、"; }
                            zyalltemp1 = zyalltemp1.Trim() + row_5[j]["摘要"].ToString().Trim();

                        }
                        if (zyalltemp1.Trim().Length > 41) { zyalltemp1 = zyalltemp1.Substring(0, 40) + "……"; }
                        row_4[i]["摘要"] = zyalltemp1;
                    }
                }
                #endregion

                //&&怪异的“5”，月底科目结帐时用，这时需要选出每个凭证中查询的科目的对应的其它的科目记录，但必须将其它的科目记录的科目ID替换成本科凭证中查询的科目ID，然后再将借方金额和贷方金额互换，然后再将借贷方向（1和2）互换
                //查询某一科目的信息时，比如查询“现金”科目时
                //比如：借方      贷方     借方金额      贷方金额
                //                现金                    1100
                //    应付帐款               500
                //    应付帐款               600
                //就需要显示“应付帐款”的科目信息
                #region
                if (subfial=="3" || subfial=="5")
                {
                    DataRow[] row_6 = dt_accountaccx1.Select("排序=1");
                    for(int i=0;i<row_6.Count();i++)
                    {
                        string accidalltempid = row_6[i]["ID"].ToString();
                        dt = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid+" and 科目编码 like '"+ pzsumbm+"%'").CopyToDataTable();
                        dt_Distinct = dt.DefaultView.ToTable(true, "科目ID","次科目借贷");

                        for(int j=0;j<dt_Distinct.Rows.Count;j++)
                        {
                            string subidtempid = dt_Distinct.Rows[j]["科目ID"].ToString();
                            string kmjdtemp1= dt_Distinct.Rows[j]["次科目借贷"].ToString();
                            DataRow[] row_7 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 科目ID=" + subidtempid);

                            int jdfxtemp1 = row_7[0]["借贷方向"].ToString().ToInt();
                            //本科目在本张凭证中所在“借贷方向”的数目
                            DataRow[] row_8 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 借贷方向=" + jdfxtemp1.ToString());
                            int jeuntemp1 = row_8.Count();
                            row_8 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 借贷方向=" + (3-jdfxtemp1).ToString());
                            int jeuntemp2 = row_8.Count();
                            if (jeuntemp1==0 || jeuntemp2 == 0) { continue; }

                            //如果本科目为一对多的“一”的这一边，则需要将“一”边本科目ID，全部复制到“多”的一边的科目中，然后将“一”边的科目ID改为“0”（避免根据科目ID拷贝记录时两边都拷贝上）
                            if (jeuntemp2>1)
                            {
                                DataRow[] row_9=dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 科目ID=" + subidtempid+" and 借贷方向="+jdfxtemp1.ToString());
                                row_9[0]["科目ID"] = 0;
                                int yysxtemp1 = row_9[0]["引用属性"].ToString().ToInt();
                                string cusidtempid = row_9[0]["公司ID"].ToString();
                                string peridtempid = row_9[0]["员工ID"].ToString();

                                DataRow[] row_10 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 借贷方向=" + (3 - jdfxtemp1).ToString());
                                for(int k=0;k<row_10.Count();k++)
                                {
                                    row_10[k]["次科目借贷"] = kmjdtemp1;
                                    row_10[k]["借贷方向"] = jdfxtemp1;
                                    row_10[k]["反科目ID"] = row_10[k]["科目ID"];
                                    row_10[k]["科目ID"] = subidtempid;
                                    Decimal decimaltemp1 = row_10[k]["借方金额"].ToString().ToDecimal();
                                    row_10[k]["借方金额"] = row_10[k]["贷方金额"];
                                    row_10[k]["贷方金额"] = decimaltemp1;
                                    string kmidtempid = row_10[k]["借方科目"].ToString();
                                    row_10[k]["借方科目"] = row_10[k]["贷方科目"];
                                    row_10[k]["贷方科目"] = kmidtempid;
                                    if (yysxtemp1 > 0)
                                    {
                                        row_10[k]["引用属性"] = yysxtemp1;
                                        row_10[k]["公司ID"] = cusidtempid;
                                        row_10[k]["员工ID"] = peridtempid;
                                    }

                                }
                            }
                            else//如果本科目为多的一边（包含一对一），只需要将“一”边的科目名称拷贝，其它不变
                            {
                                DataRow[] row_11 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 借贷方向=" + (3 - jdfxtemp1).ToString());
                                string kmnametemp1 = "";
                                if ((3 - jdfxtemp1) == 1) { kmnametemp1 = row_11[0]["借方科目"].ToString(); }
                                if ((3 - jdfxtemp1) == 2) { kmnametemp1 = row_11[0]["贷方科目"].ToString(); }
                                
                                DataRow[] row_12=dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid + " and 科目ID=" + subidtempid + " and 借贷方向=" + jdfxtemp1.ToString());
                                for(int k=0;k<row_12.Count();k++)
                                {
                                    if (jdfxtemp1 == 1) { row_12[k]["借方科目"] = kmnametemp1; }
                                    if (jdfxtemp1 == 2) { row_12[k]["贷方科目"] = kmnametemp1; }
                                }
                            }
                        }
                    }
                }
                #endregion

                // 拷贝主主凭证信息
                # region
                if (subfial == "3" || subfial == "4" || subfial == "5")
                {
                    DataRow[] row_13 = dt_accountaccx1.Select("排序=1");
                    for (int i = 0; i < row_13.Count(); i++)
                    {
                        string accidalltempid = row_13[i]["ID"].ToString();
                        string pjhtemp1 = row_13[i]["票据号"].ToString();
                        string datatemp1 = row_13[i]["日期"].ToString();
                        string pzhtemp1 = row_13[i]["凭证号"].ToString();
                        string pztypetemp1 = row_13[i]["凭证类型"].ToString();

                        DataRow[] row_14 = dt_accountaccx1.Select("排序=2 and ID=" + accidalltempid);
                        for (int j = 0; j < row_14.Count(); j++)
                        {
                            row_14[j]["票据号"] = pjhtemp1;
                            row_14[j]["日期"] = datatemp1;
                            row_14[j]["凭证号"] = pzhtemp1;
                            row_14[j]["凭证类型"] = pztypetemp1;
                        }
                    }
                }
                #endregion

                //如果为选定的一个科目，则删除掉其余多余的科目
                #region
                DataTable dt_accountaccx2;
                if (subfial == "3" || subfial == "5")
                {
                    dt_accountaccx2= dt_accountaccx1.Select("科目编码 like '" + pzsumbm + "%'").CopyToDataTable();
                }else if (subfial == "4")
                {
                    dt_accountaccx2 = dt_accountaccx1.Select("科目编码 not like '" + pzsumbm + "%'").CopyToDataTable();
                }else
                { dt_accountaccx2 = dt_accountaccx1.Copy(); }

                //删除掉详细的凭证信息
                if (subfial == "2")
                {
                    DataRow[] row_15 = dt_accountaccx2.Select("排序=2");
                    for(int i=0;i<row_15.Count();i++)
                    {
                        dt_accountaccx2.Rows.Remove(row_15[i]);
                    }
                }
                #endregion

                //如果“辅助核算”为1表示需要按公司ID或员工ID进行分类
                #region
                dt_Distinct = dt_accountaccx2.DefaultView.ToTable(true, "科目ID");
                for(int i=0;i<dt_Distinct.Rows.Count;i++)
                {
                    string subidtempid = dt_Distinct.Rows[i]["科目ID"].ToString();
                    if (subidtempid.Trim() == "") { continue; }

                    sqlstring = "select 辅助核算 from customersub where ID='" + subidtempid + "'";
                    dt = return_select(sqlstring);

                    int fzhstemp1 = dt.Rows[0]["辅助核算"].ToString().ToInt();
                    if (fzhstemp1==0)
                    {
                        DataRow[] row_16 = dt_accountaccx2.Select("科目ID=" + subidtempid);
                        for(int j=0;j<row_16.Count();j++)
                        {
                            row_16[j]["引用属性"] = 0;
                            row_16[j]["公司ID"] = 0;
                            row_16[j]["员工ID"] = 0;
                        }
                    }
                }
                #endregion

                #region
                dt_Distinct = dt_accountaccx2.DefaultView.ToTable(true, "类型ID", "ID");
                for(int i=0;i<dt_Distinct.Rows.Count;i++)
                {
                    string typeidtempid = dt_Distinct.Rows[i]["类型ID"].ToString();
                    string accidalltempid = dt_Distinct.Rows[i]["ID"].ToString();

                    dt_row = dt_accountaccx2.NewRow();
                    dt_row["类型ID"] = typeidtempid;
                    dt_row["ID"] = accidalltempid;
                    dt_row["排序"] = 3;
                    dt_accountaccx2.Rows.Add(dt_row);
                }

                DataRow[] row_17 = dt_accountaccx2.Select("排序=1");
                for(int i=0;i<row_17.Count();i++)
                {
                    string accidalltempid = row_17[i]["ID"].ToString();
                    string wfiliaidtempid = row_17[i]["分公司ID"].ToString();

                    DataRow[] row_18 = dt_accountaccx2.Select("ID=" + accidalltempid);
                    for(int j=0;j<row_18.Count();j++)
                    {
                        row_18[j]["分公司ID"] = wfiliaidtempid;
                    }
                }
                #endregion

                #region
                dt_accountaccx2.DefaultView.Sort="分公司ID,类型ID,ID,排序,凭证号";
                dt_accountacc = dt_accountaccx2.DefaultView.ToTable();

                string idtempidxx = "";
                string zytemp1xx = "";
                //int countix = 1;
                DataRow[] row_19 = dt_accountacc.Select("ID>0", "分公司ID,类型ID,ID,排序,凭证号");
                for(int i=0;i< row_19.Count();i++)
                {
                    string idtempid = row_19[i]["ID"].ToString();
                    string zytemp1= row_19[i]["摘要"].ToString();

                    if (idtempid.Trim()==idtempidxx.Trim() && zytemp1.Trim()==zytemp1xx.Trim())
                    { row_19[i]["摘要"] = ""; }

                    //row_19[i]["凭证总排序"] = countix;
                    //if (idtempid.Trim()!=idtempidxx.Trim())
                    //{  countix = countix + 1; }

                    idtempidxx = idtempid;
                    zytemp1xx = zytemp1;
                }
                #endregion

                #region
                dt_Distinct = dt_accountacc.DefaultView.ToTable(true, "ID");//注：其中ToTable（）的第一个参数为是否distinct
                int countix = 1;
                for(int i=0;i<dt_Distinct.Rows.Count;i++)
                {
                    string accallidtempid = dt_Distinct.Rows[i]["ID"].ToString();
                    DataRow[] row_20 = dt_accountacc.Select("ID="+accallidtempid, "");
                    for (int j = 0; j < row_20.Count(); j++)
                    {
                        row_20[j]["凭证总排序"] = countix;                        
                    }
                    countix = countix + 1;
                }
                #endregion


            }
            catch (Exception ex)
            {
                ex.errormess();
            }

            WaitFormService.Close();
            return dt_accountacc;
        }
        #endregion


        /// 根据凭证总ID查询出一张凭证
        /// </summary>   
        /// <param name="accidall">凭证总ID</param>  
        #region
        public DataTable accountacconesqlone(string accidall)
        {
            DataTable dt=null;
            try
            {
                    string sqlstring;
                sqlstring = "select ID,ISNULL(原因,'') 摘要,金额,借贷方向,科目ID"
                       + ",借方金额=(case when 借贷方向=1 then 金额 else 0 end),贷方金额=(case when 借贷方向=2 then 金额 else 0 end),借贷方向"
                       + ",引用属性"
                        + ",ISNULL(公司ID,'0') 公司ID,公司名称=ISNULL((case when 引用属性=1 then (select 公司名称 from customer where ID=acc.公司ID) else '' end),'')"
                        + ",ISNULL(经手人,'0') 员工ID,姓名=ISNULL((case when 引用属性=2 then (select 姓名 from person where ID=acc.经手人) else '' end),'')"
                        + " from account acc where 凭证总ID='" + accidall + "' and 属性=23";
                dt = return_select(sqlstring);

                DataColumn dc1 = new DataColumn("凭证序号", Type.GetType("System.Int64"));
                dc1.DefaultValue = 0;
                dt.Columns.Add(dc1);
                dc1 = new DataColumn("科目名称", Type.GetType("System.String"));

                dt.Columns.Add(dc1);
                dc1 = new DataColumn("排序临时", Type.GetType("System.Decimal"));
                dc1.DefaultValue = 0;
                dt.Columns.Add(dc1);
                dc1 = new DataColumn("打印科目", Type.GetType("System.String"));
                dt.Columns.Add(dc1);
                for(int i = 0; i < dt.Rows.Count; i++) { dt.Rows[i]["排序临时"] =Math.Abs(dt.Rows[i]["借方金额"].ToString().ToDecimal()); }

                dt.DefaultView.Sort = "排序临时 desc";

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string subidtempid = dt.Rows[i]["科目ID"].ToString();

                    DataRow[] rows = begin_class.dt_cw_prg_all.Select("ID=" + subidtempid);
                    string bmnametemp1 = rows[0]["编码加名称"].ToString();

                    dt.Rows[i]["凭证序号"] = (i+1).ToString();
                    dt.Rows[i]["科目名称"] = bmnametemp1;

                    int yyssxtemp1 = dt.Rows[i]["引用属性"].ToString().ToInt();
                    string bmnametemp1temp1 = bmnametemp1;
                    switch(yyssxtemp1)
                    {
                        case 1:
                            bmnametemp1temp1 = bmnametemp1temp1 + "    (" + dt.Rows[i]["公司名称"].ToString().Trim() + ")";
                            break;
                        case 2:
                            bmnametemp1temp1 = bmnametemp1temp1 + "    (" + dt.Rows[i]["姓名"].ToString().Trim() + ")";
                            break;
                        default:
                            break;
                    }
                    dt.Rows[i]["打印科目"] = bmnametemp1temp1;
                }

                DataRow dr2 = null;
                for (int i=dt.Rows.Count;i<15;i++)
                {
                    dr2 = dt.NewRow();
                    dr2["凭证序号"] = i.ToString();
                    dt.Rows.Add(dr2);
                }

                dr2 = dt.NewRow();
                dr2["凭证序号"] = 99;
                dr2["借方金额"]=dt.Compute("Sum(借方金额)", "").ToString().ToDecimal();
                dr2["贷方金额"] = dt.Compute("Sum(贷方金额)", "").ToString().ToDecimal();
                dt.Rows.Add(dr2);

                string jy1temp1x = "";
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string jy1temp1 = dt.Rows[i]["摘要"].ToString();

                    if (jy1temp1.Trim()==jy1temp1x.Trim())
                    { dt.Rows[i]["摘要"] = ""; }

                    jy1temp1x = jy1temp1;
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
            return dt;
        }
        #endregion



        //结束
    }
}