using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Response.Authenticate;
using HollywoodTestSolution.FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTestSolution.FrontEnd.Controllers
{
    public class AccountController:Controller
    {
        public AccountController()
        {
            ActionInvoker = new MVCWebApiActionInvoker();
        }
        public ActionResult Index()
        {
            return View();
        }
     
        public ControllerResponse Authorise(AuthRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Authenticate/Authorise";
                    HttpResponseMessage result = httpClient.PostAsync(requestUrl, jsonData).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    if(result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var authResponse = JsonConvert.DeserializeObject<AuthResponse>(response);
                        if (authResponse.Succeeded == true)
                            Session["AuthRequest"] = model;
                    }
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }
    }
}