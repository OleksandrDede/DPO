using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VehicleModelDataMapper
    {

        static String SQL_SELECT = "SELECT * FROM Model";
        static String SQL_SELECT_id = "SELECT * FROM Model where modelid = @modelid";
        
        public static List<VehicleModel> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            List<VehicleModel> VehicleModels = ReadVehicleModels(reader);
            reader.Close();

            db.Close();

            return VehicleModels;
        }

        public static VehicleModel SelectById(int vehiclemodelid)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_id);

            command.Parameters.Add(new SqlParameter("@modelid", SqlDbType.Int));
            command.Parameters["@modelid"].Value = vehiclemodelid;

            SqlDataReader reader = db.Select(command);

            List<VehicleModel> VehicleModels = ReadVehicleModels(reader);
            reader.Close();

            db.Close();

            if (VehicleModels.Count > 0) return VehicleModels[0];
            else return null;
        }

        private static List<VehicleModel> ReadVehicleModels(SqlDataReader reader)
        {
            List<VehicleModel> VehicleModels = new List<VehicleModel>();

            while (reader.Read())
            {
                VehicleModel vehiclemodel = new VehicleModel();
                vehiclemodel.VehicleModelID = reader.GetInt32(0);
                vehiclemodel.Brand = reader.GetString(1);
                vehiclemodel.Model = reader.GetString(2);
                vehiclemodel.SeatingCapacity = reader.GetInt32(3);
                vehiclemodel.StandingCapacity = reader.GetInt32(4);
                vehiclemodel.VehicleTypeID = reader.GetInt32(5);
                vehiclemodel.Length = reader.GetFloat(6);
                vehiclemodel.Width = reader.GetFloat(7);
                vehiclemodel.Height = reader.GetFloat(8);
                vehiclemodel.Weight = reader.GetInt32(9);
                vehiclemodel.MaxSpeed = reader.GetInt32(10);
                vehiclemodel.LowFloor = reader.GetBoolean(11);
                vehiclemodel.PoweredBy = reader.GetString(12);

                VehicleModels.Add(vehiclemodel);
            }
            return VehicleModels;
        }


        private static void PrepareCommand(SqlCommand command, VehicleModel m)
        {
            command.Parameters.Add(new SqlParameter("@modelID", SqlDbType.Int));
            command.Parameters["@modelID"].Value = m.VehicleModelID;

            command.Parameters.Add(new SqlParameter("@znacka", SqlDbType.VarChar, 50));
            command.Parameters["@znacka"].Value = m.Brand;

            command.Parameters.Add(new SqlParameter("@model", SqlDbType.VarChar, 50));
            command.Parameters["@model"].Value = m.Model;

            command.Parameters.Add(new SqlParameter("@kapacita_sezeni", SqlDbType.Int));
            command.Parameters["@kapacita_sezeni"].Value = m.SeatingCapacity;

            command.Parameters.Add(new SqlParameter("@kapacita_stani", SqlDbType.Int));
            command.Parameters["@kapacita_stani"].Value = m.StandingCapacity;

            command.Parameters.Add(new SqlParameter("@typ_vozidla", SqlDbType.Int));
            command.Parameters["@typ_vozidla"].Value = m.VehicleTypeID;

            command.Parameters.Add(new SqlParameter("@delka", SqlDbType.Float));
            command.Parameters["@delka"].Value = m.Length;

            command.Parameters.Add(new SqlParameter("@delka", SqlDbType.Float));
            command.Parameters["@delka"].Value = m.Width;

            command.Parameters.Add(new SqlParameter("@delka", SqlDbType.Float));
            command.Parameters["@delka"].Value = m.Height;

            command.Parameters.Add(new SqlParameter("@hmotnost", SqlDbType.Int));
            command.Parameters["@hmotnost"].Value = m.Weight;

            command.Parameters.Add(new SqlParameter("@max_rychlost", SqlDbType.Int));
            command.Parameters["@max_rychlost"].Value = m.MaxSpeed;

            command.Parameters.Add(new SqlParameter("@nizkopodlazni", SqlDbType.Bit));
            command.Parameters["@nizkopodlazni"].Value = m.LowFloor;

            command.Parameters.Add(new SqlParameter("@pohon", SqlDbType.Bit));
            command.Parameters["@pohon"].Value = m.PoweredBy;


        }


    }
}
