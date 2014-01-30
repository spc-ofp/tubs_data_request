using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class PortsMap : ClassMap<Ports>
    {
        public PortsMap()
        {
            ReadOnly();
            Schema("ref");
            Table("ports");
            Id(x => x.PortId).Column("port_id");
            Map(x => x.PortName).Column("port_name");
            Map(x => x.CtyCode).Column("cty_code");
            Map(x => x.LocationCode).Column("location_code");
            Map(x => x.AlsoCalled).Column("also_called");
            Map(x => x.PortLatd).Column("port_latd");
            Map(x => x.PortLond).Column("port_lond");
            Map(x => x.Active).Column("active");
        }
    }
}