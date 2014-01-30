using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class DataFormsMap : ClassMap<DataForms>
    {
        public DataFormsMap()
        {
            ReadOnly();
            Schema("ref");
            Table("data_forms");
            Id(x => x.FormCode).Column("form_code");
            Map(x => x.FormDesc).Column("form_desc");
 
        }
    }
}