using newfeixiang.a_GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace newfeixiang
{

    class begin_class
    {
        //public static bool jytt_all = true;//全局的判断,如果为假则表示程序出错,不往下执行
        public static string allmax;
        //财务科目编码表
        public static DataTable dt_cw_prg_all;
        //所有科目的最底根科目
        public static DataTable dt_cw_prg_all_bottom;
        //查询里经常会用到开始月份、结束月份 
        public static string public_pro3begin, public_pro3end;

        //凭证控件需要用到的表
        public static DataTable vouchereditdbfacc;
        public static DataTable vouchereditdbf;

        //begin_public_1  outmoneylx中的各种工资类型
        #region
        public static string outmoneylxid1;
        public static string outmoneylxid2;
        public static string outmoneylxid3;
        public static string outmoneylxid4;
        public static string outmoneylxid5;
        public static string outmoneylxid6;
        public static string outmoneylxid7;
        //public static string outmoneylxid8;
        public static string outmoneylxid9;
        public static string outmoneylxid10;
        //public static string outmoneylxid11;
        //public static string outmoneylxid12;
        public static string outmoneylxid15;
        public static string outmoneylxid16;
        public static string outmoneylxid17;
        public static string outmoneylxid19;
        public static string outmoneylxid26;

        public static string outmoneysfglid1;
        public static string outmoneysfglid3;
        public static string outmoneysfglid5;
        public static string outmoneysfglid6;
        public static string outmoneysfglid7;
        public static string outmoneysfglid8;
        public static string outmoneysfglid9;
        #endregion

        //begin_public_2  wtemp中的考核类型
        #region
        public static string wtempid1;//毛坯考核
        public static string wtempid2;//钢材考核
        public static string wtempid3;//其它辅材
        public static string wtempid4;//合金考核
        #endregion

        //begin_public_5 wmode的出入库
        #region
        public static string wmodeid2;
        public static string wmodeid4;
        #endregion

        //begin_public_6 wfiliale分公司的ID和公司名称
        #region  
        public static string wfilialeid1;//企业
        public static string wfilialename1;
        public static string wfilialeid2;//学校
        public static string wfilialename2;
        public static string wfilialeid3;//劳务公司
        public static string wfilialename3;
        public static string wfilialeid4;//崇文
        public static string wfilialename4;
        public static string wfilialeid5;//压铸有色
        public static string wfilialename5;
        public static string wfilialeid6;//食堂宾馆
        public static string wfilialename6;
        public static string wfilialeid7;//飞创电子 
        public static string wfilialename7;
        #endregion



        //其它的一些全局变量
        #region
        //""飞翔公司"在表customer中的ID
        public static string cusfxidall;


        //begin_public_11 表wcodingtype中的ID,代表是“公司编码”还是“科目编码”还是“文件编码”
        public static string wcoding_typeid1;//科目编码
        public static string wcoding_typeid2;//公司编码
        public static string wcoding_typeid4;//部门编码
        //public static string wcoding_typeid5;//原料类型编码
        //public static string wcoding_typeid6;//按大类公司编码
        public static string wcoding_typeid7;//文件编码
        #endregion


        #region begin_public_13 表wcodingtypepz 凭证的类型
        public static string wcodingtypepzid1;//收入凭证
        public static string wcodingtypepzname1;
        public static string wcodingtypepzid2;//支出凭证
        public static string wcodingtypepzname2;
        public static string wcodingtypepzid3;
        public static string wcodingtypepzname3;//转帐凭证

        #endregion
    }
}
