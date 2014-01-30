using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class ProgramsMap : ClassMap<Programs>
    {
        public ProgramsMap()
        {
            ReadOnly();
            Schema("ref");
            Table("programs");
            Id(x => x.ObsprgCode).Column("obsprg_code");
            Map(x => x.Description).Column("description");
            Map(x => x.Comments).Column("comments");
        }
    }
}