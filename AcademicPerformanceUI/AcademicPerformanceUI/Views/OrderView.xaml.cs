using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class OrderView : Page
    {
        private OrderViewModel OrderViewModel { get; set; }

        public OrderView()
        {
            InitializeComponent();
            OrderViewModel = new OrderViewModel();
            DataContext = OrderViewModel;
        }

        private void Add_Order_OnClick(object sender, RoutedEventArgs e)
        {
            OrderViewModel.AddData();
        }

        private void Update_Order_OnClick(object sender, RoutedEventArgs e)
        {
            OrderViewModel.UpdateData();
        }

        private void Remove_Order_OnClick(object sender, RoutedEventArgs e)
        {
            OrderViewModel.RemoveData();
        }

        private void Save_Order_OnClick(object sender, RoutedEventArgs e)
        {
            OrderViewModel.SaveEntity();
        }

        private void SaveAll__Order_OnClick(object sender, RoutedEventArgs e)
        {
            OrderViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                OrderViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
