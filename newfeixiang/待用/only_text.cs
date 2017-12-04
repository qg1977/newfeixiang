using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newfeixiang
{
    public partial class only_text : Form
    {
        public only_text()
        {
            InitializeComponent();
        }

        private void one_Load(object sender, EventArgs e)
        {
            try
            {  //查看类界面万用控件
                //一般使用
                mfvNormal.InitCoreValue("你好", a_qg_trol.FuncType.Simple);
                //为数字增加千位符
                mfvChnNum.InitCoreValue(123456789.1234M, a_qg_trol.FuncType.BigChnNum);
                mfvChnCash.InitCoreValue(123456789.1234M, a_qg_trol.FuncType.BigChnCash);
                //为数字增加千位符，并在上方增加汉字大写气泡
                mfvChnNumWithTip.Precision = 3;
                mfvChnNumWithTip.NeedChineseNumerals = true;
                mfvChnNumWithTip.InitCoreValue(123456789.1234M, a_qg_trol.FuncType.BigChnNum);
                mfvChnCashWithTip.Precision = 3;
                mfvChnCashWithTip.NeedChineseNumerals = true;
                mfvChnCashWithTip.InitCoreValue(123456789.1234M, a_qg_trol.FuncType.BigChnCash);
                //显示日期
                mfvDate1.InitCoreValue(20160524, a_qg_trol.FuncType.Date);
                mfvDate2.InitCoreValue(20160524L, a_qg_trol.FuncType.Date);
                mfvDate3.InitCoreValue(new DateTime(2016, 5, 24), a_qg_trol.FuncType.Date);
                //显示时间
                mfvTime1.InitCoreValue(140430, a_qg_trol.FuncType.Time);
                mfvTime2.InitCoreValue(140430, a_qg_trol.FuncType.Time);
                mfvTime3.InitCoreValue(new DateTime(2016, 5, 24, 14, 4, 30), a_qg_trol.FuncType.Time);
                //显示数据字典
                mfvDataDic1.InitCoreValue(new KeyValuePair<string, string>("1001", "3"), a_qg_trol.FuncType.DataDic);
                mfvDataDic2.DataDicEntry = "1001";
                mfvDataDic2.InitCoreValue("3", a_qg_trol.FuncType.DataDic);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
