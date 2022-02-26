using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKDesktopUI.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, Func<ViewModelBase> createViewModel)
        {
            ContentViewModel = createViewModel();
            NavigationBarViewModel = navigationBarViewModel;
        }

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public ViewModelBase ContentViewModel { get; set; }
    }
}
