using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class VesselsModel
    {
        public virtual int vesselId { get; set; }
        public virtual string vesselName { get; set; }
        public virtual string vesselIrcs { get; set; }
        public virtual string vesselFlag { get; set; }
        public virtual string vesselType { get; set; }
        public virtual string normalisedName { get; set; }
        public virtual int vesselUvi { get; set; }

        public VesselsModel() { }

        public VesselsModel(Vessels vessels)
        {
            this.vesselId  = vessels.VesselId ;
            this.vesselName = vessels.VesselName;
            this.vesselIrcs = vessels.VesselIrcs;
            this.vesselFlag = vessels.VesselFlag;
            this.vesselType = vessels.VesselType;
            this.normalisedName = vessels.NormalisedName;
            this.vesselUvi = vessels.VesselUvi;
        }
    }
}