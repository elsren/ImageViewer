using EventBinding.MVVM;
using ImageView.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageView.ViewModels
{
    public class SingleImageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region PropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;
        public new void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Fields

        public DelegateCommand ClickCommand { get; set; }

        public DelegateCommand KeyUpCommand { get; set; }

        public BitmapSource ImageBitmap
        {
            get
            {
                return BitmapConversion.ImagePathToBitmapSource(MainWindowViewModel.Images[MainWindowViewModel.SelectedImagIndex].ImagePath);
            }
        }

        #endregion

        private void PrevImage()
        {
            MainWindowViewModel.SelectedImagIndex--;
            OnPropertyChanged("ImageBitmap");
        }

        private void NextImage()
        {
            MainWindowViewModel.SelectedImagIndex++;
            OnPropertyChanged("ImageBitmap");
        }

        #region Events

        private void OnClick(object args)
        {
            if (args is RoutedEventArgs routedEventArgs)
            {
                if (((Button)routedEventArgs.Source).Name == "PrevBtn")
                {
                    PrevImage();
                }
                else if (((Button)routedEventArgs.Source).Name == "NextBtn")
                {
                    NextImage();
                }
            }
        }

        private void OnKeyUp(object obj)
        {
            if(obj is KeyEventArgs keyEventArgs)
            {
                switch(keyEventArgs.Key)
                {
                    case Key.Escape:
                        {
                            MainWindowViewModel.GoToGridView();
                            break;
                        }
                    case Key.Up:
                        {
                            PrevImage();
                            break;
                        }
                    case Key.Down:
                        {
                            NextImage();
                            break;
                        }
                }
            }
        }

        #endregion

        public SingleImageViewModel()
        {
            ClickCommand = CreateCommand(OnClick);
            KeyUpCommand = CreateCommand(OnKeyUp);
        }

    }
}
