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
    public partial class DAL_Files:IFiles
    {
        public DAL_Files() { }
        /// <summary>
        /// 根据文件名称查询文件
        /// </summary>
        /// <param name="files">对象</param>
        /// <returns></returns>
        public List<Model_Files> GetModel_FilesByFName(Model_Files files)
        {
            List<Model_Files> m_l_files = null;
            Model_Files m_files = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Files");
            strSql.Append(" where FName=@FName");
            SqlParameter[] parameters = 
            {
                    new SqlParameter("FName",files.FName)
            };
            SqlDataReader sdr = null;
            try
            {
                sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
                if (sdr.HasRows)
                {
                    m_l_files = new List<Model_Files>();
                    while (sdr.Read())
                    {
                        m_files = new Model_Files();
                        m_files = (Model_Files)Objhelper.SetObjectBySqlDataReader<Model_Files>(sdr);
                        m_l_files.Add(m_files);
                    }
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
            return m_l_files;
        }
        /// <summary>
        /// 根据文件ID查询文件
        /// </summary>
        /// <param name="files">对象</param>
        /// <returns></returns>
        public List<Model_Files> GetModel_FilesByFID(Model_Files files)
        {
            List<Model_Files> m_l_files = null;
            Model_Files m_files = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Files");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = 
            {
                    new SqlParameter("ID",files.ID)
            };
            SqlDataReader sdr = null;
            try
            {
                sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
                if (sdr.HasRows)
                {
                    m_l_files = new List<Model_Files>();
                    while (sdr.Read())
                    {
                        m_files = new Model_Files();
                        m_files = (Model_Files)Objhelper.SetObjectBySqlDataReader<Model_Files>(sdr);
                        m_l_files.Add(m_files);
                    }
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
            return m_l_files;
        }
    }
}
