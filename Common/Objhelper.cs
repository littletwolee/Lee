using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
namespace Common
{
    /// <summary>
    /// 对象帮助类
    /// </summary>
    public class Objhelper
    {
        public static object SetObject<T>(object inobj, object outobj)
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
            return outobj;
        }
    }
}
