using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class CustomerInOrderViewModel : BaseViewModel<CustomerInOrder>
    {
        public ObservableCollection<Guid> CarIds { get; set; }
        public ObservableCollection<Guid> OrdersIds { get; set; }

        public CustomerInOrderViewModel()
        {
            SelectedEntity = new CustomerInOrder();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            CarIds = new ObservableCollection<Guid>(UnitOfWork.CarRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
            OrdersIds = new ObservableCollection<Guid>(UnitOfWork.OrderRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
