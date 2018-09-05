using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageView
{
    class Helper
    {
        public static bool SuitableExtention(string path)
        {
            string extension = Path.GetExtension(path.ToLower());
            if (extension.Equals(".jpeg") || extension.Equals(".jpg") || extension.Equals(".rgb")
                || extension.Equals(".ico") || extension.Equals(".png"))
            {
                return true;
            }
            return false;
        }
    }
}
