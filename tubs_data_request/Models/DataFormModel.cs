using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class FormStatusModel
    {
        public virtual int formStatusId { get; set; }
        public virtual string formStatusDesc { get; set; }


        public FormStatusModel() { }

        public FormStatusModel(FormStatus formStatus)
        {
            this.formStatusId = formStatus.FormStatusId;
            this.formStatusDesc = formStatus.FormStatusDesc;

        }
    }
}