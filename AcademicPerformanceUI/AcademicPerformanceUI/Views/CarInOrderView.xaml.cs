using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for SubjectInGroup.xaml
    /// </summary>
    public partial class CarInOrderView : Page
    {
        private CarInOrderViewModel CarInOrderViewModel { get; set; }

        public CarInOrderView()
        {
            InitializeComponent();
            CarInOrderViewModel = new CarInOrderViewModel();
            DataContext = CarInOrderViewModel;
        }

        private void Add_CarInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CarInOrderViewModel.AddData();
        }

        private void Update_CarInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CarInOrderViewModel.UpdateData();
        }

        private void Remove_CarInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CarInOrderViewModel.RemoveData();
        }

        private void Save_CarInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CarInOrderViewModel.SaveEntity();
        }

        private void SaveAll__CarInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CarInOrderViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                CarInOrderViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
