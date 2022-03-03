using HVKClassLibary.Shared;
using HVKDesktopUI.Commands;
using HVKDesktopUI.Stores;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HVKDesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ICommand NavigateToServerCommand { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ApiHelper.InitializeClient();

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new LayoutViewModel(new NavigationBarViewModel(navigationStore), () => new HomeViewModel(navigationStore));

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void ListViewItemClicked(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var content = item.Content as ServerViewModel;
                if (content != null)
                {
                    content.NavigateToServerCommand.Execute(this);
                }
            }
        }
    }
}
