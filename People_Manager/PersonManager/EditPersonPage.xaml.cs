using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Zadatak.Models;
using Zadatak.Utils;
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Person person;
        private ShoesViewModel shoesViewModel;

        public EditPersonPage(PersonViewModel personViewModel, Person person = null) : base(personViewModel)
        {
            InitializeComponent();
            if (person == null)
            {
                shoesViewModel = new ShoesViewModel(0);
            }
            else
            {
                shoesViewModel = new ShoesViewModel(person.IDPerson);
            }
            
            this.person = person ?? new Person();
            DataContext = person;
            LvShoes.ItemsSource = shoesViewModel.ShoeCollection;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                person.Age = int.Parse(TbAge.Text.Trim());
                person.Email = TbEmail.Text.Trim();
                person.FirstName = TbFirstName.Text.Trim();
                person.LastName = TbLastName.Text.Trim();
                person.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                if (person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(person);
                }
                else
                {
                    PersonViewModel.Update(person);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()) 
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(TbEmail.Text.Trim())))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                } else
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


        private void BtnAdd_Click(object sender, RoutedEventArgs e) 
            => Frame.Navigate(new EditShoesPage(shoesViewModel) { Frame = Frame });



        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvShoes.SelectedItem != null)
            {
                Frame.Navigate(new EditShoesPage(shoesViewModel, LvShoes.SelectedItem as Shoes) { Frame = Frame });
            }
        }



        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvShoes.SelectedItem != null)
            {
                shoesViewModel.ShoeCollection.Remove(LvShoes.SelectedItem as Shoes);
            }
        }
    }
}
