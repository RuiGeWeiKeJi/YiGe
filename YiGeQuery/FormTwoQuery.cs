using FastReport;
using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YiGeQuery
{
    public partial class FormTwoQuery : Form
    {
        public FormTwoQuery ( )
        {
            InitializeComponent( );
        }
        YiGeBll.Bll.VerBll _bll = new YiGeBll.Bll.VerBll( );
        YiGeEntiry.VersionEntity _model = new YiGeEntiry.VersionEntity( );
        DataTable tableOnly = new DataTable( );
        DataTable print, prints, tableOfPeople;
        Report report = new Report( );
        DataSet RDataSet = new DataSet( ); EcanRMB rmb = new EcanRMB( );
        string strWhere = "", file = "", strWhereOne = "";
        public string sign = "";

        private void FormTwoQuery_Load ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit3.EditValue =  null;
            lookUpEdit1.ItemIndex = lookUpEdit3.ItemIndex = -1;
            tableOnly = null;
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
        }

        void createRdataSet (string signOfName,string strWhere )
        {
            RDataSet = new DataSet( );
            print = _bll.GetDataTablePrint( strWhere ,signOfName );
            if ( print == null )
            {
                MessageBox.Show( "" + signOfName + "模板数据源为空" );
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
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "单号、单别不可为空" );
                return;
            }
            //if ( lookUpEdit3.EditValue == null )
            //{
            //    MessageBox.Show( "审核码不可为空" );
            //    return;
            //}
            strWhere = strWhereOne = "1=1";
            if ( lookUpEdit1.EditValue != null )
            {
                string[] str = lookUpEdit1.Text.Split( '-' );
                _model.TA001 = _model.TO001 = str[0].Trim( );
                _model.TA002 = _model.TO002 = str[1].Trim( );
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                     _model.TA003 = _model.TO004 = DateTime.Now.ToString( "yyyyMMdd" );
                else
                    _model.TA003 = _model.TO004 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                strWhere = strWhere + " AND TA001='" + _model.TA001 + "' AND TA002='" + _model.TA002 + "' AND TA003='" + _model.TA003 + "'";
                strWhereOne = strWhereOne + " AND TO001='" + _model.TO001 + "' AND TO002='" + _model.TO002 + "' AND TO004='" + _model.TO004 + "'";             
            }
            if ( lookUpEdit3.EditValue != null && lookUpEdit3.Text != "" )
            {
                _model.TA013 = _model.TO041 = lookUpEdit3.Text;
                strWhere = strWhere + " AND TA013='" + _model.TA013 + "'";
            }

            file = "";
            switch ( sign )
            {
                case "22":
                file = Application.StartupPath + "\\工单.frx";
                report.Load( file );
                createRdataSet( "工单" ,strWhere );
                break;
                case "23":
                file = Application.StartupPath + "\\工单变更单.frx";
                report.Load( file );
                createRdataSet( "工单变更单" ,strWhereOne );
                break;
            }

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
            lookUpEdit1.EditValue = lookUpEdit3.EditValue =lookUpEdit3.EditValue=  null;
            lookUpEdit1.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit3.ItemIndex= -1;
             textBox1.Text = "";

            tableOnly = null;
            textBox1 . Text = DateTime . Now . ToString ( "yyyy年MM月dd日" );
            dateTimePicker1 . Value = DateTime . Now;
        }

        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
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
            lookUpEdit1.EditValue = null;
            lookUpEdit1.ItemIndex = -1;
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                _model.TA003 = _model.TO004 = DateTime.Now.ToString( "yyyyMMdd" );
            else
                _model.TA003 = _model.TO004 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
            tableOnly = null;

            //if ( lookUpEdit3.EditValue == null )
            //    return;
            _model.TA013 = _model.TO041 = lookUpEdit3.Text;

            if ( sign == "22" )
            {
                tableOnly = _bll.GetDataTableOnlySev( _model.TA003 ,_model.TA013 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
            }
            if ( sign == "23" )
            {
                tableOnly = _bll.GetDataTableOnlyEgi( _model.TO004 ,_model.TO041 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";
            }
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
    }
}
