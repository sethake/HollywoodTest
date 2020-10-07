using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
   public interface IRoles
    {
        string[] GetRolesForUser(string username);
    }
}
