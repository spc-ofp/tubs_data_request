using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class RequestHeader
    {
        public virtual int RequestId { get; set; }
        public virtual string TripNo { get; set; }
        public virtual string PrgTripNo { get; set; }
        public virtual string ObsprgCode { get; set; }
        public virtual string StaffCode { get; set; }
        public virtual int VesselId { get; set; }
        public virtual DateTime DepartDate { get; set; }
        public virtual DateTime ReturnDate { get; set; }
        public virtual int DepartPort { get; set; }
        public virtual int ReturnPort { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual DateTime SendDate { get; set; }
        public virtual Boolean IsComplete { get; set; }
        public virtual int FormTypeId { get; set; }
        public virtual String Comments { get; set; }
        public virtual String EnteredBy { get; set; }
        public virtual DateTime EnteredDtime { get; set; }
        public virtual IList<RequestDetails> Details { get; set; }

        public RequestHeader()
        {
            this.Details = new List<RequestDetails>();
        }
    }
}