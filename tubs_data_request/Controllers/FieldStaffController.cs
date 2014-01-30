using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tubs_data_request.DAL.Repositories;
using tubs_data_request.Domain;

namespace tubs_data_request.Controllers
{
    public class FieldStaffController : ApiController
    {
        public IEnumerable<FieldStaff> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(FieldStaff)).List<FieldStaff>();
        }

        public FieldStaff Get(int id)
        {
            return WebApiApplication.UnitOfWork.Session.Get<FieldStaff>(id);
        }

        public FieldStaff Get(string code)
        {
            if (String.IsNullOrEmpty(code)) 
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FieldStaff>(x => x.StaffCode.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<FieldStaff> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim(); 
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FieldStaff>(x => x.StaffCode.ToUpper().Trim() == name || x.FamilyName.ToUpper().Contains(name)).ToList<FieldStaff>().Take(10);
        }
    }
}
