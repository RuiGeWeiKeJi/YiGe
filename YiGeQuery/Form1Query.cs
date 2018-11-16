using System;
using System . Data;
using System . Windows . Forms;
using FastReport;
using Mulaolao . Class;

namespace YiGeQuery
{
    public partial class Form1Query : Form
    {
        public Form1Query ( )
        {
            InitializeComponent( );
        }
        
        YiGeBll.Bll.VerBll _bll = new YiGeBll.Bll.VerBll( );
        YiGeEntiry.VersionEntity _model = new YiGeEntiry.VersionEntity( );
        DataTable tableOnly, tableOnlys, print, prints, tableOfPeople;
        Report report = new Report( );
        DataSet RDataSet = new DataSet( ); EcanRMB rmb = new EcanRMB( );
        string strWhereOne = "1=1", file = "", sign = "", strWhereTwo = "1=1", strWhereTre = "1=1", strWhereFor = "1=1",strWhereFiv="1=1", signOf = "";

        public string signOfPtint = "";

        private void Form1Query_Load ( object sender ,EventArgs e )
        {
            tableOnly = new DataTable( );
            tableOnlys = new DataTable( );
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = -1;
            textBox3.Text =  "";
            textBox1.Text = DateTime.Now.ToString( "yyyy年MM月dd日" );
            dateTimePicker1.Value = DateTime.Now;

            DataTable tableOne = new DataTable( );
            if ( tableOne != null && tableOne.Rows.Count > 0 )
                return;
            tableOne = new DataTable( "data" );
            tableOne.Columns.Add( "SH" ,Type.GetType( "System.String" ) );
            tableOne.Rows.Add( "" );
            tableOne.Rows.Add( "Y" );
            tableOne.Rows.Add( "N" );
            lookUpEdit3.Properties.DataSource = tableOne;
            lookUpEdit3.Properties.DisplayMember = "SH";
            
            tableOfPeople = _bll.GetDataTableOfPeopleOne( );
            lookUpEdit4.Properties.DataSource = tableOfPeople;
            lookUpEdit4.Properties.DisplayMember = "MV002";
            lookUpEdit4.Properties.ValueMember = "MV001";
        }
        
        //PirntTable
        void createRDataSet (string signOfName,string strWhere )
        {
            RDataSet = new DataSet( );
            signOf = "";
            print = _bll.GetDataTablePrint( strWhere ,signOfName);
            if ( print == null )
            {
                MessageBox.Show( "" + signOfName + "模板数据源为空" );
                signOf = "1";
                return;
            }
            /*
            prints = _bll.GetDataTableTotal( strWhere ,signOfName );
            if ( prints != null && prints.Rows.Count > 0 )
            {
                report.SetParameterValue( "小写合计" ,prints.Rows[0]["小写合计"].ToString( ) );
                if ( !string.IsNullOrEmpty( prints.Rows[0]["小写合计"].ToString( ) ) )
                    report.SetParameterValue( "小写合计大写" ,rmb.CmycurD( Convert.ToDecimal( prints.Rows[0]["小写合计"].ToString( ) ) ) );
                prints.TableName = "COPTC";
                RDataSet.Tables.Add( prints );
            }
            */
            //else
            //{
            //    report.SetParameterValue( "小写合计" ,0 );
            //    report.SetParameterValue( "小写合计大写" ,0 );
            //    //prints.TableName = "COPTC";
            //    //RDataSet.Tables.Add( prints );
            //}
            print.TableName = "COPMA";
            RDataSet.Tables.Add( print );
        }
        
