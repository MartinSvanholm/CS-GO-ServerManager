using HVKClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace HVKDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ServerList.xaml
    /// </summary>
    public partial class ServerList : UserControl
    {
        private Server _server;

        public ServerList(Server server)
        {
            _server = server;
        }

        public ICommand NavigateToServerCommand { get; }

        public ServerList()
        {
            InitializeComponent();
        }
    }
}
