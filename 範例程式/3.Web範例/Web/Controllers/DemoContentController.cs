using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DemoContentController : Controller
    {
        // GET: DemoContent
        public ActionResult Index()
        {
            var stationRepository = new YC.Repository.StationRepository();

            var stations = stationRepository.FindAllStations();
            var message = string.Format("共收到{0}筆監測站的資料<br/>", stations.Count);
            stations.ForEach(x =>
            {
                message += string.Format("站點名稱：{0},地址:{1}<br/>", x.ObservatoryName, x.LocationAddress);


            });
            return Content(message);
        }
    }
}