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
    public partial class FormSevQuery : Form
    {
        public FormSevQuery ( )
        {
            InitializeComponent( );
        }

        YiGeBll.Bll.VerBll _bll = new YiGeBll.Bll.VerBll( );
        YiGeEntiry.VersionEntity _model = new YiGeEntiry.VersionEntity( );
        DataTable tableOnly = new DataTable( ); DataTable tableOnlys = new DataTable( );
        DataTable print, prints;
        Report report = new Report( );
        DataSet RDataSet = new DataSet( ); EcanRMB rmb = new EcanRMB( );
        string strWhere = "", file = "", signOf = "", strWhereOne = "", signs = "";
        public string sign = "";

        private void FormSevQuery_Load ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue= null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
            textBox3.Text = "";
            tableOnly = tableOnlys = null;
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

            if ( sign == "27" )
                label7.Text = "委外进货单单别、单号";
            else
                label7.Text = "委外退货单单别、单号";
        }

        void createRDataSet ( string signOfName ,string strWhere )
        {
            RDataSet = new DataSet( );
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
            if ( lookUpEdit2.EditValue == null )
            {
                MessageBox.Show( "退料单单别、单号不可为空" );
                return;
            }
            //if ( lookUpEdit3.EditValue == null )
            //{
            //    MessageBox.Show( "审核码不可为空" );
            //    return;
            //}
            strWhere = strWhereOne = "1=1";
            if ( lookUpEdit1.Text != null && lookUpEdit1.Text != "==请选择==" )
            {
                _model.TI001 = _model.TK001 = lookUpEdit1.Text.Split( '-' )[0].Trim( );
                _model.TI002 = _model.TK002 = lookUpEdit1.Text.Split( '-' )[1].Trim( );
                strWhere = strWhere + "AND TI001='" + _model.TI001 + "' AND TI002='" + _model.TI002 + "'";
                strWhereOne = strWhereOne + " AND TK001='" + _model.TK001 + "' AND TK002='" + _model.TK002 + "'";
            }
            if ( lookUpEdit2.Text != null && lookUpEdit2.Text != "==请选择==" )
            {
                _model.TH005 = _model.TK004 = lookUpEdit2.Text;
                strWhere = strWhere + "AND TH005='" + _model.TH005 + "'";
                strWhereOne = strWhereOne + " AND TK004='" + _model.TK004 + "'";
            }
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                _model.TH003 = _model.TK003 = DateTime.Now.ToString( "yyyyMMdd" );
            else
                _model.TH003 = _model.TK003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );

            strWhere = strWhere + " AND TC003='" + _model.TC003 + "'";
            strWhereOne = strWhereOne + " AND TK003='" + _model.TK003 + "'";

            if ( lookUpEdit3.EditValue != null && lookUpEdit3.Text != "" )
            {
                _model.TH023 = _model.TK021 = lookUpEdit3.Text;
                strWhere = strWhere + " AND TH023='" + _model.TH023 + "'";
                strWhereOne = strWhereOne + " AND TK021='" + _model.TK021 + "'";
            }

            if ( sign == "" )
                return;
            file = "";
            switch ( signOf )
            {
                case "27":
                file = Application.StartupPath + "\\委外进货单.frx";
                report.Load( file );
                createRDataSet( "委外进货单" ,strWhere );
                break;

                case "28":
                file = Application.StartupPath + "\\委外退货单.frx";
                report.Load( file );
                createRDataSet( "委外退货单" ,strWhereOne );
                break;
            }
            if ( signOf == "" )
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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
            textBox3.Text = "";
            tableOnly = tableOnlys = null;
            textBox1.Text = DateTime.Now.ToString( "yyyy年MM月dd日" );
            dateTimePicker1.Value = DateTime.Now;
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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                _model.TH003 = _model.TK003 = DateTime.Now.ToString( "yyyyMMdd" );
            else
                _model.TH003 = _model.TK003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );

            tableOnly = tableOnlys = null;

            //if ( lookUpEdit3.EditValue == null )
            //    return;

            _model.TH023 = _model.TK021 = lookUpEdit3.Text;

            if ( sign == "27" )
            {
                tableOnly = _bll.GetDataTableOnlyThreese( _model.TH003 ,_model.TH023 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";

                tableOnlys = _bll.GetDataTableOnlyThrese( _model.TH003 ,_model.TH023 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
            else if ( sign == "28" )
            {
                tableOnly = _bll.GetDataTableOnlyFoures( _model.TK003 ,_model.TK021 );
                lookUpEdit1.Properties.DataSource = tableOnly;
                lookUpEdit1.Properties.DisplayMember = "TC";

                tableOnlys = _bll.GetDataTableOnlyFourse( _model.TK003 ,_model.TK021 );
                lookUpEdit2.Properties.DataSource = tableOnlys;
                lookUpEdit2.Properties.DisplayMember = "MA001";
                lookUpEdit2.Properties.ValueMember = "MA003";
            }
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                if ( signs != "2" )
                {
                    lookUpEdit2.EditValue = null;
                    lookUpEdit2.ItemIndex = -1;
                    string[] str = lookUpEdit1.Text.Split( '-' );
                    _model.TI001 = _model.TK001 = str[0].Trim( );
                    _model.TI002 = _model.TK002 = str[1].Trim( );
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        _model.TH003 = _model.TK003 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TH003 = _model.TK003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );
                    tableOnlys = null;

                    if ( sign == "27" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyThree( _model.TI001 ,_model.TI002 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                    else if ( sign == "28" )
                    {
                        tableOnlys = _bll.GetDataTableOnlyFours( _model.TK001 ,_model.TK002 );
                        lookUpEdit2.Properties.DataSource = tableOnlys;
                        lookUpEdit2.Properties.DisplayMember = "MA001";
                        lookUpEdit2.Properties.ValueMember = "MA003";
                    }
                }
                textBox3.Text = "";
                sign = "1";
            }
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
                        _model.TH003 = _model.TK003 = DateTime.Now.ToString( "yyyyMMdd" );
                    else
                        _model.TH003 = _model.TK003 = dateTimePicker1.Value.ToString( "yyyyMMdd" );

                    _model.TH005 = _model.TK004 = lookUpEdit2.Text;

                    tableOnly = null;
                    lookUpEdit1.Properties.DataSource = null;
                    if ( sign == "27" )
                    {
                        tableOnly = _bll.GetDataTableOnlyThrees( _model.TH005 ,_model.TH003 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                    else if ( sign == "28" )
                    {
                        tableOnly = _bll.GetDataTableOnlyFour( _model.TK004 ,_model.TK003 );
                        lookUpEdit1.Properties.DataSource = tableOnly;
                        lookUpEdit1.Properties.DisplayMember = "TC";
                    }
                }
            }
        }

    }
}
