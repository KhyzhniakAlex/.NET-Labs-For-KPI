using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.InMemoryDb
{
    public static class InMemoryLists
    {
        static InMemoryLists()
        {
            Orders = new List<Order>();
            Customers = new List<Customer>();
            Cars = new List<Car>();
            Manufacturers = new List<Manufacturer>();
            CarInOrders = new List<CarInOrder>();
            Managers = new List<Manager>();

            Cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                Brand = "Masda",
                Model = "6",
                SerialNumber = "N78TY85YJ45",
                Color = "Red",
                Price = 250000
            });
        }

        public static List<Order> Orders;
        public static List<Customer> Customers;
        public static List<Car> Cars;
        public static List<Manager> Managers;
        public static List<Manufacturer> Manufacturers;
        public static List<CarInOrder> CarInOrders;
    }
}
