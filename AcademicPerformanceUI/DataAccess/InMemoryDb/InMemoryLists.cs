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
            CustomerInOrders = new List<CustomerInOrder>();
            Managers = new List<Manager>();

            Managers.Add(new Manager()
            {
                Id = Guid.NewGuid(),
                FirstName = "Oleksandr",
                LastName = "Khyzhniak",
                PhoneNumber = "+380507896456",
                Salary = 25000,
                Position = "Administrator"
            });
        }

        public static List<Order> Orders;
        public static List<Customer> Customers;
        public static List<Car> Cars;
        public static List<Manager> Managers;
        public static List<Manufacturer> Manufacturers;
        public static List<CustomerInOrder> CustomerInOrders;
    }
}
