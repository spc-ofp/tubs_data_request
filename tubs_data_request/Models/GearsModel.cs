using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class GearsModel
    {
        public virtual string gearCode { get; set; }
        public virtual string gearCode2 { get; set; }
        public virtual string gearDesc { get; set; }
        public virtual string mimraTypeCode { get; set; }

        public GearsModel() { }

        public GearsModel(Gears gears)
        {
            this.gearCode  = gears.GearCode ;
            this.gearCode2  = gears.GearCode2;
            this.gearDesc  = gears.GearDesc;
            this.mimraTypeCode  = gears.MimraTypeCode;
        }
    }
}