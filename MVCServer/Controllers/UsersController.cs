using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MVCServer.Models;
using BLL;
using Common;
using Model;
namespace MVCServer.Controllers
{
    public class UsersController : ApiController
    {
        readonly BLL.Users bll = new BLL.Users();
        public bool GetUsersByUsersId(string username,string userpwd)
        {
            Model.Users m_users = new Model.Users();
            MVCServer.Models.Users v_users = new Models.Users();
            string euserpwd = Common.Encrypt.UserMd5(userpwd);
            v_users.UserName = username;
            v_users.Password = euserpwd;
            m_users = (Model.Users)Common.Objhelper.SetObject<Model.Users>(v_users, m_users);
            bool result = bll.Login(m_users);
            return result;
        }
    }
}
