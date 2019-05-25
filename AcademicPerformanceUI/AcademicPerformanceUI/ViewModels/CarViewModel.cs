using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class CarViewModel : BaseViewModel<Car>
    {
        public ObservableCollection<Guid> ManufacturerIds { get; set; }

        public CarViewModel()
        {
            SelectedEntity = new Car();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            ManufacturerIds = new ObservableCollection<Guid>(UnitOfWork.ManufacturerRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
