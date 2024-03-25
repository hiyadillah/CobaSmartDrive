using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Domain.RepositoryContext;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class RoleRespository : IRepositoryEntityBase<Role, RoleRequest>
    {
        private readonly CobaContext _dbContext;

        public RoleRespository(CobaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> Create(RoleRequest entity)
        {
            var item = entity.Adapt<Role>();
            await _dbContext.Set<Role>().AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            _dbContext.Set<Role>().Remove(item);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var allItem = await _dbContext.Role.ToListAsync();
            return allItem;
        }

        public async Task<Role> GetById(int id)
        {
            var item = await _dbContext.Set<Role>().Include(c=>c.Userentity).Where(c => c.RoleID == id).FirstAsync();
            return item;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> Update(int id, RoleRequest entity)
        {
            var item = await GetById(id);
            item.RoleName = entity.RoleName;
            item.UserId = entity.UserId;
            await SaveChangesAsync();
            return item;
        }
    }
}
