using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class FormTypeMap : ClassMap<FormType>
    {
        public FormTypeMap()
        {
            ReadOnly();
            Schema("ref");
            Table("form_type");
            Id(x => x.FormTypeId).Column("form_type_id");
            Map(x => x.FormTypeDesc).Column("form_type_desc");

        }
    }
}