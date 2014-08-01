using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Data.SqlClient;
namespace Common
{
    /// <summary>
    /// 对象帮助类
    /// </summary>
    public class Objhelper
    {
        /// <summary>
        /// 客户端和服务端对象互转
        /// </summary>
        /// <typeparam name="T">对象Type</typeparam>
        /// <param name="inobj">输入对象</param>
        /// <param name="outobj">输出对象</param>
        /// <returns></returns>
        public static T SetObject<T>(object inobj, Type outobjtype)
        {
            //得到类型
            object outobj = CreatObject(outobjtype.Namespace, outobjtype.Namespace + "." + outobjtype.Name);
            Type inobjtype = inobj.GetType();
            //取得属性集合
            PropertyInfo[] pi = outobjtype.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                //给属性赋值
                try
                {
                    item.SetValue(outobj, inobjtype.GetProperty(item.Name).GetValue(inobj), null);
                }
                catch (Exception e)
                {
                    
                    throw;
                }
                
            }
            return (T)outobj;
        }
        public static T SetObject<T>(object inobj, object outobj)
        {
            //得到类型
            Type outobjtype = outobj.GetType();
            Type inobjtype = inobj.GetType();
            //取得属性集合
            PropertyInfo[] pi = outobjtype.GetProperties();
            foreach (PropertyInfo item in pi)
            {
                //给属性赋值
                try
                {
                    item.SetValue(outobj, inobjtype.GetProperty(item.Name).GetValue(inobj), null);
                }
                catch (Exception e)
                {

                    throw;
                }

            }
            return (T)outobj;
        }
        public static T SetObjectBySqlDataReader<T>(SqlDataReader sdr, Type outobjtype)
        {
            //得到类型
            object outobj = CreatObject(outobjtype.Namespace, outobjtype.Namespace + "." + outobjtype.Name);
            //取得属性集合
            PropertyInfo[] pi = outobjtype.GetProperties();
            try
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        foreach (PropertyInfo item in pi)
                        {
                            //给属性赋值
                            item.SetValue(outobj, sdr[item.Name], null);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return default(T);
            }
            finally
            {
                sdr.Close();
                sdr.Dispose();
            }
            return (T)outobj;
        }
        /// <summary>
        /// 反射创建对象
        /// </summary>
        /// <param name="AssemblyPath">命名空间</param>
        /// <param name="classNamespace">命名空间.类全名</param>
        /// <returns></returns>
        public static object CreatObject(string AssemblyPath, string classNamespace)
        {
            object objType = null;
            try
            {
                objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
            }
            catch (Exception)
            {
                return objType;
            }
            return objType;
        }
    }
}
