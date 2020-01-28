using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _311calls.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Index(double longitude, double latitude)
        {
            if(longitude == 0)
            {
                longitude = 40.7831;
            }
            if (latitude == 0)
            {
                latitude = 73.9712;
            }
            Models.MapViewModel model = new Models.MapViewModel()
            {
                Latitude = latitude,
                Longitude = longitude
            };
            return View(model);
        }
    }
}