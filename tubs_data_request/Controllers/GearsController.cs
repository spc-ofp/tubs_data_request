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
    public class GearsController : ApiController
    {
        public IEnumerable<Gears> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(Gears)).List<Gears>();
        }

        public Gears Get(string code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Gears>(x => x.GearCode.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<Gears> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Gears>(x => x.GearCode.ToUpper().Trim() == name || x.GearDesc.ToUpper().Contains(name)).ToList<Gears>().Take(10);
        }
    }
}
