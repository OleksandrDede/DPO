using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VehicleModel
    {
        int vehiclemodelid;
        string brand;
        string model;
        int seatingcapacity;
        int standingcapacity;
        int vehicletypeid;
        float length;
        float width;
        float height;
        int weight;
        int maxspeed;
        bool lowfloor;
        string poweredby;


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

        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public int SeatingCapacity
        {
            get
            {
                return seatingcapacity;
            }

            set
            {
                seatingcapacity = value;
            }
        }

        public int StandingCapacity
        {
            get
            {
                return standingcapacity;
            }

            set
            {
                standingcapacity = value;
            }
        }

        public int VehicleTypeID
        {
            get
            {
                return vehicletypeid;
            }

            set
            {
                vehicletypeid = value;
            }
        }

        public float Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public float Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public float Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public int MaxSpeed
        {
            get
            {
                return maxspeed;
            }

            set
            {
                maxspeed = value;
            }
        }

        public bool LowFloor
        {
            get
            {
                return lowfloor;
            }

            set
            {
                lowfloor = value;
            }
        }

        public string PoweredBy
        {
            get
            {
                return poweredby;
            }

            set
            {
                poweredby = value;
            }
        }
    }
}
