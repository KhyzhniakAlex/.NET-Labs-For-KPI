using DataAccess.Interfaces;
using Model = DataAccess.Models;
using System;
using DataAccess.Models;
using CrudWebService.DTOModels;

namespace CrudWebService.Services
{
    public class Mapper
    {
        public IEntity MapToModel(IBaseDto entity)
        {
            if (entity == null) throw new FormatException();
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "OrderDto":
                    {
                        var dtoEntity = (OrderDto)entity;
                        return new Order() {
                            Id = dtoEntity.Id,
                            StartDate = dtoEntity.StartDate,
                            EndDate = dtoEntity.EndDate,
                            Sum = dtoEntity.Sum,
                            CustomerId = dtoEntity.CustomerId
                        };
                    }
                case "CustomerDto":
                    {
                        var dtoEntity = (CustomerDto)(IBaseDto)entity;
                        return new Customer() {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            PassportSeries = dtoEntity.PassportSeries,
                            AccoutId = dtoEntity.AccoutId
                        };
                    }
                case "CarDto":
                    {
                        var dtoEntity = (CarDto)(IBaseDto)entity;
                        return new Car()
                        {
                            Id = dtoEntity.Id,
                            Brand = dtoEntity.Brand,
                            Model = dtoEntity.Model,
                            SerialNumber = dtoEntity.SerialNumber,
                            Color = dtoEntity.Color,
                            Price = dtoEntity.Price,
                            ManufacturerId = dtoEntity.ManufacturerId,
                            ManagerId = dtoEntity.ManagerId
                        };
                    }
                case "CustomerInOrderDto":
                    {
                        var dtoEntity = (CustomerInOrderDto)(IBaseDto)entity;
                        return new CustomerInOrder()
                        {
                            Id = dtoEntity.Id,
                            OrderId = dtoEntity.OrderId,
                            CarId = dtoEntity.CarId
                        };
                    }
                case "ManagerDto":
                    {
                        var dtoEntity = (ManagerDto)(IBaseDto)entity;
                        return new Manager()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            Salary = dtoEntity.Salary,
                            Position = dtoEntity.Position
                        };
                    }
                case "ManufacturerDto":
                    {
                        var dtoEntity = (ManufacturerDto)(IBaseDto)entity;
                        return new Manufacturer()
                        {
                            Id = dtoEntity.Id,
                            Name = dtoEntity.Name,
                            OfficePhoneNumber = dtoEntity.OfficePhoneNumber,
                            Country = dtoEntity.Country
                        };
                    }
                default: throw new NotSupportedException();
            }
        }

        public IBaseDto MapToDto<T>(IEntity entity)
        {
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "Order":
                    {
                        var dtoEntity = (Order)entity;
                        return new OrderDto() {
                            Id = dtoEntity.Id,
                            StartDate = dtoEntity.StartDate,
                            EndDate = dtoEntity.EndDate,
                            Sum = dtoEntity.Sum,
                            CustomerId = dtoEntity.CustomerId
                        };
                    }
                case "Customer":
                    {
                        var dtoEntity = (Customer)entity;
                        return new CustomerDto() {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            PassportSeries = dtoEntity.PassportSeries,
                            AccoutId = dtoEntity.AccoutId
                        };
                    }
                case "Car":
                    {
                        var dtoEntity = (Car)entity;
                        return new CarDto()
                        {
                            Id = dtoEntity.Id,
                            Brand = dtoEntity.Brand,
                            Model = dtoEntity.Model,
                            SerialNumber = dtoEntity.SerialNumber,
                            Color = dtoEntity.Color,
                            Price = dtoEntity.Price,
                            ManufacturerId = dtoEntity.ManufacturerId,
                            ManagerId = dtoEntity.ManagerId
                        };
                    }
                case "CustomerInOrder":
                    {
                        var dtoEntity = (CustomerInOrder)entity;
                        return new CustomerInOrderDto()
                        {
                            Id = dtoEntity.Id,
                            OrderId = dtoEntity.OrderId,
                            CarId = dtoEntity.CarId
                        };
                    }
                case "Manager":
                    {
                        var dtoEntity = (Manager)entity;
                        return new ManagerDto()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            Salary = dtoEntity.Salary,
                            Position = dtoEntity.Position
                        };
                    }
                case "Manufacturer":
                    {
                        var dtoEntity = (Manufacturer)entity;
                        return new ManufacturerDto()
                        {
                            Id = dtoEntity.Id,
                            Name = dtoEntity.Name,
                            OfficePhoneNumber = dtoEntity.OfficePhoneNumber,
                            Country = dtoEntity.Country
                        };
                    }
                default: throw new NotSupportedException();
            }
        }
    }
}