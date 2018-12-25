using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Vehicle
    {

        int vehicleid;
        int production_year;
        string depot;
        string condition;
        int vehiclemodelid;

        public Vehicle()
        {
        }

        public Vehicle(int vehicleid, int production_year, string depot, string condition, int vehiclemodelid)
        {
            this.vehicleid = vehicleid;
            this.production_year = production_year;
            this.depot = depot;
            this.condition = condition; 
            this.vehiclemodelid = vehiclemodelid;
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

        public int ProductionYear
        {
            get
            {
                return production_year;
            }

            set
            {
                production_year = value;
            }
        }

        public string Depot
        {
            get
            {
                return depot;
            }

            set
            {
                depot = value;
            }
        }

        public string Condition
        {
            get
            {
                return condition;
            }

            set
            {
                condition = value;
            }
        }

       

        public int VehicleModelID
        {
            get
            {
                return vehiclemodelid;
            }

            set
            {
                vehiclemodelid = value;
            }
        }


    } 
        
}
