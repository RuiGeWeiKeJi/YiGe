using FastReport;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace YiGeQuery
{
    public partial class FormOneQuery : Form
    {
        public FormOneQuery ( )
        {
            InitializeComponent( );
        }
        
        YiGeBll.Bll.VerBll _bll = new YiGeBll.Bll.VerBll( );
        YiGeEntiry.VersionEntity _model = new YiGeEntiry.VersionEntity( );
        DataTable tableOnly, tableOnlys, print, prints, tableOfPeople;
        Report report = new Report( );
        DataSet RDataSet = new DataSet( ); EcanRMB rmb = new EcanRMB( );
        string strWhereOne = "1=1", file = "", sign = "", strWhereTwo = "1=1", strWhereTre = "1=1", signOf = "";
        public string signOfPtint = "";

        private void FormOneQuery_Load ( object sender ,EventArgs e )
        {
            tableOnly = new DataTable( );
            tableOnlys = new DataTable( );
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = -1;
            textBox3.Text ="";
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

        // 采购单
        void createPurchaseOrder ( string signOfName,string strWhere)
        {
            RDataSet = new DataSet( );
            signOf = "";
            print = _bll.GetDataTablePrint( strWhere ,signOfName );
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

            strWhereOne = strWhereTwo = strWhereTre = "1=1";
            if ( lookUpEdit1 . EditValue != null )
            {
                string [ ] str = lookUpEdit1 . Text . Split ( '-' );
                _model . TC001 = _model . TE001 = _model . TA001 = str [ 0 ] . Trim ( );
                _model . TC002 = _model . TE002 = _model . TA002 = str [ 1 ] . Trim ( );
                if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    _model . TC003 = _model . TA003 = DateTime . Now . ToString ( "yyyyMMdd" );
                else
                    _model . TC003 = _model . TA003 = dateTimePicker1 . Value . ToString ( "yyyyMMdd" );
                _model . TE004 = _model . TC003;
                strWhereOne = strWhereOne + " AND TC001='" + _model . TC001 + "' AND TC002='" + _model . TC002 + "' AND TC003='" + _model . TC003 + "'";
                strWhereTwo = strWhereTwo + " AND TE001='" + _model . TE001 + "' AND TE002='" + _model . TE002 + "' AND TE004='" + _model . TE004 + "'";
                strWhereTre = strWhereTre + " AND TE001='" + _model . TE001 + "' AND TE002='" + _model . TE002 + "' AND TE004='" + _model . TE004 + "'";
            }
            if ( lookUpEdit2.EditValue != null )
            {
                _model.TC004 = _model.TA004 =_model.TE007=_model.TE005= lookUpEdit2.Text;
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                    _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
                else
                    _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                _model.TA003 = _model.TE004 = _model.TC003;
                strWhereOne = strWhereOne + " AND TC003='" + _model.TC003 + "' AND TC004='" + _model.TC004 + "'";
                strWhereTwo = strWhereTwo + " AND TE004='" + _model.TE004 + "' AND TE007='" + _model.TE007 + "'";
                strWhereTre = strWhereTre + " AND TE004='" + _model.TE004 + "' AND TE005='" + _model.TE005 + "'";
            }
            if ( lookUpEdit3.EditValue != null && lookUpEdit3.Text != "" )
            {
                _model.TC014 = _model.TE029 = _model.TE017 = lookUpEdit3.Text;
                strWhereOne = strWhereOne + " AND TC014='" + _model.TC014 + "'";
                strWhereTwo = strWhereTwo + " AND TE029='" + _model.TE029 + "'";
                strWhereTre = strWhereTre + " AND TE017='" + _model.TE017 + "'";
            }
            if ( lookUpEdit4.EditValue != null && lookUpEdit4.Text != "" )
            {
                _model.MV001 = lookUpEdit4.EditValue.ToString( );
                strWhereOne = strWhereOne + " AND MV001='" + _model.MV001 + "'";
                strWhereTwo = strWhereTwo + " AND MV001='" + _model.MV001 + "'";
                strWhereTre = strWhereTre + " AND MV001='" + _model.MV001 + "'";
            }
            file = "";
            if ( signOfPtint == "" )
                return;
            switch ( signOfPtint )
            {
                case "10":
                file = Application.StartupPath + "\\嘉兴依格采购.frx";
                report.Load( file );
                createPurchaseOrder( "采购单" ,strWhereOne );
                break;
                case "11":
                file = Application.StartupPath + "\\浩律科贸采购.frx";
                report.Load( file );
                createPurchaseOrder( "采购单" ,strWhereOne );
                break;
                case "12":
                file = Application.StartupPath + "\\鲁澜工贸采购.frx";
                report.Load( file );
                createPurchaseOrder( "采购单" ,strWhereOne );
                break;
                case "13":
                file = Application.StartupPath + "\\国外采购.frx";
                report.Load( file );
                createPurchaseOrder( "国外采购单" ,strWhereOne );
                break;
                case "14":
                file = Application.StartupPath + "\\订单变更单.frx";
                report.Load( file );
                createPurchaseOrder( "订单变更单" ,strWhereTwo );
                break;
                case "15":
                file = Application.StartupPath + "\\采购变更单.frx";
                report.Load( file );
                createPurchaseOrder( "采购变更单" ,strWhereTre );
                break;
            }
            if ( signOf == "1" )
                return;
            report.RegisterData( RDataSet );
            report.Show( );
        }
        //Close
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
            textBox3.Text = textBox1.Text = "";

            tableOnly = tableOnlys = null;

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
                textBox3.Text = lookUpEdit2.EditValue.ToString( );

                if ( sign != "1" )
                {
                    lookUpEdit1.EditValue = null;
                    lookUpEdit1.ItemIndex = -1;
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                    _model.TE004 = _model.TC003;
                    _model.TC004 = _model.TE007 = _model.TE005 = lookUpEdit2.Text;

                    tableOnly = null;
                    if ( signOfPtint == "10" || signOfPtint == "11" || signOfPtint == "12" || signOfPtint == "13" )
                    {
                        tableOnly = _bll.GetDataTableOnlyTwo( _model.TC003 ,_model.TC004 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "14" )
                    {
                        tableOnly = _bll.GetDataTableOnlyTre( _model.TE004 ,_model.TE007 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "15" )
                    {
                        tableOnly = _bll.GetDataTableOnlyFor( _model.TE004 ,_model.TE005 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( signOfPtint == "16" )
                    {

                    }
                    else if ( signOfPtint == "17" )
                    {

                    }
                    else if ( signOfPtint == "27" )
                    {

                    }
                    else if ( signOfPtint == "28" )
                    {

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
                    _model.TC001 = _model.TE001= str[0].Trim( );
                    _model.TC002 = _model.TE002= str[1].ToString( );
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        _model.TC003 = _model.TE004 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TC003 = _model.TE004 = dateTimePicker1.Value.ToString( "yyyyMMdd" );

                    tableOnlys = null;
                    if ( signOfPtint == "10" || signOfPtint == "11" || signOfPtint == "12" || signOfPtint == "13" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyTwos( _model.TC001 ,_model.TC002 ,_model.TC003 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "14" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyTres( _model.TE001 ,_model.TE002 ,_model.TE004 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "15" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyFors( _model.TE001 ,_model.TE002 ,_model.TE004 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( signOfPtint == "16" )
                    {

                    }
                    else if ( signOfPtint == "17" )
                    {

                    }
                    else if ( signOfPtint == "27" )
                    {

                    }
                    else if ( signOfPtint == "28" )
                    {

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
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                _model.TC003 = DateTime.Now.ToString( "yyyyMMdd" );
            else
                _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
            _model.TE004 = _model.TC003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
            tableOnly = tableOnlys = null;

            //if ( lookUpEdit4.EditValue == null && lookUpEdit3.EditValue == null )
            //    return;
            if ( lookUpEdit4.EditValue != null )
                _model.MV001 = lookUpEdit4.EditValue.ToString( );

            if ( lookUpEdit3.EditValue != null )
                _model.TC014 = _model.TE029 = _model.TE017 = lookUpEdit3.Text;

            if ( signOfPtint == "10" || signOfPtint == "11" || signOfPtint == "12" || signOfPtint == "13" )
            {
                tableOnly = _bll.GetDataTableOnlyTwo( _model.TC003 ,_model.MV001 ,_model.TC014 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlysTwo( _model.TC003 ,_model.MV001 ,_model.TC014 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( signOfPtint == "14" )
            {
                tableOnly = _bll.GetDataTableOnlyTre( _model.TE004 ,_model.MV001 ,_model.TE029 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlysTre( _model.TE004 ,_model.MV001 ,_model.TE029 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( signOfPtint == "15" )
            {
                tableOnly = _bll.GetDataTableOnlyFor( _model.TE004 ,_model.MV001 ,_model.TE017 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
                tableOnlys = _bll.GetDataTableOnlysFor( _model.TE004 ,_model.MV001 ,_model.TE017 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
        }

    }
}
