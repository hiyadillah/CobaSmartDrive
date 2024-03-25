using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Domain.RepositoryContext;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UserRepository : IRepositoryEntityBase<User, UserRequest>
    {
        private readonly CobaContext _dbContext;

        public UserRepository(CobaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(UserRequest entity)
        {
            var item= entity.Adapt<User>();
            item.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            await _dbContext.Set<User>().AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var item=await GetById(id);
            _dbContext.Set<User>().Remove(item);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var allItem = await _dbContext.User.ToListAsync();
            return allItem;
        }

        public async Task<User> GetById(int id)
        {
            var item = await _dbContext.Set<User>().Where(c=> c.UserID == id).FirstAsync();
            return item;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync(); 
        }

        public async Task<User> Update(int id, UserRequest entity)
        {
            var item=await GetById(id);
            item.Username=entity.Username;
            item.Password=BCrypt.Net.BCrypt.HashPassword(entity.Password);
            await SaveChangesAsync();
            return item;
        }
    }
}
