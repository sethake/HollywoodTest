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
    public class RolesRepository:IRoles
    {
        public string[] GetRolesForUser(string username)
        {
            using (HollywoodTestDataContext db = new HollywoodTestDataContext(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                var userRoles = (from user in db.Users
                                 join roleMapping in db.UserRoleMappings
                                 on user.Id equals roleMapping.UserId
                                 join role in db.Roles
                                 on roleMapping.RoleId equals role.Id
                                 where user.Username == username
                                 select role.RoleName).ToArray();
                return userRoles;
            }
        }
    }
}
