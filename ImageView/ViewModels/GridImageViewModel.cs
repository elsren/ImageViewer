﻿using EventBinding.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImageView.ViewModels
{
    public class GridImageViewModel : ViewModelBase
    {
        public DelegateCommand DropCommand { get; set; }
        public DelegateCommand MouseDoubleClickCommand { get; set; }

        public ObservableCollection<Image> Images
        {
            get
            {
                return MainWindowViewModel.Images;
            }
            set { }
        }

        private void OnDrop(object args)
        {
            if (args is DragEventArgs dragEventArgs)
            {
                string[] data = (string[])dragEventArgs.Data.GetData(DataFormats.FileDrop);

                for (int i = 0; i < data.Length; i++)
                {
                    if (Helper.SuitableExtention(data[i]))
                    {
                        Images.Add(new Image(data[i]));
                    }
                }
            }
        }

        private void OnDoubleClick(object args)
        {
            if(args is MouseButtonEventArgs mouseButtonEventArgs)
            {
                MainWindowViewModel.ChangePage(mouseButtonEventArgs);
            }
        }

        public GridImageViewModel()
        {
            DropCommand = CreateCommand(OnDrop);
            MouseDoubleClickCommand = CreateCommand(OnDoubleClick);
        }
    }
}