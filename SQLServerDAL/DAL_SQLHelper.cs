using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using DBUtility;
using IDAL;
using Model;
using System.Data.SqlClient;
using System.Data;
namespace SQLServerDAL
{
    public class DAL_SQLHelper
    {
        public DAL_SQLHelper() { }
        public Model_Tables GetUser(Model_Tables table)
        {
            Model_Tables r_table = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(ID),@TableName from @TableName");
            SqlParameter[] parameters = 
            {
                    new SqlParameter("TableName",table.TableName)
            };
            SqlDataReader sdr = null;
            try
            {
                sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
                if (sdr.HasRows)
                {
                    r_table = new Model_Tables();
                    r_table = (Model_Tables)Objhelper.SetObjectBySqlDataReader<Model_Tables>(sdr);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return r_table;
        }
    }
}
