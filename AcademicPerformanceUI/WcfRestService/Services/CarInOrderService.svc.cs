﻿using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CarInOrderService : BaseService<CarInOrderDto, CarInOrder>, ICarInOrderService
    {
        public CarInOrderService()
        {

        }
    }

}
