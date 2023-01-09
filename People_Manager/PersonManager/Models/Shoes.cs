using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Zadatak.Utils;

namespace Zadatak.Models
{
    public class Shoes
    {
        public int IDShoes { get; set; }
        public string Brand { get; set; }
        public int Size { get; set; }
        public byte[] ShoesPicture { get; set; }
        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(ShoesPicture);
        }
        public int PersonID { get; set; }
    }
}
