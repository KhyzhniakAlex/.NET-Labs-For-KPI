using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class OrderViewModel : BaseViewModel<Order>
    {
        public ObservableCollection<Guid> CustomerIds { get; set; }
        public ObservableCollection<Guid> ManagerIds { get; set; }
        public OrderViewModel()
        {
            SelectedEntity = new Order();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            CustomerIds = new ObservableCollection<Guid>(UnitOfWork.CustomerRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
            ManagerIds = new ObservableCollection<Guid>(UnitOfWork.ManagerRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
