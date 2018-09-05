using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageView
{
    public class Image
    {
        public string ImagePath { get; set; }

        public Image(string path)
        {
            ImagePath = path;
        }

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
                        result.Add(new Image(folderFiles[i]));
                    }
                }
            }

            return result;
        }

    }
}
