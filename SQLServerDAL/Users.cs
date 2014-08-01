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
    public partial class Users : IUsers
    {
        public Users()
		{}
        public bool Login(Model.Users users)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users");
            strSql.Append(" where UserName=@UserName and  Password=@Password");
            SqlParameter[] parameters = 
            {
					new SqlParameter("UserName",users.UserName),
                    new SqlParameter("Password",users.Password)
            };
            SqlDataReader sdr = null;
            try
            {
                sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
                if (sdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sdr.Close();
                sdr.Dispose();
            }
        }
        public Model.Users GetUser(Model.Users users)
        {
            Model.Users user= null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users");
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
                    user = (Model.Users)Objhelper.SetObjectBySqlDataReader<Model.Users>(sdr, typeof(Model.Users));
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
    }
}
