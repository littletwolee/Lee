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
            MVCServer.Models.Users v_users = new Models.Users();
            string euserpwd = Common.Encrypt.UserMd5(userpwd);
            v_users.UserName = username;
            v_users.Password = euserpwd;
            return bll.Login((Model.Users)Common.Objhelper.SetObject<Model.Users>(v_users, typeof(Model.Users)));
        }
        public Models.Users GetUsersByUsersId(int Id)
        {
            Models.Users user = new Models.Users();
            user.UserID = Id;
            Models.Users us = new Models.Users();
            return (Models.Users)Common.Objhelper.SetObject<Models.Users>(bll.GetUser((Model.Users)Common.Objhelper.SetObject<Model.Users>(user, typeof(Model.Users))), us);
        }
    }
}
