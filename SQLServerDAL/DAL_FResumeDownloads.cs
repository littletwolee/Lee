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
    public partial class DAL_FResumeDownloads:IFResumeDownloads
    {
        public DAL_FResumeDownloads() { }
        public bool ResumeDownloads(Model_FResumeDownloads fResumeDownloads)
        {
            try
            {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FResumeDownloads() from Accounts_Users");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = 
            {
                    new SqlParameter("UserID",users.UserID)
            };
            SqlDataReader sdr = null;
            try
            {
                sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
                if (sdr.HasRows)
                {
                    user = new Model.Users();
                    user = (Model.Users)Objhelper.SetObjectBySqlDataReader<Model.Users>(sdr);
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
            return user;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
