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
using RealEstateGui.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstateGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ingatlanContext context = new ingatlanContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Sellers.Load();
            context.Categories.Load();
            context.Realestates.Load();
            lb_eladok.ItemsSource = (from e in context.Sellers select e).ToList();
        }

        private void lb_eladok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sp_jobb.DataContext = lb_eladok.SelectedItem;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Realestate> x = (from h in context.Realestates where h.SellerId == ((Seller)lb_eladok.SelectedItem).Id select h).ToList();
            lbl_hirdetesekSzama.Content = x.Count;

        }
    }
}
