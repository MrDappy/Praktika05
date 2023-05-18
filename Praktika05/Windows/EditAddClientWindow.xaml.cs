using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditAddClientWindow.xaml
    /// </summary>
    public partial class EditAddClientWindow : Window
    {

        private DB_HotelEntities2 _context;
        private Clients _Clients;
        private AddClientWindow _clientsWindow;

        public EditAddClientWindow(DB_HotelEntities2 context, object o, AddClientWindow clientsWindow)
        {
            InitializeComponent();
            _Clients = (o as Button).DataContext as Clients;
            _context = context;
            _clientsWindow = clientsWindow;

            TxtFioClient.Text = _Clients.FIO;
            TxtPolClient.Text = _Clients.Pol;
            TxtDataRojd.Text = _Clients.Data_rojdenia;
            TxtSeriaPasport.Text = _Clients.Seria_pasporta;
            TxtNumPasport.Text = _Clients.Number_pasprota;
            TxtAddress.Text = _Clients.Address;
            TxtNumTelephone.Text = _Clients.Telephone;


        }

        private void BtnDelHotel1_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Convert.ToString(_Clients.FIO), "Хотите удалить бронирование?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                _context.Clients.Remove(_Clients);
                _context.SaveChanges();

                _clientsWindow.RefreshClients();
                this.Close();
            }
        }

        private void BtnUpdateHotelInfo1_Click(object sender, RoutedEventArgs e)
        {
            _Clients.FIO = TxtFioClient.Text;
            _Clients.Pol = TxtPolClient.Text;
            _Clients.Data_rojdenia = TxtDataRojd.Text;
            _Clients.Seria_pasporta = TxtSeriaPasport.Text;
            _Clients.Number_pasprota = TxtNumPasport.Text;
            _Clients.Address = TxtAddress.Text;
            _Clients.Telephone = TxtNumTelephone.Text;

            _clientsWindow.RefreshClients();
            _context.SaveChanges();
            this.Close();
        }
    }
}
