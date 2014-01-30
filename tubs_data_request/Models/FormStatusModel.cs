using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class DataFormsModel
    {
        public virtual string formCode { get; set; }
        public virtual string formDesc { get; set; }


        public DataFormsModel() { }

        public DataFormsModel(DataForms dataForms)
        {
            this.formCode = dataForms.FormCode;
            this.formDesc = dataForms.FormDesc;

        }
    }
}