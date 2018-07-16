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
    public class LootController : ApiController
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
        public string Loot()
        {
        //http://localhost:61867/api/Finish/MethodGetTest?taux=0,001&prospection=250&challenge=10
            double leChall, laPP, leTaux, tauxVise;
            bool bonusPack;
            Uri httpRequest = HttpContext.Current.Request.Url;
            //Do your thing
            //Get some Stuff
            //Return
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("taux") == null) || !(Double.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("taux"), out leTaux)))
                return "Le taux n'est pas indiqué ou d'un format incompatible";
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("challenge") == null) || !(Double.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("challenge"), out leChall)))
                leChall = 0;
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("prospection") == null) || !(Double.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("prospection"), out laPP)))
                laPP = 100;
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("tauxAcceptable") == null) || !(Double.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("tauxAcceptable"), out tauxVise)))
                tauxVise = 50;
            if ((HttpUtility.ParseQueryString(httpRequest.Query).Get("bonusPack") == null) || !(Boolean.TryParse(HttpUtility.ParseQueryString(httpRequest.Query).Get("bonusPack"), out bonusPack)))
                bonusPack = true;
            return new Loot(leTaux,laPP,leChall, tauxVise, bonusPack).GetAll();
        }
    }
}