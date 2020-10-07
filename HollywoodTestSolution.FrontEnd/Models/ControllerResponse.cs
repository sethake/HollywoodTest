using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HollywoodTestSolution.FrontEnd.Models
{
    public class ControllerResponse
    {
        public HttpStatusCode HttpResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public object ResponseObject { get; set; }

        public ControllerResponse(HttpStatusCode httpResponseCode)
        {
            HttpResponseCode = httpResponseCode;
        }
        public ControllerResponse(HttpStatusCode httpResponseCode, string responseMessage)
        {
            HttpResponseCode = httpResponseCode;
            ResponseMessage = responseMessage;
        }
        public ControllerResponse(HttpStatusCode httpResponseCode, string responseMessage, object responseObject)
        {
            HttpResponseCode = httpResponseCode;
            ResponseMessage = responseMessage;
            ResponseObject = responseObject;
        }
        public ControllerResponse(HttpStatusCode httpResponseCode, object responseObject)
        {
            HttpResponseCode = httpResponseCode;
            ResponseObject = responseObject;
        }
    }
}