        //Print
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue == null )
            {
                MessageBox.Show( "单号、单别不可为空" );
                return;
            }
            //if ( lookUpEdit3.EditValue == null && lookUpEdit4.EditValue==null)
            //{
            //    MessageBox.Show( "审核码或业务员不可都为空" );
            //    return;
            //}
            strWhereOne = strWhereTwo = strWhereTre = strWhereFor = strWhereFiv = "1=1";
            if ( lookUpEdit1.EditValue !=null )
            {
                string[] str = lookUpEdit1.Text.Split( '-' );
                _model.TC001 = _model.TA001 = _model.TG001 = str[0].Trim( );
                _model.TC002 = _model.TA002 = _model.TG002 = str[1].Trim( );
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                    _model.TC003 = _model.TA003 = DateTime.Now.ToString( "yyyyMMdd" );
                else
                    _model.TC003 = _model.TA003 = _model.TG003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                strWhereOne = strWhereOne + " AND A.TC001='" + _model.TC001 + "' AND A.TC002='" + _model.TC002 + "' AND A.TC003='" + _model.TC003 + "'";
                strWhereTwo = strWhereTwo + " AND TA001='" + _model.TA001 + "' AND TA002='" + _model.TA002 + "' AND TA003='" + _model.TA003 + "'";
                strWhereTre = strWhereTre + " AND TG001='" + _model.TG001 + "' AND TG002='" + _model.TG002 + "' AND TG003='" + _model.TG003 + "'";
                strWhereFor = strWhereFor + " AND TG001='" + _model.TG001 + "' AND TG002='" + _model.TG002 + "' AND TG003='" + _model.TG003 + "'";
                strWhereFiv = strWhereFiv + " AND A.TC001='" + _model . TC001 + "' AND A.TC002='" + _model . TC002 + "' AND A.TC003='" + _model . TC003 + "'";
            }
            if ( lookUpEdit2.EditValue != null )
            {
                _model.TG004 = _model.TC004 = _model.TA004 =_model.TG005= lookUpEdit2.Text;
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                    _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
                else
                    _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                _model.TG003 = _model.TA003 = _model.TC003;
                strWhereOne = strWhereOne + " AND A.TC003='" + _model.TC003 + "' AND A.TC004='" + _model.TC004 + "'";
                strWhereTwo = strWhereTwo + " AND TA003='" + _model.TA003 + "' AND TA004='" + _model.TA004 + "'";
                strWhereTre = strWhereTre + " AND TG003='" + _model.TG003 + "' AND TG004='" + _model.TG004 + "'";
                strWhereFor = strWhereFor + " AND TG003='" + _model.TG003 + "' AND TG005='" + _model.TG005 + "'";
                strWhereFiv = strWhereFiv + " AND A.TC003='" + _model . TC003 + "' AND A.TC004='" + _model . TC004 + "'";
            }
            if ( lookUpEdit3.EditValue != null && lookUpEdit3.Text!="")
            {
                _model . TC027 = _model . TA019 = _model . TG023 = _model . TD021 = lookUpEdit3 . Text;
                strWhereOne = strWhereOne + " AND TC027='" + _model.TC027 + "'";
                strWhereTwo = strWhereTwo + " AND TA019='" + _model.TA019 + "'";
                strWhereTre = strWhereTre + " AND TG023='" + _model.TG023 + "'";
                strWhereFor = strWhereFor + " AND TG013='" + _model.TG023 + "'";
                strWhereFiv = strWhereFiv + " AND TD021='" + _model . TG023 + "'";
            }
            if ( lookUpEdit4.EditValue != null && lookUpEdit4.Text != "" )
            {
                _model.MV001 = lookUpEdit4.EditValue.ToString( );
                strWhereOne = strWhereOne + " AND MV001='" + _model.MV001 + "'";
                strWhereTwo = strWhereTwo + " AND MV001='" + _model.MV001 + "'";
                strWhereTre = strWhereTre + " AND MV001='" + _model.MV001 + "'";
                strWhereFor = strWhereFor + " AND MV001='" + _model.MV001 + "'";
                strWhereFiv = strWhereFiv + " AND MV001='" + _model . MV001 + "'";
            }

