using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Car> CarRepository { get; }
        IRepository<CustomerInOrder> CustomerInOrderRepository { get; }
        IRepository<Manager> ManagerRepository { get; }
        IRepository<Manufacturer> ManufacturerRepository { get;  }

        IRepository<Entity> GetRepositoryByEntityType<Entity>() where Entity : IEntity;
    }
}
