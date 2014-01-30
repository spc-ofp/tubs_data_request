using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.Domain;

namespace tubs_data_request.DAL.Maps
{
    public class FieldStaffMap : ClassMap<FieldStaff>
    {
        public FieldStaffMap()
        {
            ReadOnly();
            Schema("ref");
            Table("field_staff");
            Id(x => x.StaffId).Column("staff_id");
            Map(x => x.StaffCode).Column("staff_code");
            Map(x => x.FirstName).Column("first_name");
            Map(x => x.FamilyName).Column("family_name");
            Map(x => x.BirthDate).Column("birth_date");
            Map(x => x.StaffTypeId).Column("staff_type_id");
            Map(x => x.ObsprgCode).Column("obs_prg_code");
            Map(x => x.EntityCode).Column("entity_code");
            Map(x => x.HomePortId).Column("home_port_id");
            Map(x => x.Address1).Column("address1");
            Map(x => x.Address2).Column("address2");
            Map(x => x.PrvId).Column("prv_id");
            Map(x => x.Phone).Column("phone");
            Map(x => x.Fax).Column("fax");
            Map(x => x.Email).Column("email");
            Map(x => x.ContactName).Column("contact_name");
            Map(x => x.MstId).Column("mst_id");
            Map(x => x.MaritalStatus).Column("marital_status");
            Map(x => x.NextOfKinName).Column("next_of_kin_name");
            Map(x => x.NextOfKinPhone).Column("next_of_kin_phone");
            Map(x => x.PassportNumber).Column("passport_number");
            Map(x => x.PassportName).Column("passport_name");
            Map(x => x.PassportIssueDate).Column("passport_issue_date");
            Map(x => x.PassportIssuePlace).Column("passport_issue_place");
            Map(x => x.PassportExpiryDate).Column("passport_expiry_date");
            Map(x => x.BankName).Column("bank_name");
            Map(x => x.BankAccountNumber).Column("bank_account_number");
            Map(x => x.Height).Column("height");
            Map(x => x.Weight).Column("weight");
            Map(x => x.ShoeSize).Column("shoe_size");
            Map(x => x.ShirtSize).Column("shirt_size");
            Map(x => x.TrouserSize).Column("trouser_size");
            Map(x => x.KitType).Column("kit_type");
            Map(x => x.KitIssueDate).Column("kit_issue_date");
            Map(x => x.Rating).Column("rating");
            Map(x => x.EnteredBy).Column("entered_by");
            //Map(x => x.Active).Column("is_active");

        }
    }
}