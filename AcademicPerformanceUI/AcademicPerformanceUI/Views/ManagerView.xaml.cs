using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class ManagerView : Page
    {
        private ManagerViewModel ManagerViewModel { get; set; }

        public ManagerView()
        {
            InitializeComponent();
            ManagerViewModel = new ManagerViewModel();
            DataContext = ManagerViewModel;
        }

        private void Add_Manager_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerViewModel.AddData();
        }

        private void Update_Manager_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerViewModel.UpdateData();
        }

        private void Remove_Manager_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerViewModel.RemoveData();
        }

        private void Save_Manager_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerViewModel.SaveEntity();
        }

        private void SaveAll__Manager_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                ManagerViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
