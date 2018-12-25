using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;



namespace DataLayer
{
    public partial class VehicleTypeDataMapperXML
    {
        static string namefile = "VehicleType.xml";
        private static List<VehicleType> vehicleTypeList = new List<VehicleType>();


        public VehicleTypeDataMapperXML() { }

        public static List<VehicleType> readFromFile()
        {
            XDocument xdoc = XDocument.Load(namefile);
            List<VehicleType> _vehicleTypeList = new List<VehicleType>();

            var items = from xe in xdoc.Element("traction").Element("Tractions").Elements("Traction")
                        select new
                        {
                            vehicletypeid = xe.Element("vehicletypeid").Value != null ? (int)xe.Element("vehicletypeid") : 0,
                            traction = xe.Element("traction").Value != null ? (string)xe.Element("traction") : ""
                        };

            foreach (var t in items)
                _vehicleTypeList.Add(new VehicleType(t.vehicletypeid, t.traction));


            return _vehicleTypeList;

        }
        ///
  
        ///

        private VehicleType SelectVehicleTypeById(int vehicletypeid)
        {
            foreach (VehicleType item in vehicleTypeList)
            {
                if (item.vehicletypeid == vehicletypeid) return item;
            }
            return null;
        }
        public string SelectTractionById(int vehicletypeid)
        {
            foreach (VehicleType item in vehicleTypeList)
            {
                if (item.vehicletypeid == vehicletypeid) return item.traction;
            }
            return null;
        }


        public static List<VehicleType> Select()
        {
            vehicleTypeList = readFromFile();
            return vehicleTypeList;
        }

        private int writeToXML(int id = 0)
        {

            if (id == 0)
            {
                XElement xElement = new XElement("Tractions");
                foreach (VehicleType item in vehicleTypeList)
                {
                    XElement newPlace = new XElement("Traction",
                            new XElement("vehicletypeid", item.vehicletypeid),
                            new XElement("traction", item.traction));

                    xElement.Add(newPlace);
                }
                xElement.Save(namefile, SaveOptions.None);
            }

            return 0;
        }

    }
}
