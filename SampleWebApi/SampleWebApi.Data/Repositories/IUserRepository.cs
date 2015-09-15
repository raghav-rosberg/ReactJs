using SampleWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> where);
    }
}
