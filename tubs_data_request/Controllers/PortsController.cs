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
    public class PortsController : ApiController
    {
        public IEnumerable<Ports> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(Ports)).List<Ports>();
        }

        public Ports Get(int id)
        {
            return WebApiApplication.UnitOfWork.Session.Get<Ports>(id);
        }
        public Ports Get(string code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Ports>(x => x.LocationCode.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }
        [HttpGet]
        public IEnumerable<Ports> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<Ports>(x => x.LocationCode.ToUpper().Trim() == name || x.PortName.ToUpper().Contains(name)).ToList<Ports>().Take(10);
        }
    }
}
