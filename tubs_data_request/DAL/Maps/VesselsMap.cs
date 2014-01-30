using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class VesselsMap : ClassMap<Vessels>
    {
        public VesselsMap()
        {
            ReadOnly();
            Schema("ref");
            Table("vessels");
            Id(x => x.VesselId).Column("vessel_id");
            Map(x => x.VesselName).Column("vessel_name");
            Map(x => x.VesselIrcs).Column("vessel_ircs");
            Map(x => x.VesselFlag).Column("vessel_flag");
            Map(x => x.VesselType).Column("vessel_type");
            Map(x => x.NormalisedName).Column("normalised_name");
            Map(x => x.VesselUvi).Column("vessel_uvi");

        }
    }
}