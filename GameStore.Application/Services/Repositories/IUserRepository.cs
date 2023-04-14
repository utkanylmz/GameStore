using Core.Persistence.Repositories;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Repositories
{
    public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
    {
    }
}
