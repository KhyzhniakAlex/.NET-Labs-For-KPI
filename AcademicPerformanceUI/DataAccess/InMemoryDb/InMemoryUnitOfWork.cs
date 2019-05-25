using DataAccess.InMemoryDb.Repository;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;

namespace DataAccess.InMemoryDb
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository => customerRepository ?? (customerRepository = new CustomerRepository());

        private IRepository<Order> orderRepository;
        public IRepository<Order> OrderRepository => orderRepository ?? (orderRepository = new OrderRepository());

        private IRepository<Car> carRepository;
        public IRepository<Car> CarRepository => carRepository ?? (carRepository = new CarRepository());

        private IRepository<CustomerInOrder> customerInOrderRepository;
        public IRepository<CustomerInOrder> CustomerInOrderRepository => customerInOrderRepository ?? (customerInOrderRepository = new CustomerInOrderRepository());

        private IRepository<Manager> managerRepository;
        public IRepository<Manager> ManagerRepository => managerRepository ?? (managerRepository = new ManagerRepository());

        private IRepository<Manufacturer> manufacturerRepository;
        public IRepository<Manufacturer> ManufacturerRepository => manufacturerRepository ?? (manufacturerRepository = new ManufacturerRepository());



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
