using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tests.MockRepositories
{
    public class ManagerRepositoryMock : IRepository<Manager>
    {
        private List<Manager> managers = new List<Manager>();

        public void AddCollection(List<Manager> entities)
        {
            managers.AddRange(entities);
        }

        public Task<Manager> CreateAsync(Manager entity)
        {
            managers.Add(entity);
            return Task.FromResult(entity);
        }

        public Manager CreateEmptyObject() => new Manager();

        public Task<bool> DeleteAsync(Guid id)
        {
            managers = managers.Where(item => item.Id != id).ToList();
            return Task.FromResult(true);
        }

        public Task<List<Manager>> GetAllEntitiesAsync() => Task.FromResult(managers);

        public Task<Manager> GetFirstOrDefaultAsync(Expression<Func<Manager, bool>> predicate = null)
        {
            Manager manager = null;
            if (predicate == null) manager = managers.FirstOrDefault();
            manager = managers.AsQueryable().FirstOrDefault(predicate);
            return Task.FromResult(manager);
        }
         

        public Task<Manager> UpdateAsync(Manager entity)
        {
            var manager = managers.FirstOrDefault(item => item.Id == entity.Id);
            manager.FirstName = entity.FirstName;
            manager.LastName = entity.LastName;
            manager.PhoneNumber = entity.PhoneNumber;
            manager.Salary = entity.Salary;
            manager.Position = entity.Position;
            return Task.FromResult(entity);
        }

        public void Clear()
        {
            managers = new List<Manager>();
        }
    }
}
