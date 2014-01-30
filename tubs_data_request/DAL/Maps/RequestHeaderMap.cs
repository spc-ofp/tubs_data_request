using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class RequestHeaderMap : ClassMap<RequestHeader>
    {
        public RequestHeaderMap()
        {
            ReadOnly();
            Schema("dbo");
            Table("request_header");
            Id(x => x.RequestId).Column("request_id");
            Map(x => x.TripNo).Column("tripno");
            Map(x => x.PrgTripNo).Column("prg_tripno");
            Map(x => x.ObsprgCode).Column("obsprg_code");
            Map(x => x.StaffCode).Column("staff_code");
            Map(x => x.VesselId).Column("vessel_id");
            Map(x => x.DepartDate).Column("depart_date");
            Map(x => x.ReturnDate).Column("return_date");
            Map(x => x.DepartPort).Column("depart_port");
            Map(x => x.ReturnPort).Column("return_port");
            Map(x => x.RequestDate).Column("request_date");
            Map(x => x.SendDate).Column("send_date");
            Map(x => x.IsComplete).Column("is_complete");
            Map(x => x.FormTypeId).Column("form_type_id");
            Map(x => x.Comments).Column("comments");
            Map(x => x.EnteredBy).Column("entered_by");
            Map(x => x.EnteredDtime).Column("entered_dtime");
            HasMany(x => x.Details).KeyColumn("request_id");
        }
    }
}