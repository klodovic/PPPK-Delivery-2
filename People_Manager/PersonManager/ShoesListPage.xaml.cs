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
using Zadatak.ViewModels;

namespace Zadatak
{
    /// <summary>
    /// Interaction logic for ShoesListPage.xaml
    /// </summary>
    public partial class ShoesListPage : ShoesFramedPage
    {


        public ShoesListPage(ShoesViewModel shoesViewModel) : base(shoesViewModel)
        {
            InitializeComponent();
            LvShoes.ItemsSource = shoesViewModel.ShoeCollection;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) 
            => Frame.Navigate(new EditShoesPage(ShoesViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvShoes.SelectedItem != null)
            {
                //Frame.Navigate(new EditPersonPage(PersonViewModel, LvPeople.SelectedItem as Person) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvShoes.SelectedItem != null)
            {
                //PersonViewModel.People.Remove(LvPeople.SelectedItem as Person);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();
    }
}
