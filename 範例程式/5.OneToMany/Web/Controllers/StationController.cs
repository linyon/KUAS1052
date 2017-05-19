using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StationController : Controller
    {
        // GET: Station
        public ActionResult Index(string search = "")
        {
            
            var stationRepository = new YC.Repository.StationRepository();

            var stations = stationRepository.FindAllStations();
            if (!string.IsNullOrEmpty(search))
                stations = stations
                    .Where(x =>
                    x.ObservatoryName.Contains(search) ||
                    x.LocationAddress.Contains(search))
                    .ToList();
            ViewBag.Search = search;
            //ViewBag.Stations = stations;

            return View(stations);
        }
    }
}