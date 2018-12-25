using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using DataLayer;

namespace DataLayer
{
    public class DriverDataMapper
    {
        static String SQL_SELECT = "SELECT * FROM Ridic";
        static String SQL_SELECT_id = "SELECT * FROM Ridic where driverid = @ridicid";
        //2.4 Seznam ridicu bez smeny dany den
        static String SQL_SELECT_free_drivers = "SELECT * FROM Ridic WHERE NOT EXISTS(SELECT * FROM Smena WHERE date = @datum)";
        //3.1 Aktualizovat preference
        static String SQL_update_preferences = "Update smena set preference = @preference where driverid = @ridicid";


        public static List<Driver> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            List<Driver> Drivers = ReadDrivers(reader);
            reader.Close();

            db.Close();

            return Drivers;
        }

        public static Driver SelectById(int driverid)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_id);

            command.Parameters.Add(new SqlParameter("@ridicid", SqlDbType.Int));
            command.Parameters["@ridicid"].Value = driverid;

            SqlDataReader reader = db.Select(command);

            List<Driver> Drivers = ReadDrivers(reader);
            reader.Close();

            db.Close();

            if (Drivers.Count > 0) return Drivers[0];
            else return null;
        }

        //2.4 Seznam ridicu bez smeny dany den
        public static List<Driver> SelectFreeDrivers()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_free_drivers);
            SqlDataReader reader = db.Select(command);

            List<Driver> Drivers = ReadDrivers(reader);
            reader.Close();

            db.Close();

            return Drivers;
        }

        private static List<Driver> ReadDrivers(SqlDataReader reader)
        {
            List<Driver> Drivers = new List<Driver>();

            while (reader.Read())
            {
                Driver driver = new Driver();
                driver.DriverID = reader.GetInt32(0);
                driver.Name = reader.GetString(1);
                driver.Surname = reader.GetString(2);
                driver.BirthDate = reader.GetDateTime(3);
                driver.DebutDate = reader.GetDateTime(4);
                driver.BusDriver = reader.GetBoolean(5);
                driver.TramDriver = reader.GetBoolean(6);
                driver.TrolleybusDriver = reader.GetBoolean(7);
                driver.Gender = reader.GetString(8);
                driver.Preference = reader.GetString(9);

                Drivers.Add(driver);
            }
            return Drivers;
        }

        //3.1 Aktualizovat preference
        public static int UpdatePreference(Driver driver)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_update_preferences);
            PrepareCommand(command, driver);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        private static void PrepareCommand(SqlCommand command, Driver d)
        {
            command.Parameters.Add(new SqlParameter("@ridicid", SqlDbType.Int));
            command.Parameters["@ridicid"].Value = d.DriverID;

            command.Parameters.Add(new SqlParameter("@jmeno", SqlDbType.VarChar, 50));
            command.Parameters["@jmeno"].Value = d.Name;

            command.Parameters.Add(new SqlParameter("@prijmeni", SqlDbType.VarChar, 50));
            command.Parameters["@prijmeni"].Value = d.Surname;

            command.Parameters.Add(new SqlParameter("@datum_narozeni", SqlDbType.DateTime));
            command.Parameters["@datum_narozeni"].Value = d.BirthDate;

            command.Parameters.Add(new SqlParameter("@datum_nastupu", SqlDbType.DateTime));
            command.Parameters["@datum_nastupu"].Value = d.DebutDate;

            command.Parameters.Add(new SqlParameter("@ridicid", SqlDbType.VarChar, 50));
            command.Parameters["@ridicid"].Value = d.DriverID;

            command.Parameters.Add(new SqlParameter("@ridi_autobus", SqlDbType.Bit));
            command.Parameters["@ridi_autobus"].Value = d.BusDriver;

            command.Parameters.Add(new SqlParameter("@ridi_tramvaj", SqlDbType.Bit));
            command.Parameters["@ridi_tramvaj"].Value = d.TramDriver;

            command.Parameters.Add(new SqlParameter("@ridi_trolejbus", SqlDbType.Bit));
            command.Parameters["@ridi_trolejbus"].Value = d.TrolleybusDriver;

            command.Parameters.Add(new SqlParameter("@pohlavi", SqlDbType.VarChar, 5));
            command.Parameters["@pohlavi"].Value = d.Gender;

            command.Parameters.Add(new SqlParameter("@preference", SqlDbType.VarChar, 20));
            command.Parameters["@preference"].Value = d.Preference;



            
        }
    }
}
