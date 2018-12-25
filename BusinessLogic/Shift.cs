using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Shift
    {
        int shiftid;
        DateTime date;
        int line;
        int driverid;
        int vehicleid;

        public int ShiftID
        {
            get
            {
                return shiftid;
            }

            set
            {
                shiftid = value;
            }
        }


        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }


        public int DriverID
        {
            get
            {
                return driverid;
            }

            set
            {
                driverid = value;
            }
        }

        public int VehicleID
        {
            get
            {
                return vehicleid;
            }

            set
            {
                vehicleid = value;
            }
        }

    }
}
