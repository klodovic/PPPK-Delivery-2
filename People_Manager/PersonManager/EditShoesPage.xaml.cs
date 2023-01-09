using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zadatak.Models;
using Zadatak.Utils;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for EditShoesPage.xaml
    /// </summary>
    public partial class EditShoesPage : ShoesFramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Shoes shoes;

        public EditShoesPage(ShoesViewModel shoesViewModel, Shoes shoes = null) : base(shoesViewModel)  
        {
            InitializeComponent();
            this.shoes = shoes ?? new Shoes();
            DataContext = shoes;
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e) {
            if (FormValid())
            {
                shoes.Brand = TbBrend.Text.Trim();
                shoes.Size = int.Parse(TbSize.Text.Trim());
                shoes.ShoesPicture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                shoes.PersonID = ShoesViewModel.PersonId;
                if (shoes.IDShoes == 0)
                {
                    ShoesViewModel.ShoeCollection.Add(shoes);
                }
                else
                {
                    ShoesViewModel.Update(shoes);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            AddNewShoes.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int size)))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.WhiteSmoke;
            }
            return valid;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

    }
}
