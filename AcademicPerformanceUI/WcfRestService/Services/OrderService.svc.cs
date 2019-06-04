using DataAccess.Interfaces;
using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class OrderService : BaseService<OrderDto, Order>, IOrderService 
    {
        public OrderService()
        {

        }
    }
}
