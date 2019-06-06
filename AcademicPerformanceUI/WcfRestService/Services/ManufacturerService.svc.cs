using DataAccess.Interfaces;
using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ManufacturerService : BaseService<ManufacturerDto, Manufacturer>, IManufacturerService
    {
        public ManufacturerService(IRepository<Manufacturer> repository) : base(repository)
        {

        }
        public ManufacturerService()
        {
                    
        }
    }
}
