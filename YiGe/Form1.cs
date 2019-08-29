using System;
using System . Data;
using System . Windows . Forms;

namespace YiGe
{
    public partial class Form1 : Form
    {
        YiGeBll.Bll.VerBll _bll = null;

        YiGeQuery.Form1Query formQuery = null;
        YiGeQuery.FormOneQuery formQueryOne =null;
        YiGeEntiry.VersionEntity _model =null;
        YiGeQuery.FormTwoQuery formQueryTwo = null;
        YiGeQuery.FormTreQuery formQueryTre = null;
        YiGeQuery.FormForQuery formQueryFor = null;
        YiGeQuery.FormFivQuery formQueryFiv = null;
        YiGeQuery.FormSxiQuery formQuerySix = null;
        YiGeQuery.FormSevQuery formQuerySev = null;
        bool result = false;
        string signOne = "", signTwo = "";

        public Form1 ( )
        {
            InitializeComponent( );

            _bll = new YiGeBll . Bll . VerBll ( );
            _model = new YiGeEntiry . VersionEntity ( );
            formQuery = new YiGeQuery . Form1Query ( );
            formQueryOne = new YiGeQuery . FormOneQuery ( );
            formQueryTwo = new YiGeQuery . FormTwoQuery ( );
            formQueryTre = new YiGeQuery . FormTreQuery ( );
            formQueryFor = new YiGeQuery . FormForQuery ( );
            formQueryFiv = new YiGeQuery . FormFivQuery ( );
            formQuerySix = new YiGeQuery . FormSxiQuery ( );
            formQuerySev = new YiGeQuery . FormSevQuery ( );
        }

