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

namespace Praktika05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DB_HotelEntities2 _context = new DB_HotelEntities2();

        private List<Nums_hotel> _classes_comfort = new List<Nums_hotel>();
        /// <summary>
        /// private string _SelectedType;
        /// </summary>
        private string _FindedName;
        public MainWindow()
        {
            InitializeComponent();
            ListHotelClass.ItemsSource = _context.Nums_hotel.OrderBy(Classes_comfort => Classes_comfort.class_comfort).ToList();

            List<Nums_hotel> types = new List<Nums_hotel>();
            types.Add(new Nums_hotel() { class_comfort = "Все классы комфорта" });
            types.AddRange(_context.Nums_hotel.OrderBy(t => t.class_comfort).ToList());

            this._classes_comfort = _context.Nums_hotel.ToList();
        }
        
        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChbHZ_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TxtFindedHotelClassName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _FindedName = TxtFindedHotelClassName.Text;

            _classes_comfort = _context.Nums_hotel.OrderBy(t => t.class_comfort).ToList();

            if (TxtFindedHotelClassName.Text != "")
            {
                _classes_comfort = _classes_comfort.OrderBy(t => t.class_comfort).Where(t => t.class_comfort.ToLower().Contains(_FindedName)).ToList();
            }
            else
            {
                _classes_comfort = _context.Nums_hotel.ToList();
            }
            ListHotelClass.ItemsSource = _classes_comfort;
        }

        private void CmbType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ChbHZ_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void ChbHZ_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShowHotelWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.HotelWindow window = new Windows.HotelWindow();
            window.ShowDialog();
        }
    }
}
