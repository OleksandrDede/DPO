using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using DataLayer;

namespace DataLayer
{
    public class ShiftDataMapper
    {
        static String SQL_SELECT = "SELECT * FROM Smena";
        //static String SQL_INSERT = "Insert into Smena values (@nastup, @ukonceni, null, null, @idz, @idr, @ida)";

        //1.3 - pridani (noveho) vozidla do smeny
        static String SQL_Update_shiftvehicle = "Update smena set shiftid = @smenaid where vehicleid = @vozidloid";

        //2.1 - zobrazeni smen ridice
        static String SQL_SELECT_myshifts = "SELECT * FROM Smena WHERE ridicid = 1 AND MONTH(datum) >= MONTH(dateadd(dd, -1, GetDate())) AND DAY(datum) >= DAY(dateadd(dd, -1, GetDate()));";

        //2.2 - odhlaseni ze smeny
        static String SQL_Remove_shiftdriver = "Update Smena set driverid = NULL where shiftid = @smenaid";
        //2.3 - zobrazeni seznamu smen bez ridice
        static String SQL_shiftswithnodriver = "SELECT * FROM Smena WHERE driverid = null";
        //2.5 - dosazeni noveho ridice
        static String SQL_Update_shiftdriver = "Update Smena set driverid = @ridicid where shiftid = @smenaid";


        //4.1 - zobrazeni mych smen tento mesic
        static String SQL_SELECT_myshiftsthismonth = "SELECT * FROM Smena WHERE ridicid = 1 AND MONTH(datum) = MONTH(dateadd(dd, -1, GetDate()));";



        public static List<Shift> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);
            List<Shift> shifts = ReadShift(reader);

            reader.Close();
            db.Close();

            return shifts;

        }

        //1.3 - pridani (noveho) vozidla do smeny
        public static int UpdateShiftVehicle(Shift shift)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_Update_shiftvehicle);
            PrepareCommand(command, shift);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }




        //2.1 - zobrazeni smen ridice
        public static List<Shift> Selectmyshifts()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_myshifts);
            SqlDataReader reader = db.Select(command);
            List<Shift> shifts = ReadShift(reader);

            reader.Close();
            db.Close();

            return shifts;

        }

        //2.2 - odhlaseni ze smeny
        public static int RemoveShiftDriver(Shift shift)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_Remove_shiftdriver);
            PrepareCommand(command, shift);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        //2.3 - zobrazeni seznamu smen bez ridice
        public static List<Shift> ShiftsWithNoDriver()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_shiftswithnodriver);
            SqlDataReader reader = db.Select(command);
            List<Shift> shifts = ReadShift(reader);

            reader.Close();
            db.Close();

            return shifts;

        }



        //2.4 - dosazeni noveho ridice
        public static int UpdateShiftDriver(Shift shift)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_Update_shiftdriver);
            PrepareCommand(command, shift);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        //4.1 - zobrazeni mych smen tento mesic
        public static List<Shift> Selectmyshiftsthismonth()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_myshiftsthismonth);
            SqlDataReader reader = db.Select(command);
            List<Shift> shifts = ReadShift(reader);

            reader.Close();
            db.Close();

            return shifts;

        }


        private static List<Shift> ReadShift(SqlDataReader reader)
        {
            List<Shift> shifts = new List<Shift>();

            while (reader.Read())
            {
                Shift shift = new Shift();
                shift.ShiftID = reader.GetInt32(0);
                shift.Date = reader.GetDateTime(1);
                shift.Line = reader.GetInt32(2);
                shift.DriverID = reader.GetInt32(3);
                shift.VehicleID = reader.GetInt32(4);


                shifts.Add(shift);
            }
            return shifts;
        }

        /*
        public static int Insert(Shift shift)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, shift);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        */

        private static void PrepareCommand(SqlCommand command, Shift S)
        {
            command.Parameters.Add(new SqlParameter("@smenaid", SqlDbType.Int));
            command.Parameters["@smenaid"].Value = S.ShiftID;

            command.Parameters.Add(new SqlParameter("@datum", SqlDbType.DateTime));
            command.Parameters["@datum"].Value = S.Date;

            command.Parameters.Add(new SqlParameter("@linka", SqlDbType.Int));
            command.Parameters["@linka"].Value = S.Line;

            command.Parameters.Add(new SqlParameter("@ridicid", SqlDbType.Int));
            command.Parameters["@ridicid"].Value = S.DriverID;

            command.Parameters.Add(new SqlParameter("@vozidloid", SqlDbType.Int));
            command.Parameters["@vozidloid"].Value = S.VehicleID;




        }
    }
}
