using MvcApplication2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class ExoController : ApiController
    {
        [HttpPost]
        public string MethodPostTest()
        {
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var httpRequest = HttpContext.Current.Request;

            try
            {
                if (httpRequest.Files.Count > 0)
                {
                    //Do your Stuff with file


                }
            }
            catch (Exception e)
            {
            }

            //Work with Json if Necessary

            //string JsonContent = Request.Content.ReadAsStringAsync().Result;
            //var values = JsonConvert.DeserializeObject<List<Person>(JsonContent);
            //string jsonString = string.Empty;
            //jsonString = JsonConvert.SerializeObject(paper);

            //Send a File to Service 
            //string fileToUpload = filePath;
            //using (var client = new WebClient())
            //{
            //    byte[] result = client.UploadFile(serviceUrl, fileToUpload);
            //    string responseAsString = Encoding.Default.GetString(result);
            //}

            //Return the report and the new rar in byte[], tranforming them into json.

            return "success"; //jsonString;
        }

        [HttpGet]
        public string Exo()
        {
            int prixRune, coutRemontee;
            double tauxIncertitude;
            Uri httpRequest = HttpContext.Current.Request.Url;
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("prixRune") == null) || !(Int32.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("prixRune"), out prixRune)))
                return "Le prix d'une rune n'est pas indiqué ou d'un format incompatible";
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("coutRemontee") == null) || !(Int32.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("coutRemontee"), out coutRemontee)))
                return "Le cout d'uen remontée n'est pas indiqué ou d'un format incompatible";
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("tauxIncertitude") == null) || !(Double.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("tauxIncertitude"), out tauxIncertitude)))
                tauxIncertitude = 5;
            return new Exo(prixRune, coutRemontee, tauxIncertitude). GetAll();
        }
    }
}