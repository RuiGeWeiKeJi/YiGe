using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMgr;
using System.Data.SqlClient;
using System.Collections;

namespace YiGeBll.Dao
{
    public class VerDao
    {
        /// <summary>
        /// 获取查询条件字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string tc003 ,string tc027 ,string tc006 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc027 ) && !string.IsNullOrEmpty( tc006 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM COPTC WHERE TC003='{0}' AND TC027='{1}' AND TC006='{2}' ORDER BY TC001,TC002" ,tc003 ,tc027 ,tc006 );
            else if ( string.IsNullOrEmpty( tc027 ) && !string.IsNullOrEmpty( tc006 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM COPTC WHERE TC003='{0}' AND TC006='{1}' ORDER BY TC001,TC002" ,tc003 ,tc006 );
            else if ( string.IsNullOrEmpty( tc006 ) && !string.IsNullOrEmpty( tc027 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM COPTC WHERE TC003='{0}' AND TC027='{1}' ORDER BY TC001,TC002" ,tc003 ,tc027 );
            else if ( string.IsNullOrEmpty( tc027 ) && string.IsNullOrEmpty( tc006 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM COPTC WHERE TC003='{0}' ORDER BY TC001,TC002" ,tc003 );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnly ( string tc004,string tc003)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TC001+'-'+TC002 TC FROM COPTC" );
            strSql.Append( " WHERE TC004=@TC004 AND TC003=@TC003" );
            strSql.Append( " ORDER BY TC001,TC002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TC004",SqlDbType.Char,10),
                new SqlParameter("@TC003",SqlDbType.Char,8)
            };
            parameter[0].Value = tc004;
            parameter[1].Value = tc003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyes (string tc003 ,string tc027 ,string tc006 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc027 ) && !string.IsNullOrEmpty( tc006 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM  COPMA WHERE MA001 IN (SELECT TC004 FROM COPTC WHERE TC003='{0}' AND TC027='{1}' AND TC006='{2}' ) ORDER BY MA001,MA003" ,tc003 ,tc027 ,tc006 );
            else if ( string.IsNullOrEmpty( tc027 ) && !string.IsNullOrEmpty(tc006))
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM  COPMA WHERE MA001 IN (SELECT TC004 FROM COPTC WHERE TC003='{0}' AND TC006='{1}' ) ORDER BY MA001,MA003" ,tc003 ,tc006 );
            else if ( string.IsNullOrEmpty( tc006 ) && !string.IsNullOrEmpty(tc027))
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM  COPMA WHERE MA001 IN (SELECT TC004 FROM COPTC WHERE TC003='{0}' AND TC027='{1}' ) ORDER BY MA001,MA003" ,tc003 ,tc027 );
            else if ( string.IsNullOrEmpty( tc027 ) && string.IsNullOrEmpty( tc006 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM  COPMA WHERE MA001 IN (SELECT TC004 FROM COPTC WHERE TC003='{0}' ) ORDER BY MA001,MA003" ,tc003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlys ( string tc001 ,string tc002 ,string tc003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM COPMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TC004 FROM COPTC WHERE TC001=@TC001 AND TC002=@TC002 AND TC003=@TC003)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TC001",SqlDbType.Char,4),
                new SqlParameter("@TC002",SqlDbType.Char,11),
                new SqlParameter("@TC003",SqlDbType.Char,8)
            };
            parameter[0].Value = tc001;
            parameter[1].Value = tc002;
            parameter[2].Value = tc003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取报价单查询条件字段
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOne ( string ta003,string ta019,string ta005 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( ta019 ) && !string.IsNullOrEmpty( ta005 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM COPTA WHERE TA003='{0}' AND TA019='{1}' AND TA005='{2}' ORDER BY TA001,TA002" ,ta003 ,ta019 ,ta005 );
            else if ( string.IsNullOrEmpty( ta019 ) && !string.IsNullOrEmpty( ta005 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM COPTA WHERE TA003='{0}' AND TA005='{1}' ORDER BY TA001,TA002" ,ta003 ,ta005 );
            else if ( string.IsNullOrEmpty( ta005 ) && !string.IsNullOrEmpty( ta019 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM COPTA WHERE TA003='{0}' AND TA019='{1}' ORDER BY TA001,TA002" ,ta003 ,ta019 );
            else if( string.IsNullOrEmpty( ta019 ) && string.IsNullOrEmpty( ta005 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM COPTA WHERE TA003='{0}' ORDER BY TA001,TA002" ,ta003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyOne ( string ta004 ,string ta003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TA001+'-'+TA002 TC FROM COPTA" );
            strSql.Append( " WHERE TA004=@TA004 AND TA003=@TA003" );
            strSql.Append( " ORDER BY TA001,TA002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TA004",SqlDbType.Char,10),
                new SqlParameter("@TA003",SqlDbType.Char,8)
            };
            parameter[0].Value = ta004;
            parameter[1].Value = ta003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyOnese ( string ta003,string ta019,string ta005 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( ta019 ) && !string.IsNullOrEmpty( ta005 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TA004 FROM COPTA WHERE TA003='{0}' AND TA019='{1}' AND TA005='{2}') ORDER BY MA001,MA003" ,ta003 ,ta019 ,ta005 );
            else if ( string.IsNullOrEmpty( ta019 ) && !string.IsNullOrEmpty( ta005 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TA004 FROM COPTA WHERE TA003='{0}' AND TA005='{1}') ORDER BY MA001,MA003" ,ta003 ,ta005 );
            else if ( string.IsNullOrEmpty( ta005 ) && !string.IsNullOrEmpty( ta019 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TA004 FROM COPTA WHERE TA003='{0}' AND TA019='{1}' ) ORDER BY MA001,MA003" ,ta003 ,ta019 );
            else if ( string.IsNullOrEmpty( ta005 ) && string.IsNullOrEmpty( ta019 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TA004 FROM COPTA WHERE TA003='{0}') ORDER BY MA001,MA003" ,ta003 );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyOnes ( string ta001 ,string ta002 ,string ta003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM COPMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TA004 FROM COPTA WHERE TA001=@TA001 AND TA002=@TA002 AND TA003=@TA003)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TA001",SqlDbType.Char,4),
                new SqlParameter("@TA002",SqlDbType.Char,11),
                new SqlParameter("@TA003",SqlDbType.Char,8)
            };
            parameter[0].Value = ta001;
            parameter[1].Value = ta002;
            parameter[2].Value = ta003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 采购单查询条件字段
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTwo ( string tc003 ,string tc011,string tc014)
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc011 ) && !string.IsNullOrEmpty( tc014 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM PURTC WHERE TC003='{0}' AND TC011='{1}' AND TC014='{2}' ORDER BY TC001,TC002" ,tc003 ,tc011 ,tc014 );
            else if ( string.IsNullOrEmpty( tc011 ) && !string.IsNullOrEmpty( tc014 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM PURTC WHERE TC003='{0}' AND TC014='{1}' ORDER BY TC001,TC002" ,tc003 ,tc014 );
            else if ( string.IsNullOrEmpty( tc014 ) && !string.IsNullOrEmpty( tc011 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM PURTC WHERE TC003='{0}' AND TC011='{1}' ORDER BY TC001,TC002" ,tc003 ,tc011 );
            else if ( string.IsNullOrEmpty( tc014 ) && string.IsNullOrEmpty( tc011 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM PURTC WHERE TC003='{0}' ORDER BY TC001,TC002" ,tc003 );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlysTwo ( string tc003 ,string tc011,string tc014)
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc011 ) && !string.IsNullOrEmpty( tc014 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TC004 FROM PURTC WHERE TC003='{0}' AND TC011='{1}' AND TC014='{2}') ORDER BY MA001,MA003" ,tc003 ,tc011 ,tc014 );
            else if ( string.IsNullOrEmpty( tc011 ) && !string.IsNullOrEmpty( tc014 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TC004 FROM PURTC WHERE TC003='{0}' AND TC014='{1}') ORDER BY MA001,MA003" ,tc003 ,tc014 );
            else if ( string.IsNullOrEmpty( tc014 ) && !string.IsNullOrEmpty( tc011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TC004 FROM PURTC WHERE TC003='{0}' AND TC011='{1}' ) ORDER BY MA001,MA003" ,tc003 ,tc011 );
            else if ( string.IsNullOrEmpty( tc014 ) && string.IsNullOrEmpty( tc011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TC004 FROM PURTC WHERE TC003='{0}' ) ORDER BY MA001,MA003" ,tc003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTwo ( string tc004 ,string tc003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TC001+'-'+TC002 TC FROM PURTC" );
            strSql.Append( " WHERE TC004=@TC004 AND TC003=@TC003" );
            strSql.Append( " ORDER BY TC001,TC002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TC004",SqlDbType.Char,10),
                new SqlParameter("@TC003",SqlDbType.Char,8)
            };
            parameter[0].Value = tc004;
            parameter[1].Value = tc003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyTwos ( string tc001 ,string tc002 ,string tc003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM PURMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TC004 FROM PURTC WHERE TC001=@TC001 AND TC002=@TC002 AND TC003=@TC003)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TC001",SqlDbType.Char,4),
                new SqlParameter("@TC002",SqlDbType.Char,11),
                new SqlParameter("@TC003",SqlDbType.Char,8)
            };
            parameter[0].Value = tc001;
            parameter[1].Value = tc002;
            parameter[2].Value = tc003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 订单变更单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTre ( string te004 ,string te011,string te029 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te029 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM COPTE WHERE TE004='{0}' AND TE011='{1}' AND TE029='{2}' GROUP BY TE001,TE002" ,te004 ,te011 ,te029 );
            else if ( string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te029 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM COPTE WHERE TE004='{0}' AND TE029='{1}' GROUP BY TE001,TE002" ,te004 ,te029 );
            else if ( string.IsNullOrEmpty( te029 ) && !string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM COPTE WHERE TE004='{0}' AND TE011='{1}' GROUP BY TE001,TE002" ,te004 ,te011 );
            else if ( string.IsNullOrEmpty( te029 ) && string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM COPTE WHERE TE004='{0}' GROUP BY TE001,TE002" ,te004 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlysTre ( string te004 ,string te011 ,string te029 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te029 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TE007 FROM COPTE WHERE TE004='{0}' AND TE011='{1}' AND TE029='{2}') GROUP BY MA001,MA003" ,te004 ,te011 ,te029 );
            else if ( string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te029 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TE007 FROM COPTE WHERE TE004='{0}' AND TE029='{1}') GROUP BY MA001,MA003" ,te004 ,te029 );
            else if ( string.IsNullOrEmpty( te029 ) && !string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TE007 FROM COPTE WHERE TE004='{0}' AND TE011='{1}' ) GROUP BY MA001,MA003" ,te004 ,te011 );
            else if ( string.IsNullOrEmpty( te029 ) && string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TE007 FROM COPTE WHERE TE004='{0}') GROUP BY MA001,MA003" ,te004 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTre ( string te004 ,string te007 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TE001+'-'+TE002 TC FROM COPTE" );
            strSql.Append( " WHERE TE004=@TE004 AND TE007=@TE007" );
            strSql.Append( " ORDER BY TE001,TE002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE004",SqlDbType.Char,10),
                new SqlParameter("@TE007",SqlDbType.Char,8)
            };
            parameter[0].Value = te004;
            parameter[1].Value = te007;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyTres ( string te001 ,string te002 ,string te004 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM COPMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TE007 FROM COPTE WHERE TE001=@TE001 AND TE002=@TE002 AND TE004=@TE004)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE001",SqlDbType.Char,4),
                new SqlParameter("@TE002",SqlDbType.Char,11),
                new SqlParameter("@TE004",SqlDbType.Char,8)
            };
            parameter[0].Value = te001;
            parameter[1].Value = te002;
            parameter[2].Value = te004;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 采购变更单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFor ( string te004,string te011,string te017 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te017 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM PURTE WHERE TE004='{0}' AND TE011='{1}' AND TE017='{2}' GROUP BY TE001,TE002" ,te004 ,te011 ,te017 );
            else if ( string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te017 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM PURTE WHERE TE004='{0}' AND TE017='{1}' GROUP BY TE001,TE002" ,te004 ,te017 );
            else if ( string.IsNullOrEmpty( te017 ) && !string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM PURTE WHERE TE004='{0}' AND TE011='{1}' GROUP BY TE001,TE002" ,te004 ,te011 );
            else if ( string.IsNullOrEmpty( te017 ) && string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT TE001+'-'+TE002 TC FROM PURTE WHERE TE004='{0}' GROUP BY TE001,TE002" ,te004 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlysFor ( string te004 ,string te011 ,string te017 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te017 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TE005 FROM PURTE WHERE TE004='{0}' AND TE011='{1}' AND TE017='{2}') GROUP BY MA001,MA003" ,te004 ,te011 ,te017 );
            else if ( string.IsNullOrEmpty( te011 ) && !string.IsNullOrEmpty( te017 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TE005 FROM PURTE WHERE TE004='{0}' AND TE017='{1}') GROUP BY MA001,MA003" ,te004 ,te017 );
            else if ( string.IsNullOrEmpty( te017 ) && !string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TE005 FROM PURTE WHERE TE004='{0}' AND TE011='{1}' ) GROUP BY MA001,MA003" ,te004 ,te011 );
            else if ( string.IsNullOrEmpty( te017 ) && string.IsNullOrEmpty( te011 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TE005 FROM PURTE WHERE TE004='{0}') GROUP BY MA001,MA003" ,te004 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyFor ( string te004 ,string te005 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TE001+'-'+TE002 TC FROM PURTE" );
            strSql.Append( " WHERE TE004=@TE004 AND TE005=@TE005" );
            strSql.Append( " ORDER BY TE001,TE002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE004",SqlDbType.Char,10),
                new SqlParameter("@TE005",SqlDbType.Char,8)
            };
            parameter[0].Value = te004;
            parameter[1].Value = te005;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyFors ( string te001 ,string te002 ,string te004 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM PURMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TE005 FROM PURTE WHERE TE001=@TE001 AND TE002=@TE002 AND TE004=@TE004)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE001",SqlDbType.Char,4),
                new SqlParameter("@TE002",SqlDbType.Char,11),
                new SqlParameter("@TE004",SqlDbType.Char,8)
            };
            parameter[0].Value = te001;
            parameter[1].Value = te002;
            parameter[2].Value = te004;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 装箱单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFiv ( string tg003 ,string tg006 ,string tg023 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tg006 ) && !string.IsNullOrEmpty( tg023 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM COPTG WHERE TG003='{0}' AND TG023='{1}' AND TG006='{2}' GROUP BY TG001,TG002" ,tg003 ,tg023 ,tg006 );
            else if ( string.IsNullOrEmpty( tg006 ) && !string.IsNullOrEmpty( tg023 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM COPTG WHERE TG003='{0}' AND TG023='{1}' GROUP BY TG001,TG002" ,tg003 ,tg023 );
            else if ( string.IsNullOrEmpty( tg023 ) && !string.IsNullOrEmpty( tg006 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM COPTG WHERE TG003='{0}' AND TG006='{1}' GROUP BY TG001,TG002" ,tg003 ,tg006 );
            else if ( string.IsNullOrEmpty( tg023 ) && string.IsNullOrEmpty( tg006 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM COPTG WHERE TG003='{0}' GROUP BY TG001,TG002" ,tg003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlysFiv ( string tg003 ,string tg006 ,string tg023 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tg006 ) && !string.IsNullOrEmpty( tg023 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TG004 FROM COPTG WHERE TG003='{0}' AND TG023='{1}' AND TG006='{2}') GROUP BY MA001,MA003" ,tg003 ,tg023 ,tg006 );
            if ( string.IsNullOrEmpty( tg006 ) && !string.IsNullOrEmpty( tg023 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TG004 FROM COPTG WHERE TG003='{0}' AND TG023='{1}' ) GROUP BY MA001,MA003" ,tg003 ,tg023 );
            if ( string.IsNullOrEmpty( tg023 ) && !string.IsNullOrEmpty( tg006 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TG004 FROM COPTG WHERE TG003='{0}' AND TG006='{1}') GROUP BY MA001,MA003" ,tg003 ,tg006 );
            if ( string.IsNullOrEmpty( tg023 ) && string.IsNullOrEmpty( tg006 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM COPMA WHERE MA001 IN (SELECT TG004 FROM COPTG WHERE TG003='{0}') GROUP BY MA001,MA003" ,tg003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyFiv ( string tg003 ,string tg004 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TG001+'-'+TG002 TC FROM COPTG" );
            strSql.Append( " WHERE TG003=@TG003 AND TG004=@TG004" );
            strSql.Append( " ORDER BY TG001,TG002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TG003",SqlDbType.Char,10),
                new SqlParameter("@TG004",SqlDbType.Char,8)
            };
            parameter[0].Value = tg003;
            parameter[1].Value = tg004;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyFivs ( string tg001 ,string tg002 ,string tg003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM COPMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TG004 FROM COPTG WHERE TG001=@TG001 AND TG002=@TG002 AND TG003=@TG003)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TG001",SqlDbType.Char,4),
                new SqlParameter("@TG002",SqlDbType.Char,11),
                new SqlParameter("@TG003",SqlDbType.Char,8)
            };
            parameter[0].Value = tg001;
            parameter[1].Value = tg002;
            parameter[2].Value = tg003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 进货单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlySix ( string tg003,string mv001,string tg013)
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( mv001 ) && !string.IsNullOrEmpty( tg013 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM PURTG WHERE TG003='{0}' AND TG005='{1}' AND TG013='{2}' GROUP BY TG001,TG002" ,tg003 ,mv001 ,tg013 );
            else if ( string.IsNullOrEmpty( mv001 ) && !string.IsNullOrEmpty( tg013 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM PURTG WHERE TG003='{0}' AND TG013='{1}' GROUP BY TG001,TG002" ,tg003 ,tg013 );
            else if ( string.IsNullOrEmpty( tg013 ) && !string.IsNullOrEmpty( mv001 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM PURTG WHERE TG003='{0}' AND TG005='{1}' GROUP BY TG001,TG002" ,tg003 ,mv001 );
            else if ( string.IsNullOrEmpty( tg013 ) && string.IsNullOrEmpty( mv001 ) )
                strSql.AppendFormat( "SELECT TG001+'-'+TG002 TC FROM PURTG WHERE TG003='{0}' GROUP BY TG001,TG002" ,tg003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlysSix ( string tg003,string mv001,string tg013 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( mv001 ) && !string.IsNullOrEmpty( tg013 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TG004 FROM PURTG WHERE TG003='{0}' AND TG005='{1}' AND TG013='{2}') GROUP BY MA001,MA003" ,tg003 ,mv001 ,tg013 );
            if ( string.IsNullOrEmpty( mv001 ) && !string.IsNullOrEmpty( tg013 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TG004 FROM PURTG WHERE TG003='{0}' AND TG013='{1}') GROUP BY MA001,MA003" ,tg003 ,tg013 );
            if ( string.IsNullOrEmpty( tg013 ) && !string.IsNullOrEmpty( mv001 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TG004 FROM PURTG WHERE TG003='{0}' AND TG005='{1}' ) GROUP BY MA001,MA003" ,tg003 ,mv001 );
            if ( string.IsNullOrEmpty( tg013 ) && string.IsNullOrEmpty( mv001 ) )
                strSql.AppendFormat( "SELECT DISTINCT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TG004 FROM PURTG WHERE TG003='{0}') GROUP BY MA001,MA003" ,tg003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlySix ( string tg003 ,string tg004 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TG001+'-'+TG002 TC FROM PURTG" );
            strSql.Append( " WHERE TG003=@TG003 AND TG004=@TG004" );
            strSql.Append( " ORDER BY TG001,TG002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TG003",SqlDbType.Char,10),
                new SqlParameter("@TG004",SqlDbType.Char,8)
            };
            parameter[0].Value = tg003;
            parameter[1].Value = tg004;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlySixs ( string tg001 ,string tg002 ,string tg003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MA001,MA003 FROM PURMA" );
            strSql.Append( " WHERE MA001 IN (SELECT TG005 FROM PURTG WHERE TG001=@TG001 AND TG002=@TG002 AND TG003=@TG003)" );
            strSql.Append( " ORDER BY MA001,MA003" );
            SqlParameter[] parameter = {
                new SqlParameter("@TG001",SqlDbType.Char,4),
                new SqlParameter("@TG002",SqlDbType.Char,11),
                new SqlParameter("@TG003",SqlDbType.Char,8)
            };
            parameter[0].Value = tg001;
            parameter[1].Value = tg002;
            parameter[2].Value = tg003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 委外进货单查询条件
        /// </summary>
        /// <param name="th003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyThreese ( string th003 ,string th023 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( th023 ) )
                strSql.AppendFormat( "SELECT TH001+'-'+TH002 TC FROM MOCTH WHERE TH003='{0}' AND TD023='{1}'" ,th003 ,th023 );
            else if ( string.IsNullOrEmpty( th023 ) )
                strSql.AppendFormat( "SELECT TH001+'-'+TH002 TC FROM MOCTH WHERE TH003='{0}'" ,th003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyThrese ( string th003 ,string th023 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( th023 ) )
                strSql.AppendFormat( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TH005 FROM MOCTH WHERE TH003='{0}' AND TH023='{1}')" ,th003 ,th023 );
            else if ( string.IsNullOrEmpty( th023 ) )
                strSql.AppendFormat( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TH005 FROM MOCTH WHERE TH003='{0}')" ,th003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyThree ( string th001 ,string th002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TH005 FROM MOCTH WHERE TH001=@TH001 AND TH002=@TH002)" );
            SqlParameter[] parameter = {
                new SqlParameter("@TH001",SqlDbType.NVarChar),
                new SqlParameter("@TH002",SqlDbType.NVarChar)
            };
            parameter[0].Value = th001;
            parameter[1].Value = th002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyThrees ( string th005 ,string th003 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TH001+'-'+TH002 FROM MOCTH WHERE TH003=@TH003 AND TH005=@TH005" );
            SqlParameter[] parameter = {
                new SqlParameter("@TH003",SqlDbType.NVarChar),
                new SqlParameter("@TH005",SqlDbType.NVarChar)
            };
            parameter[0].Value = th003;
            parameter[1].Value = th005;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 委外进货单查询条件
        /// </summary>
        /// <param name="th003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFoures ( string tk003 ,string tk021 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tk021 ) )
                strSql.AppendFormat( "SELECT TK001+'-'+TK002 TC FROM MOCTK WHERE TK003='{0}' AND TK021='{1}'" ,tk003 ,tk021 );
            else if ( string.IsNullOrEmpty( tk021 ) )
                strSql.AppendFormat( "SELECT TK001+'-'+TK002 TC FROM MOCTK WHERE TK003='{0}'" ,tk003  );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyFourse ( string tk003 ,string tk021)
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tk021 ) )
                strSql.AppendFormat( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TK004 FROM MOCTK WHERE TK003='{0}' AND TK021='{1}')" ,tk003 ,tk021 );
            else if ( string.IsNullOrEmpty( tk021 ) )
                strSql.AppendFormat( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TK004 FROM MOCTK WHERE TK003='{0}')" ,tk003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyFours ( string tk001,string tk002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MA001,MA003 FROM PURMA WHERE MA001 IN (SELECT TK004 FROM MOCTK WHERE TK001=@TK001 AND TK002=@TK002)" );
            SqlParameter[] parameter = {
                new SqlParameter("@TK001",SqlDbType.NVarChar),
                new SqlParameter("@TK002",SqlDbType.NVarChar)
            };
            parameter[0].Value = tk001;
            parameter[1].Value = tk002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public DataTable GetDataTableOnlyFour ( string tk004 ,string tk003 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tk004 ) )
                strSql.AppendFormat( "SELECT TK001+'-'+TK002 FROM MOCTK WHERE TK003='{0}' AND TK004='{1}'" ,tk003 ,tk004 );
            else if ( string.IsNullOrEmpty( tk004 ) )
                strSql.AppendFormat( "SELECT TK001+'-'+TK002 FROM MOCTK WHERE TK003='{0}'" ,tk003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 所有模板业务员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPeopleOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT MV001,MV002 FROM CMSMV UNION SELECT '','' " );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 工单查询条件
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlySev ( string ta003 ,string ta013 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( ta013 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM MOCTA WHERE TA003='{0}' AND TA013='{1}'" ,ta003 ,ta013 );
            else if ( string.IsNullOrEmpty( ta013 ) )
                strSql.AppendFormat( "SELECT TA001+'-'+TA002 TC FROM MOCTA WHERE TA003='{0}'" ,ta003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 工单变更单查询条件
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyEgi ( string to004 ,string to041)
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( to041 ) )
                strSql.AppendFormat( "SELECT TO001+'-'+TO002 TC FROM MOCTO WHERE TO004='{0}' AND TO041='{1}'" ,to004 ,to041 );
            else if ( string.IsNullOrEmpty( to041 ) )
                strSql.AppendFormat( "SELECT TO001+'-'+TO002 TC FROM MOCTO WHERE TO004='{0}'" ,to004 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 领料单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyNin ( string tc003 ,string tc009 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc009 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM MOCTC  WHERE TC003='{0}' AND TC009='{1}'" ,tc003 ,tc009 );
            if ( string.IsNullOrEmpty( tc009 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM MOCTC  WHERE TC003='{0}'" ,tc003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyNins ( string tc001,string tc002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TE011+'-'+TE012 TC FROM MOCTE" );
            strSql.Append( " WHERE TE001=@TE001 AND TE002=@TE002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE001",SqlDbType.NVarChar),
                new SqlParameter("@TE002",SqlDbType.NVarChar)
            };
            parameter[0].Value = tc001;
            parameter[1].Value = tc002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 退料单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTen ( string tc003 ,string tc009 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tc009 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM MOCTC WHERE TC003='{0}' AND TC009='{1}'" ,tc003 ,tc009 );
            else if ( string.IsNullOrEmpty( tc009 ) )
                strSql.AppendFormat( "SELECT TC001+'-'+TC002 TC FROM MOCTC WHERE TC003='{0}'" ,tc003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTens ( string tc001 ,string tc002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TE011+'-'+TE012 TC FROM MOCTE" );
            strSql.Append( " WHERE TE001=@TE001 AND TE002=@TE002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TE001",SqlDbType.NVarChar),
                new SqlParameter("@TE002",SqlDbType.NVarChar)
            };
            parameter[0].Value = tc001;
            parameter[1].Value = tc002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 退货单查询条件
        /// </summary>
        /// <param name="ti003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyEle ( string ti003,string ti013 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( ti013 ) )
                strSql.AppendFormat( "SELECT TI001+'-'+TI002 TC FROM PURTI WHERE TI003='{0}' AND TI013='{1}'" ,ti003 ,ti013 );
            else if ( string.IsNullOrEmpty( ti013 ) )
                strSql.AppendFormat( "SELECT TI001+'-'+TI002 TC FROM PURTI WHERE TI003='{0}'" ,ti003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyEles ( string tj001 ,string tj002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TJ016+'-'+TJ017 TC FROM PURTJ" );
            strSql.Append( " WHERE TJ001=@TJ001 AND TJ002=@TJ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TJ001",SqlDbType.NVarChar),
                new SqlParameter("@TJ002",SqlDbType.NVarChar)
            };
            parameter[0].Value = tj001;
            parameter[1].Value = tj002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 生产入库单查询条件
        /// </summary>
        /// <param name="tf003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTew ( string tf003 ,string tf006 )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( !string.IsNullOrEmpty( tf006 ) )
                strSql.AppendFormat( "SELECT TF001+'-'+TF002 TC FROM MOCTF  WHERE TF003='{0}' AND TF006='{1}'" ,tf003 ,tf006 );
            else if ( string.IsNullOrEmpty( tf006 ) )
                strSql.AppendFormat( "SELECT TF001+'-'+TF002 TC FROM MOCTF  WHERE TF003='{0}'" ,tf003 );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOnlyTews ( string tf001 ,string tf002 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT TG014+'-'+TG015 TC FROM MOCTG " );
            strSql.Append( " WHERE TG001=@TG001 AND TG002=@TG002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TG001",SqlDbType.NVarChar),
                new SqlParameter("@TG002",SqlDbType.NVarChar)
            };
            parameter[0].Value = tf001;
            parameter[1].Value = tf002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        ///获取打印数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string strWhere ,string signOfName)
        {
            StringBuilder strSql = new StringBuilder( );
            DataTable da = GetDataTablePrints( signOfName );
            if ( da != null && da.Rows.Count > 0 )
            {
                strSql.Append( "" + da.Rows[0]["DJ003"].ToString( ) + "" );
                if ( !string.IsNullOrEmpty( da.Rows[0]["DJ004"].ToString( ) ) )
                    strSql.Append( " WHERE " + strWhere + " AND " + da.Rows[0]["DJ004"].ToString( ).Replace( "WHERE" ," " ) );
                else
                    strSql.Append( " WHERE " + strWhere );
            }
            try
            {
                return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            }
            catch
            {
                return null;
            }
        }        
        public DataTable GetDataTableTotal ( string strWhere ,string signOfName )
        {
            StringBuilder strSql = new StringBuilder( );

            DataTable da = GetDataTablePrints( signOfName );
            if ( da != null && da.Rows.Count > 0 )
            {
                strSql.Append( "" + da.Rows[0]["DJ005"].ToString( ) + "" );
                if ( !string.IsNullOrEmpty( da.Rows[0]["DJ006"].ToString( ) ) )
                    strSql.Append( " " + da.Rows[0]["DJ006"].ToString( ) + " AND " + strWhere );
                else
                    strSql.Append( " WHERE " + strWhere );
            }
            try
            {
                return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取保存的数据源
        /// </summary>
        /// <param name="nameOfNames"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrints ( string nameOfNames )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DJ003,DJ004,DJ005,DJ006 FROM DJSJY" );
            strSql.Append( " WHERE DJ002=@DJ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@DJ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = nameOfNames;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool GetDataTablePass ( string passWord )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM DJSJY" );
            strSql.Append( " WHERE DJ001=1 AND DJ002=@DJ002" );
            SqlParameter[] parameter={
                new SqlParameter("@DJ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = passWord;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 检查语句是否正确
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableCheck ( string sqlStr ,string strWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "" + sqlStr + "" );
            if ( !string.IsNullOrEmpty( strWhere ) )
                strSql.Append( " " + strWhere + "" );

            try
            {
                return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            }
            catch ( Exception ex )
            {
                throw new Exception( ex.Message );
            }
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddTableOfSql ( YiGeEntiry.VersionEntity _model )
        {
            ArrayList SQLString = new ArrayList( );
            if ( ExistsSql( _model.DJ002 ) )
                SQLString.Add( UpdateOfSql( _model ) );
            else
                SQLString.Add( AddOfSql( _model ) );

            return SqlHelper.ExecuteSqlTran( SQLString );

        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="nameOfNames"></param>
        /// <returns></returns>
        public bool ExistsSql ( string nameOfNames )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM DJSJY" );
            strSql.Append( " WHERE DJ002=@DJ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@DJ002",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = nameOfNames;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        public string AddOfSql ( YiGeEntiry.VersionEntity _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO DJSJY (" );
            strSql.Append( "DJ002,DJ003,DJ004,DJ005,DJ006,DJ007)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}')" ,_model.DJ002 ,_model.DJ003 ,_model.DJ004 ,_model.DJ005 ,_model.DJ006 ,_model.DJ007 );

            return strSql.ToString( );
        }
        public string UpdateOfSql ( YiGeEntiry.VersionEntity _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE DJSJY SET " );
            strSql.AppendFormat( "DJ003='{0}'," ,_model.DJ003 );
            strSql.AppendFormat( "DJ004='{0}'," ,_model.DJ004 );
            strSql.AppendFormat( "DJ005='{0}'," ,_model.DJ005 );
            strSql.AppendFormat( "DJ006='{0}'," ,_model.DJ006 );
            strSql.AppendFormat( "DJ007='{0}'" ,_model.DJ007 );
            strSql.AppendFormat( " WHERE DJ002='{0}'" ,_model.DJ002 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="nameOfNames"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSql ( string nameOfNames )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DJ003,DJ004,DJ005,DJ006 FROM DJSJY" );
            strSql.Append( " WHERE DJ002=@DJ002" );
            SqlParameter[] parametre = {
                new SqlParameter("@DJ002",SqlDbType.NVarChar,20)
            };
            parametre[0].Value = nameOfNames;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parametre );
        }
    }
}
