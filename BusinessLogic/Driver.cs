using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Driver
    {
        int driverid;
        string name;
        string surname;
        DateTime birthDate;
        DateTime debutDate;
        bool busDriver;
        bool tramDriver;
        bool trolleybusDriver;
        string gender;
        string preference;
        




     


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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
            }
        }

        public DateTime DebutDate
        {
            get
            {
                return debutDate;
            }

            set
            {
                debutDate = value;
            }
        }

        public bool BusDriver
        {
            get
            {
                return busDriver;
            }

            set
            {
                busDriver = value;
            }
        }

        public bool TramDriver
        {
            get
            {
                return tramDriver;
            }

            set
            {
                tramDriver = value;
            }
        }

        public bool TrolleybusDriver
        {
            get
            {
                return trolleybusDriver;
            }

            set
            {
                trolleybusDriver = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }


        public string Preference
        {
            get
            {
                return preference;
            }

            set
            {
                preference = value;
            }
        }


    }
}
