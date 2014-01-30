using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class Programs
    {
        public virtual string ObsprgCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string Comments { get; set; }
    }
}