using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class ManagerViewModel : BaseViewModel<Manager>
    {
        public ManagerViewModel()
        {
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            SelectedEntity = new Manager();
        }
    }
}
