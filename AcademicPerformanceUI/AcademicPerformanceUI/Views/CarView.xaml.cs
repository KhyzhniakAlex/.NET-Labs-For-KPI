using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for SubjectView.xaml
    /// </summary>
    public partial class CarView : Page
    {
        private CarViewModel CarViewModel { get; set; }

        public CarView()
        {
            InitializeComponent();
            CarViewModel = new CarViewModel();
            DataContext = CarViewModel;
        }

        private void Add_Car_OnClick(object sender, RoutedEventArgs e)
        {
            CarViewModel.AddData();
        }

        private void Update_Car_OnClick(object sender, RoutedEventArgs e)
        {
            CarViewModel.UpdateData();
        }

        private void Remove_Car_OnClick(object sender, RoutedEventArgs e)
        {
            CarViewModel.RemoveData();
        }

        private void Save_Car_OnClick(object sender, RoutedEventArgs e)
        {
            CarViewModel.SaveEntity();
        }

        private void SaveAll__Car_OnClick(object sender, RoutedEventArgs e)
        {
            CarViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                CarViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
