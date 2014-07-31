using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using IDAL;
using DALFactory;
using Model;
namespace BLL
{
    public partial class Users
    {
        private readonly IUsers dal = DataSQL.CreateUsers();
        public Users() {}
        public bool Login(Model.Users users) 
        {
            return dal.Login(users);
        }
    }
}
