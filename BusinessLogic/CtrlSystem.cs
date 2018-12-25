using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataLayer;
using System.Windows.Forms;
using System.Data;
using DataLayer.Tables;

namespace BusinessLogic
{

    public class CtrlSystem
    {
        
        private Driver driver;
        private Shift shift;
        private Vehicle vehicle;
        private VehicleModel vehicleModel;
        private VehicleTypeDataMapperXML vehicletype;

        public CtrlSystem()
        {
            this.driver = new Driver();
            this.shift = new Shift();
            this.vehicle = new Vehicle();
            this.vehicleModel = new VehicleModel();
            this.vehicletype = new VehicleTypeDataMapperXML();
        }

        public void SaveVehicle(int vehicleid, int production_year, string depot, string condition, int driverid, int vehiclemodelid)
        {
            Vehicle v = new Vehicle(vehicleid, production_year, depot, condition, driverid, vehiclemodelid);
            VehicleDataMapper.Insert(v);

        }

        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }

            set
            {
                vehicle = value;
            }
        }
        public Driver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }
        
        public Shift Shift
        {
            get
            {
                return shift;
            }

            set
            {
                shift = value;
            }
        }
        public VehicleModel VehicleModel
        {
            get
            {
                return vehicleModel;
            }

            set
            {
                vehicleModel = value;
            }
        }
        
        public string getVehicleType(int vehicletypeid) { return vehicletype.SelectTractionById(vehicletypeid); }

        //1.1 - zobrazeni seznamu vozidel
        public DataTable getVehicleList()
        {
            DataTable table = new DataTable();

            int columns = 15;
            for (int i = 0; i < columns; i++) table.Columns.Add();
            foreach (var array in VehicleDataMapper.Select())
            {
                table.Rows.Add(array.VehicleID, array.ProductionYear, array.Depot, array.Condition, array.DriverID, array.VehicleModelID);
            }

            return table;
        }

        //1.2 - pridani vozidla
        
        //1.3 - přidání vozidla do směny
        public void UpdateShiftVehicle(int vehicleid)
        {
            shift.VehicleID = vehicleid;
 
        }

        //2.1 - zobrazeni mych smen
        public DataTable Selectmyshiftsthismonth()
        {
            DataTable table = new DataTable();

            int columns = 30;
            for (int i = 0; i < columns; i++) table.Columns.Add();
            foreach (var array in ShiftDataMapper.Select())
            {
                table.Rows.Add(array.ShiftID, array.Date, array.Line, array.DriverID, array.VehicleID);
            }

            return table;
        }


        //2.2 - odebrání řidiče ze směny
        public void RemoveShiftDriver(int driverid)
        {
            shift.DriverID = null;

        }

        //2.3 - zobrazeni smen (smen bez ridice za ucelem nahrady chybejiciho ridice)
        public DataTable getShiftList()
        {
            DataTable table = new DataTable();

            int columns = 15;
            for (int i = 0; i < columns; i++) table.Columns.Add();
            foreach (var array in ShiftDataMapper.Select())
            {
                table.Rows.Add(array.ShiftID, array.Date, array.Line, array.DriverID, array.VehicleID);
            }

            return table;
        }

        //2.3 - přidání řidiče ze směny
        public void UpdateShiftDriver(int driverid)
        {
            shift.DriverID = driverid;

        }

        public DataTable getListDriver()
        {
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 4;

            // Add columns
            for (int i = 0; i < columns; i++) table.Columns.Add();

            // Add rows.
            foreach (var array in DriverDataMapper.Select())
            {
                table.Rows.Add(array.DriverID, array.Name, array.Surname, array.BirthDate, array.DebutDate, array.BusDriver, array.TramDriver, array.TrolleybusDriver, array.Gender, array.Preference);
            }

            return table;
        }

       

       


        public DataTable getVehicleTypeList()
        {
            DataTable table = new DataTable();
            int columns = 2;
            for (int i = 0; i < columns; i++) table.Columns.Add();
            foreach (var array in VehicleTypeDataMapperXML.Select())
            {
                table.Rows.Add(array.vehicletypeid, array.traction);
            }

            return table;
        }
        public string ShowDriverById(int id)
        {
            driver = DriverDataMapper.SelectById(id);
            if (driver == null) { return ""; }
            else return driver.Name;
        }
        public string ShowVehicleById(int id)
        {
            vehicle = VehicleDataMapper.SelectById(id);
            if (vehicle == null) { return ""; }
            else return vehicle.VehicleID;
        }


        public int getDriverId() { return driver.DriverID; }
        public int getVehicleId() { return vehicle.VehicleID; }

        /*
        public int UlozVykaz(string nastup, string ukonceni)
        {
            this.vyk.ida = auto.Id;
            this.vyk.idr = ridic.Id;
            if (zak != null) this.vyk.idz = zak.Id;
            vyk.Nastup = nastup;
            vyk.Ukonceni = ukonceni;

            return SpravceVykazu.Insert(this.vyk);
        }
        */


    }
}
