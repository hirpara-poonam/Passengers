using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace Passengers.Controllers.Api
{
    public class PassengersApiController : ApiController
    {
        public IList<PassengersList> _passengers = new List<PassengersList>();                             
       // GET api/<controller>
        public IList<PassengersList> Get()
        {
            String text = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/PNL.txt"));

            String[] pList = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (pList.Length > 0)
            {
                for (int i = 0; i < pList.Length; i++)
                {
                    if (pList[i].StartsWith("1"))
                    {
                        var data = pList[i].Substring(1).Split(new string[] { "1", ".L/" }, StringSplitOptions.None);
                        if (data[0].Contains("-"))
                        {
                            var name = data[0].Split(new string[] { "-" }, StringSplitOptions.None);
                            _passengers.Add(new PassengersList { passenger_name = name[0], record_locator = data[1] });
                        }
                        else
                        {
                            _passengers.Add(new PassengersList { passenger_name = data[0], record_locator = data[1] });
                        }
                    }
                }
            }
            return _passengers;
            throw new NotImplementedException();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //[System.Web.Mvc.HttpGet]
        //[Route("")]
        //[Route("{booking_ref}/{passenger_name}")]
        public IList<PassengersList> Get(String booking_ref, String passenger_name)
        {
            return _passengers;
           // return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}