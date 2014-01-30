using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class GearsMap : ClassMap<Gears>
    {
        public GearsMap()
        {
            ReadOnly();
            Schema("ref");
            Table("gears");
            Id(x => x.GearCode).Column("gear_code");
            Map(x => x.GearCode2).Column("gear_code_2");
            Map(x => x.GearDesc).Column("gear_desc");
            Map(x => x.MimraTypeCode).Column("mimra_type_code");
        }
    }
}