using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tubs_data_request.Domain
{
    public class FieldStaff
    {
        public virtual int StaffId { get; set; }
        public virtual string StaffCode { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int StaffTypeId { get; set; }
        public virtual string ObsprgCode { get; set; }
        public virtual string EntityCode { get; set; }
        public virtual int HomePortId { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual int PrvId { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string ContactName { get; set; }
        public virtual int MstId { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string NextOfKinName { get; set; }
        public virtual string NextOfKinPhone { get; set; }
        public virtual string PassportNumber { get; set; }
        public virtual string PassportName { get; set; }
        public virtual DateTime PassportIssueDate { get; set; }
        public virtual string PassportIssuePlace{ get; set; }
        public virtual DateTime PassportExpiryDate { get; set; }
        public virtual string BankName { get; set; }
        public virtual string BankAccountNumber { get; set; }
        public virtual string Height { get; set; }
        public virtual string Weight { get; set; }
        public virtual string ShoeSize { get; set; }
        public virtual string ShirtSize { get; set; }
        public virtual string TrouserSize { get; set; }
        public virtual string KitType { get; set; }
        public virtual DateTime KitIssueDate { get; set; }
        public virtual int Rating { get; set; }
        public virtual string EnteredBy { get; set; }
        public virtual Boolean Active { get; set; }
    }
}