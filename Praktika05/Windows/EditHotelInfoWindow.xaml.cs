using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для EditHotelInfoWindow.xaml
    /// </summary>
    public partial class EditHotelInfoWindow : Window
    {

        private DB_HotelEntities2 _context;
        private Bron_num_hotel _bronHotel;
        private HotelWindow _hotelWindow;

        public EditHotelInfoWindow(DB_HotelEntities2 context, object o, HotelWindow hotelWindow)
        {
            InitializeComponent();
            _bronHotel = (o as Button).DataContext as Bron_num_hotel;
            _context = context;
            _hotelWindow = hotelWindow;

            TxtIdHotel.Text = Convert.ToString(_bronHotel.id_hotel_num);
            TxtIdCLient.Text = Convert.ToString(_bronHotel.client);
            TxtDateBron.Text = _bronHotel.data_bron;
            TxtDatePoselen.Text = _bronHotel.date_poselenia;
            TxtDateViezd.Text = _bronHotel.date_viezda;

        }

        private void BtnDelHotel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Convert.ToString(_bronHotel.client), "Хотите удалить бронирование?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                _context.Bron_num_hotel.Remove(_bronHotel);
                _context.SaveChanges();

                _hotelWindow.RefreshHotels();
                this.Close();
            }
        }

        private void BtnUpdateHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            _bronHotel.client = TxtIdCLient.Text;
            _bronHotel.id_hotel_num = TxtIdHotel.Text;
            _bronHotel.data_bron = TxtDateBron.Text;
            _bronHotel.date_poselenia = TxtDatePoselen.Text;
            _bronHotel.date_viezda = TxtDateViezd.Text;

            _hotelWindow.RefreshHotels();
            _context.SaveChanges();
            this.Close();
        }
    }
}
