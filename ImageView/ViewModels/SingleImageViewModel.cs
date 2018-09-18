using EventBinding.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ImageView.ViewModels
{
    public class SingleImageViewModel : ViewModelBase
    {
        public DelegateCommand ClickCommand { get; set; }

        public string ImagePath { get { return MainWindowViewModel.Images[MainWindowViewModel.SelectedImagIndex].ImagePath; } }

        private void OnClick(object args)
        {
            if(args is RoutedEventArgs routedEventArgs)
            {
                if(((Button)routedEventArgs.Source).Name == "PrevBtn")
                {
                    MainWindowViewModel.SelectedImagIndex--;
                }
                else if(((Button)routedEventArgs.Source).Name == "NextBtn")
                {
                    MainWindowViewModel.SelectedImagIndex++;
                }
            }
        }

        public SingleImageViewModel()
        {
            ClickCommand = CreateCommand(OnClick);
        }
    }
}
