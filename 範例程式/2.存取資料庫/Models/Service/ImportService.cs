using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YC.Models;

namespace YC.Service
{
    public class ImportService
    {
        public List<Station> FindStations(string xmlPath)
        {
            List<Station> stations = new List<Station>();



            var xml = XElement.Load(xmlPath);


            XNamespace gml = @"http://www.opengis.net/gml/3.2";
            XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var stationsNode = xml.Descendants(twed + "RiverStageObservatoryProfile").ToList();
            stationsNode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationNode =>
                {
                    var BasinIdentifier = stationNode.Element(twed + "BasinIdentifier").Value.Trim();
                    var ObservatoryName = stationNode.Element(twed + "ObservatoryName").Value.Trim();
                    var LocationAddress = stationNode.Element(twed + "LocationAddress").Value.Trim();

                    var LocationByTWD67pos = stationNode.Element(twed + "LocationByTWD67").Descendants(gml + "pos").FirstOrDefault().Value.Trim();
                    var LocationByTWD97pos = stationNode.Element(twed + "LocationByTWD97").Descendants(gml + "pos").FirstOrDefault().Value.Trim();
                    Station stationData = new Station();
                    stationData.ID = BasinIdentifier;
                    stationData.LocationAddress = LocationAddress;
                    stationData.LocationByTWD67 = LocationByTWD67pos;
                    stationData.ObservatoryName = ObservatoryName;
                    stationData.CreateTime = DateTime.Now;
                    stations.Add(stationData);

                });



            return stations;

        }
    }
}
