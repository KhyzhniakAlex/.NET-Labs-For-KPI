using DataAccess.Interfaces;
using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ManagerService : BaseService<ManagerDto, Manager>, IManagerService
    {
        public ManagerService(IRepository<Manager> repository) : base(repository)
        {

        }
    }
}
