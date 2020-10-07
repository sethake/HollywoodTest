using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HollywoodTestSolution.DAL.DBML;
using HollywoodTestSolution.DAL.Interface;

namespace HollywoodTestSolution.DAL.Repository
{
   public class UsersRepository:IUsers
    {
        public User GetUser(string username,string password)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                var user = (from U in db.Users where U.Username == username && U.Password == password select U).FirstOrDefault();
                return user;
            }
        }
    }
}
