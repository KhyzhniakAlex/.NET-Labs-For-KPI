using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.InMemoryDb.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        public Task<TEntity> CreateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Order order: InMemoryLists.Orders.Add(order); break;
                case Customer customer: InMemoryLists.Customers.Add(customer); break;
                case Car car: InMemoryLists.Cars.Add(car); break;
                case Manager manager: InMemoryLists.Managers.Add(manager); break;
                case Manufacturer manufacturer: InMemoryLists.Manufacturers.Add(manufacturer); break;
                case CustomerInOrder customerInOrder: InMemoryLists.CustomerInOrders.Add(customerInOrder); break;
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid Id)
        {
            InMemoryLists.Customers = InMemoryLists.Customers.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Orders = InMemoryLists.Orders.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Cars = InMemoryLists.Cars.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Managers = InMemoryLists.Managers.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.Manufacturers = InMemoryLists.Manufacturers.Where(x => x.Id != Id)
                               .ToList();
            InMemoryLists.CustomerInOrders = InMemoryLists.CustomerInOrders.Where(x => x.Id != Id)
                               .ToList();

            return Task.FromResult(true);
        }

        public Task<List<TEntity>> GetAllEntitiesAsync()
        {
            var type = typeof(TEntity);
            List<IEntity> list = null;

            if (type == typeof(Order)) list =  InMemoryLists.Orders.Select(item => (IEntity)item).ToList();
            if (type == typeof(Customer)) list = InMemoryLists.Customers.Select(item => (IEntity)item).ToList();
            if (type == typeof(Car)) list = InMemoryLists.Cars.Select(item => (IEntity)item).ToList();
            if (type == typeof(Manager)) list = InMemoryLists.Managers.Select(item => (IEntity)item).ToList();
            if (type == typeof(Manufacturer)) list = InMemoryLists.Manufacturers.Select(item => (IEntity)item).ToList();
            if (type == typeof(CustomerInOrder)) list = InMemoryLists.CustomerInOrders.Select(item => (IEntity)item).ToList();

            return Task.FromResult(list.Select(item => (TEntity)item).ToList());
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            switch (entity)
            {
                case Order group:
                    {
                        var oldEntity = InMemoryLists.Orders.Find(o => o.Id == entity.Id);
                        oldEntity = (Order)entity.Clone();
                        break;
                    }
                case Customer student:
                    {
                        var oldEntity = InMemoryLists.Customers.Find(o => o.Id == entity.Id);
                        oldEntity = (Customer)entity.Clone();
                        break;
                    }
                case Car subject:
                    {
                        var oldEntity = InMemoryLists.Cars.Find(o => o.Id == entity.Id);
                        oldEntity = (Car)entity.Clone();
                        break;
                    }
                case Manager teacher:
                    {

                        var oldEntity = InMemoryLists.Managers.Find(o => o.Id == entity.Id);
                        oldEntity = (Manager)entity.Clone();
                        break;
                    }
                case Manufacturer test:
                    {
                        var oldEntity = InMemoryLists.Manufacturers.Find(o => o.Id == entity.Id);
                        oldEntity = (Manufacturer)entity.Clone();
                        break;
                    }
                case CustomerInOrder subjectInGroup:
                    {
                        var oldEntity = InMemoryLists.CustomerInOrders.Find(o => o.Id == entity.Id);
                        oldEntity = (CustomerInOrder)entity.Clone();
                        break;
                    }
                default: throw new Exception("There is no such type");
            }

            return Task.FromResult(entity);
        }

        public void AddCollection(List<TEntity> entities)
        {
            var type = typeof(TEntity);
            if (type == typeof(Order))
            {
                InMemoryLists.Orders.Clear();
            }
            if (type == typeof(Customer))
            {
                InMemoryLists.Customers.Clear();
            }
            if (type == typeof(Car))
            {
                InMemoryLists.Cars.Clear();
            }
            if (type == typeof(Manager))
            {
                InMemoryLists.Managers.Clear();
            }
            if (type == typeof(Manufacturer))
            {
                InMemoryLists.Manufacturers.Clear();
            }
            if (type == typeof(CustomerInOrder))
            {
                InMemoryLists.CustomerInOrders.Clear();
            }
            entities.ForEach(item => CreateAsync(item));
            //throw new Exception("No such types");
        }

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity);
            IEntity newObject = null;
            if (type == typeof(Order)) newObject = new Order();
            if (type == typeof(Customer)) newObject = new Customer();
            if (type == typeof(Car)) newObject = new Car();
            if (type == typeof(Manager)) newObject = new Manager();
            if (type == typeof(Manufacturer)) newObject = new Manufacturer();
            if (type == typeof(CustomerInOrder)) newObject = new CustomerInOrder();
            return (TEntity)newObject;
        }
    }
}
