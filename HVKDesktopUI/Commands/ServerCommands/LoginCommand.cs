using HVKClassLibary.Models.Account;
using HVKClassLibary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HVKDesktopUI.Commands.ServerCommands
{
    public class LoginCommand : CommandBase
    {
        public async override void Execute(object parameter)
        {
            try
            {
                await AccountService.Login();
                MessageBox.Show("Du er logged ind");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }
    }
}
