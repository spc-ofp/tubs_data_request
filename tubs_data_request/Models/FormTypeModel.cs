using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class FormTypeModel
    {
        public virtual int formTypeId { get; set; }
        public virtual string formTypeDesc { get; set; }


        public FormTypeModel() { }

        public FormTypeModel(FormType formType)
        {
            this.formTypeId  = formType.FormTypeId ;
            this.formTypeDesc = formType.FormTypeDesc;

        }
    }
}