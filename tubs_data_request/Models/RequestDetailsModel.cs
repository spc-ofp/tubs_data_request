using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class RequestDetailsModel
    {
        public virtual int detailId { get; set; }
        public virtual string tripNo { get; set; }
        public virtual string fromCode { get; set; }
        public virtual int statusId { get; set; }
        public virtual string detailDesc { get; set; }
        public virtual DateTime reslovedDate { get; set; }
        public virtual string comments { get; set; }
        public virtual string enteredBy { get; set; }
        public virtual DateTime enteredDtime { get; set; }
        public virtual int requestId { get; set; }

        public RequestDetailsModel(RequestDetails requestDetails )
        {
            this.detailId =  requestDetails.DetailId;
            this.tripNo = requestDetails.TripNo;
            this.fromCode = requestDetails.FormCode;
            this.statusId = requestDetails.StatusId;
            this.detailDesc = requestDetails.DetailDesc;
            this.reslovedDate = requestDetails.ResolvedDate;
            this.comments = requestDetails.Comments;
            this.enteredBy = requestDetails.EnteredBy;
            this.enteredDtime = requestDetails.EnteredDtime;
            this.requestId = requestDetails.RequestId;

        }
    }
}