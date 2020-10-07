using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Request.Event;
using HollywoodTestSolution.DM.Request.Tournament;
using HollywoodTestSolution.FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTestSolution.FrontEnd.Controllers
{
    [HollywoodTestAuthorisation]
    public class HomeController : Controller
    {
        public HomeController()
        {
            ActionInvoker = new MVCWebApiActionInvoker();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ControllerResponse AddTournament(AddTournamentRequest model)
        {
            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,"application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Tournament/AddTournament";
                    HttpResponseMessage result =httpClient.PostAsync(requestUrl, jsonData).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse UpdateTournament(UpdateTournamentRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Tournament/UpdateTournament";
                    HttpResponseMessage result = httpClient.PutAsync(requestUrl, jsonData).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse GetTournaments()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Tournament/GetTournaments";
                    HttpResponseMessage result = httpClient.GetAsync(requestUrl).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse DeleteTournament(int tournamentId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Tournament/DeleteTournament?tournamentId={tournamentId}";
                    HttpResponseMessage result = httpClient.DeleteAsync(requestUrl).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public ControllerResponse AddEvent(AddEventRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Event/AddEvent";
                    HttpResponseMessage result = httpClient.PostAsync(requestUrl, jsonData).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse UpdateEvent(UpdateEventRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Event/UpdateEvent";
                    HttpResponseMessage result = httpClient.PutAsync(requestUrl, jsonData).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse GetEvents()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Event/GetEvents";
                    HttpResponseMessage result = httpClient.GetAsync(requestUrl).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public ControllerResponse DeleteEvent(int EventId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Event/DeleteEvent?EventId={EventId}";
                    HttpResponseMessage result = httpClient.DeleteAsync(requestUrl).Result;
                    var response = result.Content.ReadAsStringAsync().Result;
                    return new ControllerResponse(result.StatusCode, response);
                }
            }
            catch (Exception ex)
            {
                return new ControllerResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}