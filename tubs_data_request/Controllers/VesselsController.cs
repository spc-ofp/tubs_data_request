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
    public class VesselsController : ApiController
    {
        public IEnumerable<Vessels> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(Vessels)).List<Vessels>();
        }

        public Vessels Get(int id)
        {
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Vessels>(x => x.VesselId == id).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<Vessels> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Vessels>(x => x.VesselName.ToUpper().Contains(name)).ToList<Vessels>().Take(10);
        }
    }
}
