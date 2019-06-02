using DataAccess.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.InMemoryDb
{
    public static class InMemoryLists
    {
        public static List<Order> Orders;
        public static List<Customer> Customers;
        public static List<Car> Cars;
        public static List<Manager> Managers;
        public static List<Manufacturer> Manufacturers;
        public static List<CarInOrder> CarInOrders;

        static InMemoryLists()
        {
            Orders = new List<Order>();
            Customers = new List<Customer>();
            Cars = new List<Car>();
            Manufacturers = new List<Manufacturer>();
            CarInOrders = new List<CarInOrder>();
            Managers = new List<Manager>();

            InitManufacturer();
            InitManager();
            InitCustomer();
            InitCar();
            InitOrder();
            InitCarInOrders();
        }

        static void InitManufacturer()
        {
            Manufacturers.Add(new Manufacturer()
            {
                Id = Guid.NewGuid(),
                Name = "Mercedes Benz",
                OfficePhoneNumber = "+470458046738",
                Country = "Germany"
            });
        }

        static void InitManager()
        {
            Managers.Add(new Manager()
            {
                Id = Guid.NewGuid(),
                FirstName = "Vtaliy",
                LastName = "Klichko",
                PhoneNumber = "+380507419852",
                Salary = 250000,
                Position = "Director"
            });
        }

        static void InitCustomer()
        {
            Customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Vtaliy",
                LastName = "Klichko",
                PhoneNumber = "+380507419852",
                PassportSeries = "TT749646",
                AccoutId = "AA00AA01"
            });
        }

        static void InitCar()
        {
            Manufacturer m = (Manufacturer)InMemoryLists.Manufacturers.Take(1);
            Cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                Brand = "Masda",
                Model = "6",
                SerialNumber = "N78TY85YJ45",
                Color = "Red",
                Price = 250000,
                ManufacturerId = m.Id
            });
        }

        static void InitOrder()
        {
            Customer c = (Customer)Customers.Take(1);
            Manager m = (Manager)Managers.Take(1);
            Orders.Add(new Order()
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = new DateTime(2020, 07, 10),
                Sum = 200000,
                CustomerId = c.Id,
                ManagerId = m.Id
            });
        }

        static void InitCarInOrders()
        {
            Order o = (Order)Orders.Take(1);
            Car c = (Car)Cars.Take(1);
            CarInOrders.Add(new CarInOrder()
            {
                OrderId = o.Id,
                CarId = c.Id
            });
        }
    }
}
