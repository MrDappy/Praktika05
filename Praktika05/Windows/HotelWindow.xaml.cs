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
using System.Windows.Shapes;

namespace Praktika05.Windows
{
    /// <summary>
    /// Логика взаимодействия для HotelWindow.xaml
    /// </summary> 
    public partial class HotelWindow : Window
    {

        public static DB_HotelEntities2 _context = new DB_HotelEntities2();

        private Bron_num_hotel _hotel;
        private int _currentPage = 1;
        private int _maxPage = 0;

        public HotelWindow()
        {
            InitializeComponent();

            RefreshHotels();
        }

        public void RefreshHotels()
        {
            DataGridHotels.ItemsSource = _context.Bron_num_hotel.OrderBy(h => h.client).ToList();
            _maxPage = Convert.ToInt32(Math.Ceiling(_context.Bron_num_hotel.ToList().Count * 1.0/ 10));

            var listBronHotels = _context.Bron_num_hotel.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            LbTotalPages.Content = "of " + _maxPage.ToString();
            TxtCurrentPageButton.Text = _currentPage.ToString();
            DataGridHotels.ItemsSource = listBronHotels;
        }


        private void BtnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            EditHotelInfoWindow editHotelInfoWindow =  new EditHotelInfoWindow(_context, sender, this);
            editHotelInfoWindow.ShowDialog();
        }


        /// <summary>
        /// Переход к первой странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoFirtPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshHotels();
        }

        
        /// <summary>
        /// Переход к предыдущей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPrevPagButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage - 1 < 1)
            {
                return;
            }
            _currentPage = _currentPage - 1;
            RefreshHotels();
        }


        /// <summary>
        /// Изменение номера текущей страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCurrentPageButton_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_currentPage > 0 && _currentPage < _maxPage && TxtCurrentPageButton.Text != "")
            {
                _currentPage = Convert.ToInt32(TxtCurrentPageButton.Text);
                RefreshHotels() ;
            }
        }


        /// <summary>
        /// Переход к следующей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage + 1 > _maxPage)
            {
                return;
            }
            _currentPage = _currentPage + 1;
            RefreshHotels();
        }


        /// <summary>
        /// Переход к последней странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshHotels() ;
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            AddHotelWindow addHotelWindow = new AddHotelWindow(_context, this);
            addHotelWindow.ShowDialog();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddClient_Click_1(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
        }
    }
}
