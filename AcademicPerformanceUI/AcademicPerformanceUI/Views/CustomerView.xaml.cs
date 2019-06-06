using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        private CustomerViewModel CustomerViewModel { get; set; }

        public CustomerView()
        {
            InitializeComponent();
            CustomerViewModel = new CustomerViewModel();
            DataContext = CustomerViewModel;
        }

        private void Add_Customer_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerViewModel.AddData();
        }

        private void Update_Customer_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerViewModel.UpdateData();
        }

        private void Remove_Customer_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerViewModel.RemoveData();
        }

        private void Save_Customer_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerViewModel.SaveEntity();
        }

        private void SaveAll__Customer_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                CustomerViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
