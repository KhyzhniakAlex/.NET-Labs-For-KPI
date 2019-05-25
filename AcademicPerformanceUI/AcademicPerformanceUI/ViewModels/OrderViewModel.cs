using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class OrderViewModel : BaseViewModel<Order>
    {
        public OrderViewModel()
        {
            SelectedEntity = new Order();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
        }
    }
}
