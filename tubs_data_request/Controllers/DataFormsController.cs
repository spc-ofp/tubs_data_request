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
    public class DataFormsController : ApiController
    {
        public IEnumerable<DataForms> Get()
        {
            return WebApiApplication.UnitOfWork.Session.CreateCriteria(typeof(DataForms)).List<DataForms>();
        }

        public DataForms Get(string code)
        {
            if (String.IsNullOrEmpty(code))
                return null;
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<DataForms>(x => x.FormCode.ToUpper().Trim() == code.ToUpper().Trim()).SingleOrDefault();
        }

        [HttpGet]
        public IEnumerable<DataForms> LookUp(string name = "")
        {
            if (name.Length < 2)
                return null;
            name = name.ToUpper().Trim();
            var repo = new Repository(WebApiApplication.UnitOfWork.Session);
            return repo.Find<DataForms>(x => x.FormCode.ToUpper().Trim() == name || x.FormDesc.ToUpper().Contains(name)).ToList<DataForms>().Take(10);
            //List<DataForms> list = repo.GetAll<DataForms>().ToList();
            //return list;
        }
    }
}
