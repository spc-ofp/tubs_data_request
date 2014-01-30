using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class Vessels
    {
        public virtual int VesselId { get; set; }
        public virtual String VesselName { get; set; }
        public virtual String VesselIrcs { get; set; }
        public virtual String VesselFlag { get; set; }
        public virtual String VesselType { get; set; }
        public virtual String NormalisedName { get; set; }
        public virtual int VesselUvi { get; set; }
    }
}