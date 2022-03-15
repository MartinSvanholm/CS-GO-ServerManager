using HVKClassLibary.Models;
using HVKDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKDesktopUI.Commands.ServerCommands
{
    public abstract class ServerCommandBase : CommandBase
    {
        public readonly ServerViewModel serverViewModel;

        protected ServerCommandBase(ServerViewModel serverViewModel)
        {
            this.serverViewModel = serverViewModel;

            serverViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            if (serverViewModel.ServerStatus == "Online")
                return true && base.CanExecute(parameter);
            else
                return false && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(serverViewModel.ServerStatus))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
