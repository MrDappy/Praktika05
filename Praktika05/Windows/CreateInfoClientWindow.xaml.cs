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
    /// Логика взаимодействия для CreateInfoClientWindow.xaml
    /// </summary>
    public partial class CreateInfoClientWindow : Window
    {
        private DB_HotelEntities2 _context;
        private AddClientWindow _clientsWindow;

        public CreateInfoClientWindow(DB_HotelEntities2 dB_HotelEntities, AddClientWindow clientsWindow)
        {
            InitializeComponent();
            this._context = dB_HotelEntities;
            this._clientsWindow = clientsWindow;
        }

        private void BtnAddClientInfo_Click(object sender, RoutedEventArgs e)
        {
            _context.Clients.Add(new Clients()
            {
                FIO = TxtFioClient.Text,
                Pol = TxtPolClient.Text,
                Data_rojdenia = TxtDataRojd.Text,
                Seria_pasporta = TxtSeriaPasport.Text,
                Number_pasprota = TxtNumPasport.Text,
                Address = TxtAddress.Text,
                Telephone = TxtNumTelephone.Text
            });

            _context.SaveChanges();
            _clientsWindow.RefreshClients();

            this.Close();
        }
    }
}
