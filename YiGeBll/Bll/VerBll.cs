using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiGeBll.Bll
{
    public class VerBll
    {
        Dao.VerDao _dao = new Dao.VerDao( );
        /// <summary>
        /// 获取查询条件字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string tc003 ,string tc027 ,string tc006 )
        {
            return _dao.GetDataTableOnly( tc003 ,tc027 ,tc006 );
        }
        public DataTable GetDataTableOnly ( string tc004 ,string tc003)
        {
            return _dao.GetDataTableOnly( tc004 ,tc003 );
        }
        public DataTable GetDataTableOnlyes (string tc003 ,string tc027 ,string tc006 )
        {
            return _dao.GetDataTableOnlyes( tc003 ,tc027 ,tc006 );
        }
        public DataTable GetDataTableOnlys ( string tc001 ,string tc002 ,string tc003)
        {
            return _dao.GetDataTableOnlys( tc001 ,tc002 ,tc003 );
        }

        /// <summary>
        /// 获取报价单查询条件字段
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOne ( string ta003 ,string ta019 ,string ta005 )
        {
            return _dao.GetDataTableOnlyOne( ta003 ,ta019 ,ta005 );
        }
        public DataTable GetDataTableOnlyOne ( string ta004 ,string ta003 )
        {
            return _dao.GetDataTableOnlyOne( ta004 ,ta003 );
        }
        public DataTable GetDataTableOnlyOnese ( string ta003 ,string ta019 ,string ta005 )
        {
            return _dao.GetDataTableOnlyOnese( ta003 ,ta019 ,ta005 );
        }
        public DataTable GetDataTableOnlyOnes ( string ta001 ,string ta002 ,string ta003 )
        {
            return _dao.GetDataTableOnlyOnes( ta001 ,ta002 ,ta003 );
        }

        /// <summary>
        /// 采购单查询条件字段
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTwo ( string tc003 ,string tc011 ,string tc014 )
        {
            return _dao.GetDataTableOnlyTwo( tc003 ,tc011 ,tc014 );
        }
        public DataTable GetDataTableOnlysTwo ( string tc003 ,string tc011 ,string tc014 )
        {
            return _dao.GetDataTableOnlysTwo( tc003 ,tc011 ,tc014 );
        }
        public DataTable GetDataTableOnlyTwo ( string tc003 ,string tc004 )
        {
            return _dao.GetDataTableOnlyTwo( tc004 ,tc003 );
        }
        public DataTable GetDataTableOnlyTwos ( string tc001 ,string tc002 ,string tc003 )
        {
            return _dao.GetDataTableOnlyTwos( tc001 ,tc002 ,tc003 );
        }

        /// <summary>
        /// 订单变更单查询条件
        /// </summary>
        /// <param name="te003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTre ( string te004 ,string te011 ,string te029 )
        {
            return _dao.GetDataTableOnlyTre( te004 ,te011 ,te029 );
        }
        public DataTable GetDataTableOnlysTre ( string te004 ,string te011 ,string te029 )
        {
            return _dao.GetDataTableOnlysTre( te004 ,te011 ,te029 );
        }
        public DataTable GetDataTableOnlyTre ( string te004 ,string te007 )
        {
            return _dao.GetDataTableOnlyTre( te004 ,te007 );
        }
        public DataTable GetDataTableOnlyTres ( string te001 ,string te002 ,string te004 )
        {
            return _dao.GetDataTableOnlyTres( te001 ,te002 ,te004 );
        }

        /// <summary>
        /// 采购变更单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFor ( string te004 ,string te011 ,string te017 )
        {
            return _dao.GetDataTableOnlyFor( te004 ,te011 ,te017 );
        }
        public DataTable GetDataTableOnlysFor ( string te004 ,string te011 ,string te017 )
        {
            return _dao.GetDataTableOnlysFor( te004 ,te011 ,te017 );
        }
        public DataTable GetDataTableOnlyFor ( string te004 ,string te005 )
        {
            return _dao.GetDataTableOnlyFor( te004 ,te005 );
        }
        public DataTable GetDataTableOnlyFors ( string te001 ,string te002 ,string te004 )
        {
            return _dao.GetDataTableOnlyFors( te001 ,te002 ,te004 );
        }

        /// <summary>
        /// 装箱单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFiv ( string tg003,string tg006,string tg023 )
        {
            return _dao.GetDataTableOnlyFiv( tg003 ,tg006 ,tg023 );
        }
        public DataTable GetDataTableOnlysFiv ( string tg003 ,string tg006 ,string tg023 )
        {
            return _dao.GetDataTableOnlysFiv( tg003 ,tg006 ,tg023 );
        }
        public DataTable GetDataTableOnlyFiv ( string tg003 ,string tg004 )
        {
            return _dao.GetDataTableOnlyFiv( tg003 ,tg004 );
        }
        public DataTable GetDataTableOnlyFivs ( string tg001 ,string tg002 ,string tg003 )
        {
            return _dao.GetDataTableOnlyFivs( tg001 ,tg002 ,tg003 );
        }

        /// <summary>
        /// 进货单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlySix ( string tg003 ,string mv001 ,string tg013 )
        {
            return _dao.GetDataTableOnlySix( tg003 ,mv001 ,tg013 );
        }
        public DataTable GetDataTableOnlysSix ( string tg003 ,string mv001 ,string tg013 )
        {
            return _dao.GetDataTableOnlysSix( tg003 ,mv001 ,tg013 );
        }
        public DataTable GetDataTableOnlySix ( string tg003 ,string tg004 )
        {
            return _dao.GetDataTableOnlySix( tg003 ,tg004 );
        }
        public DataTable GetDataTableOnlySixs ( string tg001 ,string tg002 ,string tg003 )
        {
            return _dao.GetDataTableOnlySixs( tg001 ,tg002 ,tg003 );
        }

        /// <summary>
        /// 工单查询条件
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlySev ( string ta003 ,string ta013 )
        {
            return _dao.GetDataTableOnlySev( ta003 ,ta013 );
        }

        /// <summary>
        /// 工单变更单查询条件
        /// </summary>
        /// <param name="ta003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyEgi ( string to004 ,string to041 )
        {
            return _dao.GetDataTableOnlyEgi( to004 ,to041 );
        }

        /// <summary>
        /// 领料单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyNin ( string tc003 ,string tc009 )
        {
            return _dao.GetDataTableOnlyNin( tc003 ,tc009 );
        }
        public DataTable GetDataTableOnlyNins ( string tc001 ,string tc002 )
        {
            return _dao.GetDataTableOnlyNins( tc001 ,tc002 );
        }

        /// <summary>
        /// 退料单查询条件
        /// </summary>
        /// <param name="tc003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTen ( string tc003 ,string tc009 )
        {
            return _dao.GetDataTableOnlyTen( tc003 ,tc009 );
        }
        public DataTable GetDataTableOnlyTens ( string tc001 ,string tc002 )
        {
            return _dao.GetDataTableOnlyTens( tc001 ,tc002 );
        }

        /// <summary>
        /// 退货单查询条件
        /// </summary>
        /// <param name="ti003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyEle ( string ti003 ,string ti013 )
        {
            return _dao.GetDataTableOnlyEle( ti003 ,ti013 );
        }
        public DataTable GetDataTableOnlyEles ( string tj001 ,string tj002 )
        {
            return _dao.GetDataTableOnlyEles( tj001 ,tj002 );
        }

        /// <summary>
        /// 生产入库单查询条件
        /// </summary>
        /// <param name="tf003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyTew ( string tf003 ,string tf006 )
        {
            return _dao.GetDataTableOnlyTew( tf003 ,tf006 );
        }
        public DataTable GetDataTableOnlyTews ( string tf001 ,string tf002 )
        {
            return _dao.GetDataTableOnlyTews( tf001 ,tf002 );
        }

        /// <summary>
        /// 委外进货单查询条件
        /// </summary>
        /// <param name="th003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyThreese ( string th003 ,string th023 )
        {
            return _dao.GetDataTableOnlyThreese( th003 ,th023 );
        }
        public DataTable GetDataTableOnlyThrese ( string th003 ,string th023 )
        {
            return _dao.GetDataTableOnlyThrese( th003 ,th023 );
        }
        public DataTable GetDataTableOnlyThree ( string th001 ,string th002 )
        {
            return _dao.GetDataTableOnlyThree( th001 ,th002 );
        }
        public DataTable GetDataTableOnlyThrees ( string th005 ,string th003 )
        {
            return _dao.GetDataTableOnlyThrees( th005 ,th003 );
        }

        /// <summary>
        /// 委外进货单查询条件
        /// </summary>
        /// <param name="th003"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnlyFoures ( string tk003 ,string tk021)
        {
            return _dao.GetDataTableOnlyFoures( tk003 ,tk021 );
        }
        public DataTable GetDataTableOnlyFourse ( string tk003,string tk021 )
        {
            return _dao.GetDataTableOnlyFourse( tk003 ,tk021 );
        }
        public DataTable GetDataTableOnlyFours ( string tk001 ,string tk002 )
        {
            return _dao.GetDataTableOnlyFours( tk001 ,tk002 );
        }
        public DataTable GetDataTableOnlyFour ( string tk004 ,string tk003 )
        {
            return _dao.GetDataTableOnlyFour( tk004 ,tk003 );
        }

        /// <summary>
        /// 订单 报价单  装箱单  订单变更单  退货单业务员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPeopleOne ( )
        {
            return _dao.GetDataTableOfPeopleOne( );
        }

        /// <summary>
        /// 获取打印数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string strWhere ,string signOfName)
        {
            return _dao.GetDataTablePrint( strWhere ,signOfName );
        }
        public DataTable GetDataTablePrints ( string strWhere )
        {
            return _dao.GetDataTablePrints( strWhere );
        }
        public DataTable GetDataTableTotal ( string strWhere ,string signOfName)
        {
            return _dao.GetDataTableTotal( strWhere ,signOfName );
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool GetDataTablePass ( string passWord )
        {
            return _dao.GetDataTablePass( passWord );
        }

        /// <summary>
        /// 检查语句是否正确
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableCheck ( string sqlStr,string strWhere )
        {
            return _dao.GetDataTableCheck( sqlStr ,strWhere );
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddTableOfSql ( YiGeEntiry.VersionEntity _model )
        {
            return _dao.AddTableOfSql( _model );

        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="nameOfNames"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSql ( string nameOfNames )
        {
            return _dao.GetDataTableOfSql( nameOfNames );
        }
    }
}
