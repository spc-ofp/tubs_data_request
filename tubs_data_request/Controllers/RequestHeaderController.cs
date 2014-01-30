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
    public class RequestHeaderController : ApiController
    {
        public IEnumerable<RequestHeader> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(RequestHeader)).List<RequestHeader>();
        }
        public RequestHeader Get(int id)
        {
            return WebApiApplication.UnitOfWork.Session.Get<RequestHeader>(id);
        }
        public RequestHeader Get(string code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<RequestHeader>(x => x.TripNo.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }

        public Object GetCount() {
            int result = WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(RequestHeader)).List<RequestHeader>().Count(); 
            return new { Count = result };
        }

        [HttpGet]
        public IEnumerable<RequestHeader> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<RequestHeader>(x => x.TripNo.ToUpper().Contains(name) || x.PrgTripNo.ToUpper().Contains(name)).ToList<RequestHeader>().Take(10);
        }
    }
}
