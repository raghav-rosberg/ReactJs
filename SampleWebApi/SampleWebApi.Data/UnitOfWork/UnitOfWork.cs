using SampleWebApi.Data.Infrastructure;
using SampleWebApi.Data.Repositories;
using SampleWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        public async virtual Task<int> CommitAsync()
        {
            return await m_dataContext.SaveChangesAsync();
        }

        readonly System.Data.Entity.DbContext m_dataContext;

        public UnitOfWork()
        {
            m_dataContext = new SampleWebApiDbContext();
        }

        /// <summary>
        /// Repository defenitions
        /// </summary>

        IUserRepository m_userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                return m_userRepository ?? (m_userRepository = new UserRepository(m_dataContext));
            }
        }

        IRepository<LocalUser> m_localUserRepository;
        public IRepository<LocalUser> LocalUserRepository
        {
            get
            {
                return m_localUserRepository ?? (m_localUserRepository = new RepositoryBase<LocalUser>(m_dataContext));
            }
        }
    }
}
