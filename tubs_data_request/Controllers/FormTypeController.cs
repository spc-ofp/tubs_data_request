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
    public class FormTypeController : ApiController
    {
        public IEnumerable<FormType> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(FormType)).List<FormType>();
        }

        public FormType Get(int id)
        {
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FormType>(x => x.FormTypeId == id).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<FormType> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<FormType>(x => x.FormTypeDesc.ToUpper().Contains(name)).ToList<FormType>().Take(10);
        }
    }
}
