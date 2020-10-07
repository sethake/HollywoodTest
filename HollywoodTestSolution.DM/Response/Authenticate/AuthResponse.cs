using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTestSolution.DM.Response.Authenticate
{
   public class AuthResponse
    {
        public bool Succeeded { get; set; }
        public string ResponseMessage { get; set; }
        public int UserID { get; set; }
        public AuthResponse(bool succeeded, string responseMessage,int userId=0)
        {
            Succeeded = succeeded;
            ResponseMessage = responseMessage;
            UserID = userId;
        }
    }
}
