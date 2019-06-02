using DataAccess.Models;
using DataAccess.SqlDbConnection;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.ServiceModel;
using WcfMsmqService.Interfaces;

namespace WcfMsmqService.Services
{
    public class AcademicService:IAcademicService
    {
        private static string connectionString = @"Data Source = Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\SASHA\CarSalonDB.mdf;Integrated Security=True;Connect Timeout=30";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));

        #region drivers

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateCar(string driver)
        {
            try
            {
                Console.WriteLine("Recieved car: " + driver);

                _ = UnitOfWork.Value.CarRepository.CreateAsync(JsonConvert.DeserializeObject<Car>(driver)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateCar(string driver)
        {
            try
            {
                Console.WriteLine("Recieved updated car: " + driver);
                var driverObj = JsonConvert.DeserializeObject<Car>(driver);

                var guid = driverObj.Id;
                var item = UnitOfWork.Value.CarRepository.GetAllEntitiesAsync().Result.Where(x => x.Id == guid).FirstOrDefault();

                item.Brand = driverObj.Brand;
                item.Model = driverObj.Model;
                item.SerialNumber = driverObj.SerialNumber;
                item.Color = driverObj.Color;
                item.Price = driverObj.Price;
                item.ManufacturerId = driverObj.ManufacturerId;

                _ = UnitOfWork.Value.CarRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveCar(string driverId)
        {
            try
            {
                Console.WriteLine("Remove car with id: " + driverId);
                var guid = Guid.Parse(driverId);
                UnitOfWork.Value.CarRepository.DeleteAsync(guid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region shifts

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateCiO(string shift)
        {
            try
            {
                Console.WriteLine("Recieved cio: " + shift);

                _ = UnitOfWork.Value.CarInOrderRepository.CreateAsync(JsonConvert.DeserializeObject<CarInOrder>(shift)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateCiO(string shift)
        {
            try
            {
                Console.WriteLine("Recieved updated cio: " + shift);
                var shiftObj = JsonConvert.DeserializeObject<CarInOrder>(shift);

                var guid = shiftObj.Id;
                var item = UnitOfWork.Value.CarInOrderRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.OrderId = shiftObj.OrderId;
                item.CarId = shiftObj.CarId;

                _ = UnitOfWork.Value.CarInOrderRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveCiO(string shiftId)
        {
            try
            {
                Console.WriteLine("Remove cio with id: " + shiftId);
                var guid = Guid.Parse(shiftId);
                _ = UnitOfWork.Value.CarInOrderRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region routes

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateOrder(string route)
        {
            try
            {
                Console.WriteLine("Recieved order: " + route);

                var routeObj = JsonConvert.DeserializeObject<Order>(route);


                _ = UnitOfWork.Value.OrderRepository.CreateAsync(routeObj).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateOrder(string route)
        {
            try
            {
                Console.WriteLine("Recieved updated order: " + route);
                var routeObj = JsonConvert.DeserializeObject<Order>(route);

                var guid = routeObj.Id;
                var item = UnitOfWork.Value.OrderRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.StartDate = routeObj.StartDate;
                item.EndDate = routeObj.EndDate;
                item.Sum = routeObj.Sum;
                item.CustomerId = routeObj.CustomerId;
                item.ManagerId = routeObj.ManagerId;

                _ = UnitOfWork.Value.OrderRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveOrder(string routeId)
        {
            try
            {
                Console.WriteLine("Remove order with id: " + routeId);
                var guid = Guid.Parse(routeId);
                _ = UnitOfWork.Value.OrderRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion
    }
}
