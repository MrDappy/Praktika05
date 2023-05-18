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
    /// Логика взаимодействия для AddHotelWindow.xaml
    /// </summary>
    public partial class AddHotelWindow : Window
    {

        private DB_HotelEntities2 _context;
        private HotelWindow _hotelWindow;
        public AddHotelWindow(DB_HotelEntities2 dB_HotelEntities, HotelWindow hotelWindow)
        {
            InitializeComponent();
            this._context = dB_HotelEntities;
            this._hotelWindow = hotelWindow;
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            _context.Bron_num_hotel.Add(new Bron_num_hotel() 
            { 
                client = TxtIdCLient.Text,
                id_hotel_num = TxtIdHotel.Text,
                data_bron = TxtDateBron.Text,
                date_poselenia = TxtDatePoselen.Text,
                date_viezda = TxtDateViezd.Text
            });

            _context.SaveChanges();
            _hotelWindow.RefreshHotels();

            this.Close();
        }
    }
}