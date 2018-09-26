using ImageView.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageView
{
    public class Image
    {
        #region Fields

        public string ImagePath { get; set; }
        public BitmapSource ImageBitmap { get; set; }

        #endregion

        public Image() { }

        public Image(string path, BitmapSource source)
        {
            ImagePath = path;
            ImageBitmap = source;
        }

        #region Public methods

        public static ObservableCollection<Image> GetImagesFromFolder()
        {
            var result = new ObservableCollection<Image>();

            string photoDir = Directory.GetCurrentDirectory() + @"\Photos";

            if (Directory.Exists(photoDir))
            {
                var folderFiles = Directory.GetFiles(photoDir);

                for(int i = 0;i<folderFiles.Length;i++)
                {
                    string extension = Path.GetExtension(folderFiles[i]).ToLower();
                    if (Helper.SuitableExtention(folderFiles[i]))
                    {
                        result.Add(new Image(folderFiles[i], BitmapConversion.ImagePathToBitmapSource(folderFiles[i])));
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
