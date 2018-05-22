using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Passengers.Controllers;

namespace Passengers.Models
{
    public class PassengersModel
    {
        public List<PassengersList> PassengersList;

        public PassengersModel()
        {
            PassengersList = new List<PassengersList>();
        }
    }
}
