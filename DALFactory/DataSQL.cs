using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using IDAL;
using SQLServerDAL;
using System.Reflection;
using System.Configuration;
namespace DALFactory
{
    public sealed class DataSQL
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataSQL() { }
        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        public static IDAL.ISysManage CreateSysManage()
        {
            //方式1			
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (IDAL.ISysManage)objType;
        }
        #endregion

        public static IUsers CreateUsers()
        {

            string ClassNamespace = AssemblyPath + ".Users";
            object objType = CreateObject(AssemblyPath,ClassNamespace);
            return (IDAL.IUsers)objType;
        }
    }
}
