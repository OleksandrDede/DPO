using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using DataLayer;

namespace DataLayer
{
    public class VehicleDataMapper
    {

        //1.1 Zobraz vsechna vozidla
        static String SQL_SELECT = "SELECT * FROM Vozidlo JOIN Model ON Vozidlo.modelid = Model.modelid";
        //1.2 Pridani vozidla do databaze
        static String SQL_INSERT = "Insert into Vozidlo values(@vozidloid, @rok_vyroby, @depo, @stav, @modelid)";

        static String SQL_SELECT_id = "SELECT * FROM Vozidlo where vozidloid = @vozidloid";


        //1.1 Zobraz vsechna vozidla
        public static List<Vehicle> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            List<Vehicle> Vehicles = ReadVehicles(reader);
            reader.Close();

            db.Close();

            return Vehicles;
        }

        

        //1.2 Pridani vozidla do databaze
        public static int Insert(Vehicle v)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, v);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        public static Vehicle SelectById(int vehicleid)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_id);

            command.Parameters.Add(new SqlParameter("@vozidloid", SqlDbType.Int));
            command.Parameters["@vozidloid"].Value = vehicleid;

            SqlDataReader reader = db.Select(command);
            Vehicle vehicle = new Vehicle();
            while (reader.Read())
            {
                vehicle.VehicleID = reader.GetInt32(0);
                vehicle.ProductionYear = reader.GetInt32(1);
                vehicle.Depot = reader.GetString(2);
                vehicle.Condition = reader.GetString(3);

                vehicle.VehicleModelID = reader.GetInt32(4);
            }
            
            reader.Close();

            db.Close();

            return vehicle;
        }

        private static List<Vehicle> ReadVehicles(SqlDataReader reader)
        {
            List<Vehicle> Vehicles = new List<Vehicle>();

            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle();
                vehicle.VehicleID = reader.GetInt32(0);
                vehicle.ProductionYear = reader.GetInt32(1);
                vehicle.Depot = reader.GetString(2);
                vehicle.Condition = reader.GetString(3);
               
                vehicle.VehicleModelID = reader.GetInt32(4);
             

                Vehicles.Add(vehicle);
            }
            return Vehicles;
        }

        



        private static void PrepareCommand(SqlCommand command, Vehicle v)
        {
            command.Parameters.Add(new SqlParameter("@vozidloid", SqlDbType.Int));
            command.Parameters["@vozidloid"].Value = v.VehicleID;

            command.Parameters.Add(new SqlParameter("@rok_vyroby", SqlDbType.Int));
            command.Parameters["@rok_vyroby"].Value = v.ProductionYear;

            command.Parameters.Add(new SqlParameter("@depo", SqlDbType.VarChar, 50));
            command.Parameters["@depo"].Value = v.Depot;

            command.Parameters.Add(new SqlParameter("@stav", SqlDbType.VarChar, 50));
            command.Parameters["@stav"].Value = v.Condition;


            command.Parameters.Add(new SqlParameter("@modelid", SqlDbType.Int));
            command.Parameters["@modelid"].Value = v.VehicleModelID;

           
        }
        

    }
    
}
