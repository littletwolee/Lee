using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
namespace IDAL
{
    public interface IUsers
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Login(Model.Users users);
        #endregion  成员方法
    }
}
