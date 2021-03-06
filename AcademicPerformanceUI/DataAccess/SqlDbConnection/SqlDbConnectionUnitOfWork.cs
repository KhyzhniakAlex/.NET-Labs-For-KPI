﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.SqlDbConnection.Repositories;
using System;

namespace DataAccess.SqlDbConnection
{
    public class SqlDbConnectionUnitOfWork : IUnitOfWork
    {
        protected string ConnectionString;
        public SqlDbConnectionUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }


        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository => customerRepository ?? (customerRepository = new CustomerRepository(ConnectionString));

        private IRepository<Order> orderRepository;
        public IRepository<Order> OrderRepository => orderRepository ?? (orderRepository = new OrderRepository(ConnectionString));

        private IRepository<Car> carRepository;
        public IRepository<Car> CarRepository => carRepository ?? (carRepository = new CarRepository(ConnectionString));

        private IRepository<CarInOrder> carInOrderRepository;
        public IRepository<CarInOrder> CarInOrderRepository => carInOrderRepository ?? (carInOrderRepository = new CarInOrderRepository(ConnectionString));

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
            if (entityType == typeof(CarInOrder)) return (IRepository<Entity>)CarInOrderRepository;
            if (entityType == typeof(Manager)) return (IRepository<Entity>)ManagerRepository;
            if (entityType == typeof(Manufacturer)) return (IRepository<Entity>)ManufacturerRepository;

            throw new NotSupportedException();
        }
    }
}