        private void Form1_Load ( object sender ,EventArgs e )
        {
            textBox1.Enabled = true;
            button30.Enabled = true;
            comboBox1.Enabled = button31.Enabled = button33.Enabled = textBox2.Enabled = textBox3.Enabled = button34.Enabled = textBox4.Enabled = textBox5.Enabled = button32.Enabled = false;
            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "订单" ,"订单变更单" ,"采购单" ,"采购变更单" ,"报价单" ,"装箱单" ,"进货单" ,"工单" ,"工单变更单" ,"领料单" ,"退料单" ,"生产入库单" ,"退货单" ,"国外订单" ,"国外报价单" ,"国外装箱单" ,"国外采购单" ,"委外进货单" ,"委外退货单","合格证" } );
        }

        void actionOfPrint (string sign )
        {
            try
            {
                formQuery . StartPosition = FormStartPosition . CenterScreen;
                formQuery . signOfPtint = sign;
                formQuery . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintOne ( string sign )
        {
            try
            {
                formQueryOne . StartPosition = FormStartPosition . CenterScreen;
                formQueryOne . signOfPtint = sign;
                formQueryOne . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintTwo ( string sign )
        {
            try
            {
                formQueryTwo . StartPosition = FormStartPosition . CenterScreen;
                formQueryTwo . sign = sign;
                formQueryTwo . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintTre ( string sign )
        {
            try
            {
                formQueryTre . StartPosition = FormStartPosition . CenterScreen;
                formQueryTre . sign = sign;
                formQueryTre . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintFor ( string sign )
        {
            try
            {
                formQueryFor . StartPosition = FormStartPosition . CenterScreen;
                formQueryFor . sign = sign;
                formQueryFor . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintFiv ( string sign )
        {
            try
            {
                formQueryFiv . StartPosition = FormStartPosition . CenterScreen;
                formQueryFiv . sign = sign;
                formQueryFiv . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintSix ( string sign )
        {
            try
            {
                formQuerySix . StartPosition = FormStartPosition . CenterScreen;
                formQuerySix . sign = sign;
                formQuerySix . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }
        void actionOfPrintSev ( string sign )
        {
            try
            {
                formQuerySev . StartPosition = FormStartPosition . CenterScreen;
                formQuerySev . sign = sign;
                formQuerySev . ShowDialog ( );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
            }
        }

        #region
        //嘉兴依格订单
        private void button1_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "1" );
        }
        //浩律科贸订单
        private void button2_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "2" );
        }
        //上海依格订单
        private void button4_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "3" );
        }
        //国外订单
        private void button9_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "4" );
        }
        //备货单
        private void button10_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "5" );
        }
        //嘉兴依格报价
        private void button5_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "6" );
        }
        //浩律科贸报价
        private void button6_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "7" );
        }
        //上海依格报价
        private void button3_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "8" );
        }
        //国外报价
        private void button8_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "9" );
        }
        //嘉兴依格采购
        private void button12_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "10" );
        }
        //浩律科贸采购
        private void button13_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "11" );
        }
        //鲁澜工贸采购
        private void button14_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "12" );
        }
        //国外采购
        private void button16_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "13" );
        }
        //订单变更单
        private void button7_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "14" );
        }
        //采购变更单
        private void button17_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne( "15" );
        }
        //进货单
        private void button18_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "16" );
        }
        //上海依格采购
        private void button36_Click ( object sender ,EventArgs e )
        {
            actionOfPrintOne ( "31" );
        }
        //退货单
        private void button19_Click ( object sender ,EventArgs e )
        {
            actionOfPrintFiv( "17" );
        }
        //嘉兴依格装箱单
        private void button11_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "18" );
        }
        //浩律科贸装箱单
        private void button20_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "19" );
        }
        //上海依格装箱单
        private void button21_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "20" );
        }
        //国外装箱单
        private void button22_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "21" );
        }
        //工单
        private void button15_Click ( object sender ,EventArgs e )
        {
            actionOfPrintTwo( "22" );
        }
        //工单变更
        private void button23_Click ( object sender ,EventArgs e )
        {
            actionOfPrintTwo( "23" );
        }
        //领料单
        private void button24_Click ( object sender ,EventArgs e )
        {
            actionOfPrintTre( "24" );
        }
        //退料单
        private void button25_Click ( object sender ,EventArgs e )
        {
            actionOfPrintFor( "25" );
        }
        //生产入库单
        private void button26_Click ( object sender ,EventArgs e )
        {
            actionOfPrintSix( "26" );
        }
        //委外进货单
        private void button27_Click ( object sender ,EventArgs e )
        {
            actionOfPrintSev( "27" );
        }
        //委外退货单
        private void button28_Click ( object sender ,EventArgs e )
        {
            actionOfPrintSev( "28" );
        }
        //盘点单
        private void button29_Click ( object sender ,EventArgs e )
        {
            actionOfPrint( "29" );
        }
        //合格证
        private void button35_Click ( object sender ,EventArgs e )
        {
            actionOfPrint ( "30" );
        }
        //嘉兴芬格采购
        private void Button37_Click ( object sender , EventArgs e )
        {
            actionOfPrintOne ( "32" );
        }
        #endregion

        #region
        //Query
        private void button32_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "请选择模板" );
                return;
            }
            DataTable de = _bll.GetDataTableOfSql( comboBox1.Text );
            if ( de == null || de.Rows.Count < 1 )
            {
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                MessageBox.Show( "没有数据源" );               
                return;
            }
            textBox2.Text = de.Rows[0]["DJ003"].ToString( );
            textBox4.Text = de.Rows[0]["DJ004"].ToString( );
            textBox3.Text = de.Rows[0]["DJ005"].ToString( );
            textBox5.Text = de.Rows[0]["DJ006"].ToString( );
        }
        //PassWord
        private void button30_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "密码为空" );
                return;
            }
            result = _bll.GetDataTablePass( textBox1.Text );
            if ( result == false )
            {
                MessageBox.Show( "密码错误,请重试" );
                return;
            }
            comboBox1.Enabled = button31.Enabled = button33.Enabled = textBox2.Enabled = textBox3.Enabled = button34.Enabled = textBox4.Enabled =button32.Enabled= textBox5.Enabled = true;
        }
        //Check
        private void button33_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox2 . Text ) )
            {
                MessageBox . Show ( "请输入模板数据源" );
                return;
            }
            try
            {
                DataTable da = _bll . GetDataTableCheck ( textBox2 . Text ,textBox4 . Text );
                MessageBox . Show ( "模板数据源语法正确,请保存" );
                signOne = "1";
            }
            catch ( Exception ex )
            {
                MessageBox . Show ( "模板数据源语法错误,请检查" );
                signOne = "";
                throw new Exception ( ex . Message );
            }
        }
        private void button34_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "请输入合计数据源" );
                return;
            }
            if ( !string.IsNullOrEmpty( textBox3.Text ) )
            {
                if ( !textBox3.Text.Contains( "小写合计" ) )
                {
                    MessageBox.Show( "合计项应为小写合计" );
                    return;
                }
            }
            try
            {
                DataTable da = _bll.GetDataTableCheck( textBox3.Text ,textBox5.Text );
                MessageBox.Show( "合计数据源语法正确,请保存" );
                signTwo = "1";
            }
            catch
            {
                MessageBox.Show( "合计数据源语法错误,请检查" );
                signTwo = "";
                return;
            }
        }



        //Save
        private void button31_Click ( object sender ,EventArgs e )
        {
            if ( signOne == "" )
            {
                MessageBox.Show( "请检查模板数据源是否正确" );
                return;
            }
            _model.DJ002 = comboBox1.Text;
            _model.DJ003 = textBox2.Text;
            if ( !string.IsNullOrEmpty( _model.DJ003 ) && _model.DJ003.Contains( "'" ) )
            {
                _model.DJ003 = _model.DJ003.Replace( "'" ,"''" );
                if ( _model.DJ003.Contains( "\n" ) || _model.DJ003.Contains( "\r" ) )
                {
                    _model.DJ003 = _model.DJ003.Replace( "\n" ," " );
                    _model.DJ003 = _model.DJ003.Replace( "\r" ," " );
                }
            }
            _model.DJ004 = textBox4.Text;
            if ( !string.IsNullOrEmpty( _model.DJ004 ) && _model.DJ004.Contains( "'" ) )
            {

                _model.DJ004 = _model.DJ004.Replace( "'" ,"''" );
                if ( _model.DJ004.Contains( "\n" ) || _model.DJ004.Contains( "\r" ) )
                {
                    _model.DJ004 = _model.DJ004.Replace( "\n" ," " );
                    _model.DJ004 = _model.DJ004.Replace( "\r" ," " );
                }
            }
            _model.DJ005 = textBox3.Text;
            if ( !string.IsNullOrEmpty( _model.DJ005 ) && _model.DJ005.Contains( "'" ) )
            {
                _model.DJ005 = _model.DJ005.Replace( "'" ,"''" );
                if ( _model.DJ005.Contains( "\n" ) || _model.DJ005.Contains( "\r" ) )
                {
                    _model.DJ005 = _model.DJ005.Replace( "\n" ," " );
                    _model.DJ005 = _model.DJ005.Replace( "\r" ," " );
                }
            }
            _model.DJ006 = textBox5.Text;
            if ( !string.IsNullOrEmpty( _model.DJ006 ) && _model.DJ006.Contains( "'" ) )
            {
                _model.DJ006 = _model.DJ006.Replace( "'" ,"''" );
                if ( _model.DJ006.Contains( "\n" ) || _model.DJ006.Contains( "\r" ) )
                {
                    _model.DJ006 = _model.DJ006.Replace( "\n" ," " );
                    _model.DJ006 = _model.DJ006.Replace( "\r" ," " );
                }
            }
            _model.DJ007 = DateTime.Now;
            result = _bll.AddTableOfSql( _model );
            if ( result == true )
                MessageBox.Show( "数据源保存成功" );
            else
                MessageBox.Show( "数据源保存失败,请重试" );
        }
        #endregion

    }
}
