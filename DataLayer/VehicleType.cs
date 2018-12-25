using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VehicleType
    {
        public int vehicletypeid { get; set; }
        public string traction { get; set; }

        public VehicleType(int vehicletypeid, string traction)
        {
            this.vehicletypeid = vehicletypeid;
            this.traction = traction;
        }


    }
}
