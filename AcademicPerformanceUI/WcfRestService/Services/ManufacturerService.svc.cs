﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System.ServiceModel;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace WcfRestService.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ManufacturerService : BaseService<ManufacturerDto, Manufacturer>, IManufacturerService
    {
    }
}
