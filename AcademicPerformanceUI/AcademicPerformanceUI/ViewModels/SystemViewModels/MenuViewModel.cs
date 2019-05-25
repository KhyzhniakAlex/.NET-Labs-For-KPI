using System;
using System.Collections.ObjectModel;
using System.Linq;
using MahApps.Metro.IconPacks;

namespace AcademicPerformanceUI.ViewModels
{ 

    public class MenuViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public MenuViewModel()
        {
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserFriendsSolid }, Text = "Orders", NavigationDestination = new Uri("Views/OrderView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid }, Text = "Customers", NavigationDestination = new Uri("Views/CustomerView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CoffeeSolid }, Text = "Cars", NavigationDestination = new Uri("Views/CarView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSlashSolid }, Text = "Managers", NavigationDestination = new Uri("Views/ManagerView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.MarkerSolid }, Text = "Manufacturers", NavigationDestination = new Uri("Views/ManufacturerView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.AngrySolid }, Text = "CustomerInOrder", NavigationDestination = new Uri("Views/CustomerInOrder.xaml", UriKind.RelativeOrAbsolute) });

            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid }, Text = "Settings", NavigationDestination = new Uri("Views/SettingsView.xaml", UriKind.RelativeOrAbsolute) });
        }

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

        public object GetItem(object uri)
        {
            return null == uri ? null : this.Menu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }

        public object GetOptionsItem(object uri)
        {
            return null == uri ? null : this.OptionsMenu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }
    }
}
