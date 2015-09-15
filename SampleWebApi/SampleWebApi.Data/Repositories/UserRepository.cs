using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SampleWebApi.Data.Infrastructure;
using SampleWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SampleWebApi.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        readonly UserManager<ApplicationUser> m_userManager;
        readonly SampleWebApiDbContext m_dbContext;

        public UserRepository(System.Data.Entity.DbContext dbContext)
            : base(dbContext)
        {
            m_dbContext = (m_dbContext ?? (SampleWebApiDbContext)dbContext);
            m_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SampleWebApiDbContext()));
            m_userManager.UserValidator = new UserValidator<ApplicationUser>(m_userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public async Task InsertAsync(ApplicationUser user)
        {
            await m_userManager.CreateAsync(user);
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            await m_userManager.UpdateAsync(user);
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await m_userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> where)
        {
            return await m_userManager.Users.FirstOrDefaultAsync(where);
        }
    }
}
