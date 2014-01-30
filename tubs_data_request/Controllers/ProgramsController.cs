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
    public class ProgramsController : ApiController
    {
        public IEnumerable<Programs> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(Programs)).List<Programs>();
        }

        public Programs Get(string code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Programs>(x => x.ObsprgCode.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<Programs> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Programs>(x => x.ObsprgCode.ToUpper().Trim() == name || x.Description.ToUpper().Contains(name)).ToList<Programs>().Take(10);
        }
    }
}
