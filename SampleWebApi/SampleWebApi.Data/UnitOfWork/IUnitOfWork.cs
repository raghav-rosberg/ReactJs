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
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        /// <summary>
        /// Repository intefaces
        /// </summary>
        IUserRepository UserRepository { get; }
        IRepository<LocalUser> LocalUserRepository { get; }
    }
}
