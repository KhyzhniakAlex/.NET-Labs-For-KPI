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
    public partial class CustomerInOrderView : Page
    {
        private CustomerInOrderViewModel CustomerInOrderViewModel { get; set; }

        public CustomerInOrderView()
        {
            InitializeComponent();
            CustomerInOrderViewModel = new CustomerInOrderViewModel();
            DataContext = CustomerInOrderViewModel;
        }

        private void Add_CustomerInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerInOrderViewModel.AddData();
        }

        private void Update_CustomerInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerInOrderViewModel.UpdateData();
        }

        private void Remove_CustomerInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerInOrderViewModel.RemoveData();
        }

        private void Save_CustomerInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerInOrderViewModel.SaveEntity();
        }

        private void SaveAll__CustomerInOrder_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerInOrderViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                CustomerInOrderViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
