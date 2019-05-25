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
            SelectedEntity = new Manufacturer();
            LoadConnectedData();
        }
        
        public override void LoadConnectedData()
        {
        }
    }
}
