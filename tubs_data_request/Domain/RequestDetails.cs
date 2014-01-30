using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class RequestDetails
    {
        public virtual int DetailId { get; set; }
        public virtual string TripNo { get; set; }
        public virtual string FormCode { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string DetailDesc { get; set; }
        public virtual DateTime ResolvedDate { get; set; }
        public virtual String Comments { get; set; }
        public virtual String EnteredBy { get; set; }
        public virtual DateTime EnteredDtime { get; set; }
        public virtual int RequestId { get; set; }
        public virtual RequestHeader Header { get; set; }
        
    }
}