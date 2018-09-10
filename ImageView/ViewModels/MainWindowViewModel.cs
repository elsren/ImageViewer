﻿using EventBinding.MVVM;
using ImageView.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ImageView.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constants

        public static readonly string GridImageViewModelAlias = "GridVM";
        public static readonly string SingleImageViewModelAlias = "SingleVM";

        #endregion

        #region Fields

        public static ObservableCollection<Image> Images;

        #endregion

        public MainWindowViewModel()
        {
            Images = Image.GetImagesFromFolder();

            GoToGridView();
        }

        public static void GoToGridView()
        {
           Navigation.Navigate(Navigation.GridViewAlias, 
               ViewModelsResolver.Instance.GetViewModelInstance(GridImageViewModelAlias));
        }

        public static void GoToSingleImageView()
        {
            Navigation.Navigate(Navigation.SingleViewAlias, 
                ViewModelsResolver.Instance.GetViewModelInstance(SingleImageViewModelAlias));
        }

    }
}
