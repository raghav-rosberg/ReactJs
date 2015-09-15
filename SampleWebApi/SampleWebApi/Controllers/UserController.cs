using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Query;
using System.Web.Http.Cors;
using SampleWebApi.Data.UnitOfWork;
using System.Threading.Tasks;
using SampleWebApi.Model.Entities;

namespace SampleWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        readonly IUnitOfWork m_unitOfWork;

        public UserController()
        {
            m_unitOfWork = new UnitOfWork();
        }

        // GET api/values
        [HttpGet]
        [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IQueryable<LocalUser>> Get()
        {
            var users = await m_unitOfWork.LocalUserRepository.GetAllAsync();
            return users.AsQueryable();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public async Task Post(LocalUser user)
        {
            m_unitOfWork.LocalUserRepository.Insert(user);
            await m_unitOfWork.CommitAsync();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
