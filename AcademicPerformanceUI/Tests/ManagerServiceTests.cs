using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.MockRepositories;
using WcfRestService;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;
using WcfRestService.Services;

namespace Tests
{
    [TestClass]
    public class ManagerServiceTests
    {
        private readonly IManagerService managerService;
        private ManagerRepositoryMock repositoryMock = new ManagerRepositoryMock();
        private readonly ManagerDto testManager = new ManagerDto() { Id = Guid.NewGuid(), FirstName = "Khyzhniak", LastName = "Oleksandr", PhoneNumber = "+380953860579", Salary = 25000, Position = "Administrator" };

        public ManagerServiceTests()
        {
            managerService = new ManagerService(repositoryMock);
        }

        [TestMethod]
        public void Get_manager_collection_returns_according_type()
        {
            managerService.CreateEntity(testManager);
            var list = managerService.GetEntities();
            Assert.IsInstanceOfType(list, typeof(List<ManagerDto>));
        }

        [TestMethod]
        public void Add_manager_to_collection_not_empty()
        {
            managerService.CreateEntity(testManager);
            var list = managerService.GetEntities();
            Assert.IsTrue(list.Count > 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Collection_returns_empty_if_nothing_added()
        {
            var list = managerService.GetEntities();
            Assert.IsTrue(list.Count == 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Clear_collection_returns_empty()
        {
            repositoryMock.Clear();
            var list = managerService.GetEntities();
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void Add_manager_to_collection_returns_equal()
        {
            managerService.CreateEntity(testManager);
            var list = managerService.GetEntities();
            var firstOrDefault = managerService.GetEntities().FirstOrDefault();
            Assert.IsTrue(testManager.Id == firstOrDefault.Id);
            Assert.IsTrue(testManager.FirstName == firstOrDefault.FirstName);
            Assert.IsTrue(testManager.LastName == firstOrDefault.LastName);
            Assert.IsTrue(testManager.PhoneNumber == firstOrDefault.PhoneNumber);
            Assert.IsTrue(testManager.Salary == firstOrDefault.Salary);
            Assert.IsTrue(testManager.Position == firstOrDefault.Position);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_manager_count_less()
        {
            managerService.CreateEntity(testManager);
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "A", LastName = "A", PhoneNumber = "+380950000000", Salary = 15000, Position = "User" });
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "B", LastName = "B", PhoneNumber = "+380951111111", Salary = 10000, Position = "User" });
            var newId = Guid.NewGuid();
            managerService.CreateEntity(new ManagerDto() { Id = newId, FirstName = "C", LastName = "C", PhoneNumber = "+380952222222", Salary = 5000, Position = "User" });
            var previousCount = managerService.GetEntities().Count;
            managerService.DeleteEntity(newId.ToString());
            Assert.AreEqual(previousCount-1, managerService.GetEntities().Count);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_manager_item_removed()
        {
            managerService.CreateEntity(testManager);
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "A", LastName = "A", PhoneNumber = "+380950000000", Salary = 15000, Position = "User" });
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "B", LastName = "B", PhoneNumber = "+380951111111", Salary = 10000, Position = "User" });
            var newId = Guid.NewGuid();
            managerService.CreateEntity(new ManagerDto() { Id = newId, FirstName = "C", LastName = "C", PhoneNumber = "+380952222222", Salary = 5000, Position = "User" });
            var previousCount = managerService.GetEntities().Count;
            managerService.DeleteEntity(newId.ToString());
            Assert.IsNull(managerService.GetEntities().FirstOrDefault(item => item.Id == newId));
            repositoryMock.Clear();
        }


        [TestMethod]
        public void Update_manager_collection_count_save()
        {
            managerService.CreateEntity(testManager);
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "A", LastName = "A", PhoneNumber = "+380950000000", Salary = 15000, Position = "User" });
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "B", LastName = "B", PhoneNumber = "+380951111111", Salary = 10000, Position = "User" });
            var newId = Guid.NewGuid();
            var entity = managerService.CreateEntity(new ManagerDto() { Id = newId, FirstName = "C", LastName = "C", PhoneNumber = "+380952222222", Salary = 5000, Position = "User" });
            var previousCount = managerService.GetEntities().Count;
            entity.LastName = "Yakubovich";
            var countOld = managerService.GetEntities().Count;
            managerService.UpdateEntity(entity);
            var countNew = managerService.GetEntities().Count;
            Assert.AreEqual(countNew, countOld);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Update_manager_in_collection_name_changed()
        {
            managerService.CreateEntity(testManager);
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "A", LastName = "A", PhoneNumber = "+380950000000", Salary = 15000, Position = "User" });
            managerService.CreateEntity(new ManagerDto() { Id = Guid.NewGuid(), FirstName = "B", LastName = "B", PhoneNumber = "+380951111111", Salary = 10000, Position = "User" });
            var newId = Guid.NewGuid();
            var entity = managerService.CreateEntity(new ManagerDto() { Id = newId, FirstName = "C", LastName = "C", PhoneNumber = "+380952222222", Salary = 5000, Position = "User" });
            entity.LastName = "Yakubovich";
            managerService.UpdateEntity(entity);

            Assert.AreEqual(entity.LastName, managerService.GetEntities().FirstOrDefault(item => item.Id == newId).LastName);

            repositoryMock.Clear();
        }
    }
}
