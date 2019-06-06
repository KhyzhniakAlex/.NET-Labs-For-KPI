using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class CustomerViewModel : BaseViewModel<Customer>
    {
        public CustomerViewModel()
        {
            SelectedEntity = new Customer();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
        }
    }
}
