using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang
{
    class begin
    {
        public static void auto()
        {
            try {

                //其它的一些全局变量
                a_GlobalClass.begin_public.begin_public_other();

                //outmoneylx中的各种工资类型
                a_GlobalClass.begin_public.begin_public_1();

                //wtemp中的考核类型
                a_GlobalClass.begin_public.begin_public_2();

                //出入库方式
                a_GlobalClass.begin_public.begin_public_5();

                //是“公司编码”还是“科目编码”
                a_GlobalClass.begin_public.begin_public_11();

                //wfiliale分公司的ID和公司名称
                a_GlobalClass.begin_public.begin_public_6();

                //表wcodingtypepz 凭证的类型
                a_GlobalClass.begin_public.begin_public_13();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        public static void beginbmall()
        {
            //try {
            WaitFormService.Show();
            //WaitFormService.SetText("正在刷新财务科目信息，请稍候…………");
            wcoding.wcodingfinance wcoding = new newfeixiang.wcoding.wcodingfinance();
                begin_class.dt_cw_prg_all = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");

                begin_class.dt_cw_prg_all_bottom = begin_class.dt_cw_prg_all.Copy();
                DataView dataView = begin_class.dt_cw_prg_all_bottom.DefaultView;
                DataTable dt_Distinct = dataView.ToTable(true, "上级ID");//注：其中ToTable（）的第一个参数为是否DISTINCT
                foreach (DataRow row in dt_Distinct.Rows)
                {
                    string topidtempid = row["上级ID"].ToString();

                    DataRow[] dt_temp = begin_class.dt_cw_prg_all_bottom.Select("ID='" + topidtempid + "'");
                    foreach (DataRow dr in dt_temp)
                    { begin_class.dt_cw_prg_all_bottom.Rows.Remove(dr); }
                }

            #region 生成凭证控件需要的表
            
            #endregion

            WaitFormService.Close();
            //}
            //catch (Exception ex)
            //{
            //    ex.errormess();
            //}
        }
    }
}
