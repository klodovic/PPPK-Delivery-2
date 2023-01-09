using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zadatak.ViewModels;

namespace Zadatak
{
    public class ShoesFramedPage : Page
    {
        public ShoesFramedPage(ShoesViewModel shoesViewModel)
        {
            ShoesViewModel = shoesViewModel;
        }
        public ShoesViewModel ShoesViewModel { get; }
        public Frame Frame { get; set; }
    }
}
