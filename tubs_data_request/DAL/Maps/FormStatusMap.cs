using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class FormStatusMap : ClassMap<FormStatus>
    {
        public FormStatusMap()
        {
            ReadOnly();
            Schema("ref");
            Table("form_status");
            Id(x => x.FormStatusId).Column("form_status_id");
            Map(x => x.FormStatusDesc).Column("form_status_desc");

        }
    }
}