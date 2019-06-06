using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;
using DataAccess.Interfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CarService :BaseService<CarDto, Car>, ICarService
    {
        public CarService(IRepository<Car> repository) : base(repository)
        {

        }
        public CarService()
        {

        }
    }
}
