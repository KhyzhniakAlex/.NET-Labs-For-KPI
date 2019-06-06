using System.ServiceModel;
using System.ServiceModel.Web;
using WcfRestService.DTOModels;

namespace WcfRestService.ServiceInterfaces
{
    [ServiceContract]
    public interface IOrderService : IBaseService<OrderDto>
    {
    }

    [ServiceContract]
    public interface ICustomerService : IBaseService<CustomerDto>
    {
    }

    [ServiceContract]
    public interface ICarService : IBaseService<CarDto>
    {
    }

    [ServiceContract]
    public interface ICarInOrderService : IBaseService<CarInOrderDto>
    {
    }

    [ServiceContract]
    public interface IManagerService : IBaseService<ManagerDto>
    {
    }

    [ServiceContract]
    public interface IManufacturerService : IBaseService<ManufacturerDto>
    {
    }
}
