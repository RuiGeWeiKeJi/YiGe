using AutoUpdate;
using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YiGe
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            AppUpdate au = new AppUpdate( );
            string msg = "";
            bool result = au.CheckAppVersion( ref msg );
            if ( result == true )
                System.Diagnostics.Process.Start( Application.StartupPath + @"\AutoUpdate.exe" );
            //Register re = new Register( );
            //bool result = re.Exists( );
            //if ( result == false )
            ////System.Diagnostics.Process.Start( Application.StartupPath + @"\RegistrationCode.exe" );
            //{
            //    Application.EnableVisualStyles( );
            //    Application.SetCompatibleTextRenderingDefault( false );
            //    Application.Run( new RegisterForm( ) );
            //}
            else
            {
                //if ( Encrypt.GetDataTable( ) == "1418" )
                //{

                try
                {
                    Application . EnableVisualStyles ( );
                    Application . SetCompatibleTextRenderingDefault ( false );
                    Application . Run ( new Form1 ( ) );
                }
                catch ( Exception ex )
                {
                    Utility . LogHelper . WriteLog ( ex . Message + " " + ex . StackTrace );
                }
                //}
            }
        }
    }
}
