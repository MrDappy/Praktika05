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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {

        public static DB_HotelEntities2 _context = new DB_HotelEntities2();

        private Clients _Clients;
        private int _currentPage = 1;
        private int _maxPage = 0;

        public AddClientWindow()
        {
            InitializeComponent();
            
            RefreshClients();
        }


        public void RefreshClients()
        {
            DataGridClients.ItemsSource = _context.Clients.OrderBy(h => h.FIO).ToList();
            _maxPage = Convert.ToInt32(Math.Ceiling(_context.Clients.ToList().Count * 1.0 / 10));

            var listClients = _context.Clients.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            LbTotalPages1.Content = "of " + _maxPage.ToString();
            TxtCurrentPageButton1.Text = _currentPage.ToString();
            DataGridClients.ItemsSource = listClients;
        }


        private void GoLastPageButton1_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshClients();
        }

        private void GoNextPageButton1_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage + 1 > _maxPage)
            {
                return;
            }
            _currentPage = _currentPage + 1;
            RefreshClients();
        }

        private void TxtCurrentPageButton1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_currentPage > 0 && _currentPage < _maxPage && TxtCurrentPageButton1.Text != "")
            {
                _currentPage = Convert.ToInt32(TxtCurrentPageButton1.Text);
                RefreshClients();
            }
        }

        private void GoPrevPagButton1_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
            {
                return;
            }
            _currentPage = _currentPage - 1;
            RefreshClients();
        }

        private void GoFirtPageButton1_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshClients();
        }

        private void BtnAddClient1_Click(object sender, RoutedEventArgs e)
        {
            CreateInfoClientWindow createInfoClientWindow = new CreateInfoClientWindow(_context, this);
            createInfoClientWindow.ShowDialog();
        }

        private void BtnEditClientInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditClientInfo_Click_1(object sender, RoutedEventArgs e)
        {
            EditAddClientWindow editAddClientWindow = new EditAddClientWindow(_context, sender, this);
            editAddClientWindow.ShowDialog();
        }
    }
}
