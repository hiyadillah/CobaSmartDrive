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
    public class PermissionRespository : IRepositoryEntityBase<Permission, PermissionRequest>
    {
        private readonly CobaContext _dbContext;

        public PermissionRespository(CobaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission> Create(PermissionRequest entity)
        {
            var item = entity.Adapt<Permission>();
            await _dbContext.Set<Permission>().AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            _dbContext.Set<Permission>().Remove(item);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            var allItem = await _dbContext.Permission.ToListAsync();
            return allItem;
        }

        public async Task<Permission> GetById(int id)
        {
            var item = await _dbContext.Set<Permission>().Include(c => c.RoleEntity).Where(c => c.PermissionID == id).FirstAsync();
            return item;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Permission> Update(int id, PermissionRequest entity)
        {
            var item = await GetById(id);
            item.PermissionType = entity.PermissionType.ToString();
            item.RoleId = entity.RoleId;
            await SaveChangesAsync();
            return item;
        }
    }
}
