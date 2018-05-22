using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Passengers.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace Passengers.Controllers
{
    public class PassengersController : Controller
    {
       
        // GET: /Passengers/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult updateFile(String given, String surname, String brf)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/PNL.txt");
            using (var stream = new StreamWriter(directory, true))
            {
                stream.WriteLine("\n1" + surname + "/" + given + " .L/" + brf);
            }
            return Json(new { result = 0 });
        }
	}

    public class PassengersService{
        public IList<PassengersList> _passengers;

        public PassengersService()
        {  
        }

        [HttpGet]
        public void passengers_list(String filedata){
            _passengers = new List<PassengersList>();
            String[] pList = filedata.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (pList.Length > 0)
            {
                for (int i = 0; i < pList.Length; i++)
                {
                    if(pList[i].StartsWith("1")){
                        var data = pList[i].Substring(1).Split(new string[] { "1", ".L/" }, StringSplitOptions.None);
                        if(data[0].Contains("-")){
                            var name = data[0].Split(new string[] { "-" }, StringSplitOptions.None);
                            _passengers.Add(new PassengersList { passenger_name = name[0], record_locator = data[1] });
                        }
                        else{
                            _passengers.Add(new PassengersList { passenger_name = data[0], record_locator = data[1] });
                        }
                    }
                }
            }
        }

        //todo: return all passengers.
        public IList<PassengersList> FetchPassengers()
        {
            if (_passengers.Count > 0)
            {
                return _passengers;
            }
            throw new NotImplementedException();
        }
    }
    
    public class PassengersList
    {
        public string passenger_name { get; set; }
        public string record_locator { get; set; }
    }
}                                                 