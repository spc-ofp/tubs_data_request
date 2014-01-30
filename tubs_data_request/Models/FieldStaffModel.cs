using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.Models
{
    public class FieldStaffModel
    {
        public virtual int staffId { get; set; }
        public virtual string staffCode { get; set; }
        public virtual string firstName { get; set; }
        public virtual string familyName { get; set; }
        public virtual DateTime birthDate { get; set; }
        public virtual int staffTypeId { get; set; }
        public virtual string obsprgCode { get; set; }
        public virtual string entityCode { get; set; }
        public virtual int homePortId { get; set; }
        public virtual string address1 { get; set; }
        public virtual string address2 { get; set; }
        public virtual int prvId { get; set; }
        public virtual string phone { get; set; }
        public virtual string fax { get; set; }
        public virtual string email { get; set; }
        public virtual string contactName { get; set; }
        public virtual int mstId { get; set; }
        public virtual string maritalStatus { get; set; }
        public virtual string nextOfKinName { get; set; }
        public virtual string nextOfKinPhone { get; set; }
        public virtual string passportNumber { get; set; }
        public virtual string passportName { get; set; }
        public virtual DateTime passportIssueDate { get; set; }
        public virtual string passportIssuePlace { get; set; }
        public virtual DateTime passportExpiryDate { get; set; }
        public virtual string bankName { get; set; }
        public virtual string bankAccountNumber { get; set; }
        public virtual string height { get; set; }
        public virtual string weight { get; set; }
        public virtual string shoeSize { get; set; }
        public virtual string shirtSize { get; set; }
        public virtual string trouserSize { get; set; }
        public virtual string kitType { get; set; }
        public virtual DateTime kitIssueDate { get; set; }
        public virtual int rating { get; set; }
        public virtual string enteredBy { get; set; }
        public virtual Boolean active { get; set; }

        public FieldStaffModel() { }

        public FieldStaffModel(FieldStaff fieldStaff)
        {
            this.staffId = fieldStaff.StaffId;
            this.staffCode = fieldStaff.StaffCode;
            this.firstName = fieldStaff.FirstName;
            this.familyName = fieldStaff.FamilyName;
            this.birthDate = fieldStaff.BirthDate;
            this.staffTypeId = fieldStaff.StaffTypeId;
            this.obsprgCode = fieldStaff.ObsprgCode;
            this.entityCode = fieldStaff.EntityCode;
            this.homePortId = fieldStaff.HomePortId;
            this.address1 = fieldStaff.Address1;
            this.address2 = fieldStaff.Address2;
            this.prvId = fieldStaff.PrvId;
            this.phone = fieldStaff.Phone;
            this.fax = fieldStaff.Fax;
            this.email = fieldStaff.Email;
            this.contactName = fieldStaff.ContactName;
            this.mstId = fieldStaff.MstId;
            this.maritalStatus = fieldStaff.MaritalStatus;
            this.nextOfKinName = fieldStaff.NextOfKinName;
            this.nextOfKinPhone = fieldStaff.NextOfKinPhone;
            this.passportNumber= fieldStaff.PassportNumber;
            this.passportName = fieldStaff.PassportName;
            this.passportIssueDate = fieldStaff.PassportIssueDate;
            this.passportIssuePlace = fieldStaff.PassportIssuePlace;
            this.passportExpiryDate = fieldStaff.PassportExpiryDate;
            this.bankName = fieldStaff.BankName;
            this.bankAccountNumber = fieldStaff.BankAccountNumber;
            this.height = fieldStaff.Height;
            this.weight = fieldStaff.Weight;
            this.shoeSize = fieldStaff.ShoeSize;
            this.shirtSize = fieldStaff.ShirtSize;
            this.trouserSize = fieldStaff.TrouserSize;
            this.kitType = fieldStaff.KitType ;
            this.kitIssueDate = fieldStaff.KitIssueDate;
            this.rating = fieldStaff.Rating;
            this.enteredBy = fieldStaff.EnteredBy;
            this.active = fieldStaff.Active;

        }
    }
}