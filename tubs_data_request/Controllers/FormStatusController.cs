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
    public class FormStatusController : ApiController
    {
        public IEnumerable<FormStatus> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(FormStatus)).List<FormStatus>();
        }

        public FormStatus Get(int id)
        {
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FormStatus>(x => x.FormStatusId == id).SingleOrDefault();
          

        }

        [HttpGet]
        public IEnumerable<FormStatus> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FormStatus>(x => x.FormStatusDesc.ToUpper().Contains(name)).ToList<FormStatus>().Take(10);

        }
    }
}
