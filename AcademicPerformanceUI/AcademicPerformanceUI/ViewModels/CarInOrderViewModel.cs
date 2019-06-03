using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class CarInOrderViewModel : BaseViewModel<CarInOrder>
    {
        public ObservableCollection<Guid> CarIds { get; set; }
        public ObservableCollection<Guid> OrderIds { get; set; }

        public CarInOrderViewModel()
        {
            SelectedEntity = new CarInOrder();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            CarIds = new ObservableCollection<Guid>(UnitOfWork.CarRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
            OrderIds = new ObservableCollection<Guid>(UnitOfWork.OrderRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
