using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class RequestDetailsMap : ClassMap<RequestDetails>
    {
        public RequestDetailsMap()
        {
            ReadOnly();
            Schema("dbo");
            Table("request_details");
            Id(x => x.DetailId).Column("detail_id");
            Map(x => x.TripNo).Column("tripno");
            Map(x => x.FormCode).Column("form_code");
            Map(x => x.StatusId).Column("status_id");
            Map(x => x.DetailDesc).Column("detail_desc");
            Map(x => x.ResolvedDate).Column("resolved_date");
            Map(x => x.Comments).Column("comments");
            Map(x => x.EnteredBy).Column("entered_by");
            Map(x => x.EnteredDtime).Column("entered_dtime");
            Map(x => x.RequestId).Column("request_id");
            //OptimisticLock.Version();
            //References(x => x.TripNo).Column("tripno");
        }
    }
}