using HollywoodTestSolution.DM.Request.Authenticate;
using HollywoodTestSolution.DM.Request.Event;
using HollywoodTestSolution.DM.Request.EventDetail;
using HollywoodTestSolution.DM.Request.EventDetailStatus;
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
        public ControllerResponse GetEvents(int tournamentId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}Event/GetEvents?tournamentId={tournamentId}";
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

        public ControllerResponse AddEventDetail(AddEventDetailRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetail/AddEventDetail";
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
        public ControllerResponse UpdateEventDetail(UpdateEventDetailRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetail/UpdateEventDetail";
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
        public ControllerResponse GetEventDetails(int eventId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetail/GetEventDetails?eventId={eventId}";
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
        public ControllerResponse DeleteEventDetail(int EventDetailId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetail/DeleteEventDetail?EventDetailId={EventDetailId}";
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

        public ControllerResponse AddEventDetailStatus(AddEventDetailStatusRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetailStatus/AddEventDetailStatus";
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
        public ControllerResponse UpdateEventDetailStatus(UpdateEventDetailStatusRequest model)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    StringContent jsonData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetailStatus/UpdateEventDetailStatus";
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
        public ControllerResponse GetEventDetailStatuses()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetailStatus/GetEventDetailStatuses";
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
        public ControllerResponse DeleteEventDetailStatus(int EventDetailStatusId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var authRequest = (AuthRequest)Session["AuthRequest"];
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", authRequest.Username, authRequest.Password))));
                    var requestUrl = $"{ConfigurationManager.AppSettings["ApiEndpoint"]}EventDetailStatus/DeleteEventDetailStatus?EventDetailStatusId={EventDetailStatusId}";
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