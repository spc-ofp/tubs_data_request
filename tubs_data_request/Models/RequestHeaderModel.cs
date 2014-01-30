using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class RequestHeaderModel
    {
        public virtual int requestId { get; set; }
        public virtual string tripNo { get; set; }
        public virtual string prgTripNo { get; set; }
        public virtual string obsprgCode { get; set; }
        public virtual string staffCode { get; set; }
        public virtual int vesselId { get; set; }
        public virtual DateTime departDate { get; set; }
        public virtual DateTime returnDate { get; set; }
        public virtual int departPort { get; set; }
        public virtual int returnPort { get; set; }
        public virtual DateTime requestDate { get; set; }
        public virtual DateTime sendDate { get; set; }
        public virtual Boolean isComplete { get; set; }


        public RequestHeaderModel(RequestHeader requestHeader )
        {
            this.requestId = requestHeader.RequestId;
            this.tripNo = requestHeader.TripNo;
            this.prgTripNo = requestHeader.PrgTripNo;
            this.obsprgCode = requestHeader.ObsprgCode;
            this.staffCode = requestHeader.StaffCode;
            this.staffCode = requestHeader.StaffCode;
            this.vesselId =  requestHeader.VesselId;
            this.departDate =  requestHeader.DepartDate;
            this.returnDate =  requestHeader.ReturnDate;
            this.departPort =  requestHeader.DepartPort;
            this.returnPort =  requestHeader.ReturnPort;
            this.requestDate =  requestHeader.RequestDate;
            this.sendDate =  requestHeader.SendDate;
            this.isComplete =  requestHeader.IsComplete;

        }
    }
}