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
    public class MainWindowViewModel
    {
        private readonly Page GridView;
        private readonly Page SingleView;

        public Page CurrentPage { get; set; }

        public Image SelectedImage { get; set; }

        public static ObservableCollection<Image> Images;

        public static void ChangePage(object source)
        {
           ;
        }

        public MainWindowViewModel()
        {
            Images = Image.GetImagesFromFolder();

            GridView = new Views.GridImagesView();
            SingleView = new Views.SingleImagesView();


            CurrentPage = GridView;
        }
    }
}
