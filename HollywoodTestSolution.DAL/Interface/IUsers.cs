﻿using HollywoodTestSolution.DAL.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DAL.Interface
{
   public interface IUsers
    {
        User GetUser(string username, string password);
    }
}