            if ( signOfPtint == "" )
                return;
            file = "";
            switch ( signOfPtint )
            {
                case "1":
                file = Application.StartupPath + "\\嘉兴依格订单.frx";
                report.Load( file );
                createRDataSet( "订单",strWhereOne);
                break;
                case "2":
                file = Application.StartupPath + "\\浩律科贸订单.frx";
                report.Load( file );
                createRDataSet( "订单",strWhereOne );
                break;
                case "3":
                file = Application.StartupPath + "\\上海依格订单.frx";
                report.Load( file );
                createRDataSet( "订单",strWhereOne );
                break;
                case "4":
                file = Application.StartupPath + "\\国外订单.frx";
                report.Load( file );
                createRDataSet( "国外订单" ,strWhereOne );
                break;
                case "5":
                file = Application.StartupPath + "\\备货单.frx";
                report.Load( file );
                createRDataSet( "订单",strWhereOne );
                break;
                case "6":
                file = Application.StartupPath + "\\嘉兴依格报价.frx";
                report.Load( file );
                createRDataSet( "报价单" ,strWhereTwo );
                break;
                case "7":
                file = Application.StartupPath + "\\浩律科贸报价.frx";
                report.Load( file );
                createRDataSet( "报价单" ,strWhereTwo );
                break;
                case "8":
                file = Application.StartupPath + "\\上海依格报价.frx";
                report.Load( file );
                createRDataSet( "报价单" ,strWhereTwo );
                break;
                case "9":
                file = Application.StartupPath + "\\国外报价.frx";
                report.Load( file );
                createRDataSet( "国外报价单" ,strWhereTwo );
                break;
                case "16":
                file = Application.StartupPath + "\\进货单.frx";
                report.Load( file );
                createRDataSet("进货单" ,strWhereFor );
                break;
                case "18":
                file = Application.StartupPath + "\\嘉兴依格装箱单.frx";
                report.Load( file );
                createRDataSet("装箱单" ,strWhereTre );
                break;
                case "19":
                file = Application.StartupPath + "\\浩律科贸装箱单.frx";
                report.Load( file );
                createRDataSet( "装箱单" ,strWhereTre );
                break;
                case "20":
                file = Application.StartupPath + "\\上海依格装箱单.frx";
                report.Load( file );
                createRDataSet( "装箱单" ,strWhereTre );
                break;
                case "21":
                file = Application.StartupPath + "\\国外装箱单.frx";
                report.Load( file );
                createRDataSet( "国外装箱单" ,strWhereTre );
                break;
                case "30":
                file = Application . StartupPath + "\\合格证.frx";
                report . Load ( file );
                createRDataSet ( "合格证" ,strWhereFiv );
                break;
            }
            if ( signOf == "1" )
                return;
            report.RegisterData( RDataSet );
            report.Show( );
        }
        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );          
        }
        //Clear
        private void button3_Click ( object sender ,EventArgs e )
        {
            sign = "";
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = -1;
            textBox3.Text =textBox1.Text= "";
   
            tableOnly = tableOnlys = null;
            textBox3.Text = "";

            textBox1 . Text = DateTime . Now . ToString ( "yyyy年MM月dd日" );
            dateTimePicker1 . Value = DateTime . Now;
        }

        //Event
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            query( );
            textBox3.Text = "";
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
        private void lookUpEdit2_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit2.EditValue != null )
            {
                textBox3.Text = lookUpEdit2.Text;

                if ( sign != "1" )
                {
                    lookUpEdit1.EditValue = null;
                    lookUpEdit1.ItemIndex = -1;
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                    _model.TG003 = _model.TC003;
                    _model.TC004 = _model.TG004 = lookUpEdit2.Text;

                    tableOnly = null;
                    lookUpEdit1.Properties.DataSource = null;
                    if ( signOfPtint == "1" || signOfPtint == "2" || signOfPtint == "3" || signOfPtint == "4" || signOfPtint == "5" )
                    {
                        tableOnly = _bll.GetDataTableOnly( _model.TC004 ,_model.TC003 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "6" || signOfPtint == "7" || signOfPtint == "8" || signOfPtint == "9" )
                    {
                        tableOnly = _bll.GetDataTableOnlyOne( _model.TC004 ,_model.TC003 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "18" || signOfPtint == "19" || signOfPtint == "20" || signOfPtint == "21" )
                    {
                        tableOnly = _bll.GetDataTableOnlyFiv( _model.TC003 ,_model.TC004 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "16" )
                    {
                        tableOnly = _bll.GetDataTableOnlySix( _model.TC003 ,_model.TC004 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    sign = "2";
                }
            }
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                if ( sign != "2" )
                {
                    lookUpEdit2.EditValue = null;
                    lookUpEdit2.ItemIndex = -1;
                    string[] str = lookUpEdit1.Text.Split( '-' );
                    _model.TC001 = _model.TG001 = str[0].Trim( );
                    _model.TC002 = _model.TG002 = str[1].Trim( );
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                    _model.TG003 = _model.TC003;
                    tableOnlys = null;

                    if ( signOfPtint == "1" || signOfPtint == "2" || signOfPtint == "3" || signOfPtint == "4" || signOfPtint == "5" )
                    {
                        tableOnlys = _bll.GetDataTableOnlys( _model.TC001 ,_model.TC002 ,_model.TC003 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "6" || signOfPtint == "7" || signOfPtint == "8" || signOfPtint == "9" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyOnes( _model.TC001 ,_model.TC002 ,_model.TC003 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "18" || signOfPtint == "19" || signOfPtint == "20" || signOfPtint == "21" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyFivs( _model.TG001 ,_model.TG002 ,_model.TG003 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "16" )
                    {
                        tableOnlys = _bll.GetDataTableOnlySixs( _model.TG001 ,_model.TG002 ,_model.TG003 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    textBox3.Text = "";
                    sign = "1";
                }        
            }
        }
        private void lookUpEdit4_EditValueChanged ( object sender ,EventArgs e )
        {
            query( );
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            query( );
        }
        void query ( )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yyyy年MM月dd日" );
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = -1;
            tableOnly = tableOnlys = null;

            if ( string.IsNullOrEmpty( textBox1.Text ) )
                _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
            else
                _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
            _model.TG003 = _model.TC003;
            //if ( lookUpEdit4.EditValue == null && lookUpEdit3.EditValue == null )
            //    return;
            if ( lookUpEdit4.EditValue != null )
                _model.MV001 = lookUpEdit4.EditValue.ToString( );
            if ( lookUpEdit3.EditValue != null )
                _model.TC027 = _model.TA019 = _model.TG023 = _model.TH020 = lookUpEdit3.Text;

            if ( signOfPtint == "1" || signOfPtint == "2" || signOfPtint == "3" || signOfPtint == "4" || signOfPtint == "5" || signOfPtint == "30" )
            {
                tableOnly = _bll.GetDataTableOnly( _model.TC003 ,_model.TC027 ,_model.MV001  );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlyes( _model.TC003 , _model.TC027,_model.MV001 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( signOfPtint == "6" || signOfPtint == "7" || signOfPtint == "8" || signOfPtint == "9" )
            {
                tableOnly = _bll.GetDataTableOnlyOne( _model.TC003 ,_model.TA019 ,_model.MV001 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlyOnese( _model.TC003 ,_model.TA019 ,_model.MV001 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( signOfPtint == "18" || signOfPtint == "19" || signOfPtint == "20" || signOfPtint == "21" )
            {
                tableOnly = _bll.GetDataTableOnlyFiv( _model.TG003 ,_model.MV001 ,_model.TG023 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlysFiv( _model.TG003 ,_model.MV001 ,_model.TG023 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( signOfPtint == "16" )
            {
                tableOnly = _bll.GetDataTableOnlySix( _model.TG003 ,_model.MV001 ,_model.TG023 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlysSix( _model.TG003 ,_model.MV001 ,_model.TG023 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
        }

    }
}
