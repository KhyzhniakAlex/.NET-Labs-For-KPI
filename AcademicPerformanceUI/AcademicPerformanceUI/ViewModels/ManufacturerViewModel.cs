using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class ManufacturerViewModel : BaseViewModel<Manufacturer>
    { 
        public ManufacturerViewModel()
        {
            LoadConnectedData();
        }
        
        public override void LoadConnectedData()
        {
            SelectedEntity = new Manufacturer();
        }
    }
}
