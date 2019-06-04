using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class ManufacturerView : Page
    {
        private ManufacturerViewModel ManufacturerViewModel { get; set; }

        public ManufacturerView()
        {
            InitializeComponent();
            ManufacturerViewModel = new ManufacturerViewModel();
            DataContext = ManufacturerViewModel;
        }

        private void Add_Manufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            ManufacturerViewModel.AddData();
        }

        private void Update_Manufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            ManufacturerViewModel.UpdateData();
        }

        private void Remove_Manufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            ManufacturerViewModel.RemoveData();
        }

        private void Save_Manufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            ManufacturerViewModel.SaveEntity();
        }

        private void SaveAll__Manufacturer_OnClick(object sender, RoutedEventArgs e)
        {
            ManufacturerViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                ManufacturerViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
