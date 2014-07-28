using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MvcApplication1.Models;
namespace MvcApplication1.Controllers
{
    public class UsersController : ApiController
    {
        Users[] users = new Users[] 
        { 
            new Users { Id=1, UserID = "admin", UserPwd = "aaa"},
            new Users { Id = 2, UserID = "admin1", UserPwd = "1"}
        };

        public IEnumerable<Users> GetAllUsers()
        {
            return users;
        }

        public Users GetUsersByUsersId(string userid)
        {
            var user = users.FirstOrDefault((p) => p.UserID == userid);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
    }
}
