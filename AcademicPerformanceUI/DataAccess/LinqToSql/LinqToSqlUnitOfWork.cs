using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.LinqToSql.Repositories;
using System;

namespace DataAccess.LinqToSql
{
    public class LinqToSqlUnitOfWork:IUnitOfWork
    {
        protected string ConnectionString;
        public LinqToSqlUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }


        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository => customerRepository ?? (customerRepository = new CustomerRepository(ConnectionString));

        private IRepository<Order> orderRepository;
        public IRepository<Order> OrderRepository => orderRepository ?? (orderRepository = new OrderRepository(ConnectionString));

        private IRepository<Car> carRepository;
        public IRepository<Car> CarRepository => carRepository ?? (carRepository = new CarRepository(ConnectionString));

        private IRepository<CustomerInOrder> customerInOrderRepository;
        public IRepository<CustomerInOrder> CustomerInOrderRepository => customerInOrderRepository ?? (customerInOrderRepository = new CustomerInOrderRepository(ConnectionString));

        private IRepository<Manager> managerRepository;
        public IRepository<Manager> ManagerRepository => managerRepository ?? (managerRepository = new ManagerRepository(ConnectionString));

        private IRepository<Manufacturer> manufacturerRepository;
        public IRepository<Manufacturer> ManufacturerRepository => manufacturerRepository ?? (manufacturerRepository = new ManufacturerRepository(ConnectionString));


        public IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity
        {
            var entityType = typeof(Entity);

            if (entityType == typeof(Customer)) return (IRepository<Entity>)CustomerRepository;
            if (entityType == typeof(Order)) return (IRepository<Entity>)OrderRepository;
            if (entityType == typeof(Car)) return (IRepository<Entity>)CarRepository;
            if (entityType == typeof(CustomerInOrder)) return (IRepository<Entity>)CustomerInOrderRepository;
            if (entityType == typeof(Manager)) return (IRepository<Entity>)ManagerRepository;
            if (entityType == typeof(Manufacturer)) return (IRepository<Entity>)ManufacturerRepository;

            throw new NotSupportedException();
        }
    }
}
