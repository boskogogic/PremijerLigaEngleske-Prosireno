using HCIProjekat2.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HCIProjekat2.UtakmicaView
{
    /// <summary>
    /// Interaction logic for UtakmicaZavrsena.xaml
    /// </summary>
    public partial class UtakmicaZavrsena : Page
    {
		static int koloBroj;
		static string[] domacinKlub = new string[10];
		static string[] gostKlub = new string[10];
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";



		public UtakmicaZavrsena(int brojKola)
        {
			koloBroj = brojKola;
			InitializeComponent();
			fillComboBox();
			BrojKola.Content = brojKola;
			
        }

		public void fillComboBox()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.CommandText = "getUtakmiceKolo";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@brojKola", koloBroj);
					cmd.Parameters["@brojKola"].Direction = ParameterDirection.Input;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					int brojac = 0;
					while (dr.Read())
					{
						string klubDomacin = dr.GetString(0);
						string klubGost = dr.GetString(1);
						string karakter = "-";
						domacinKlub[brojac] = klubDomacin;
						gostKlub[brojac] = klubGost;
						string item = klubDomacin + karakter + klubGost;
						UtakmicaComboBox.Items.Add(item);
						brojac++;
					}

				}

			}
		}

		private void Postave_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';

			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali zeljenu utakmicu");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaPostave(klubovi[0], klubovi[1], koloBroj));
			}
		}

		private void Detalji_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';
			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali zeljenu utakmicu");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaDetalji(klubovi[0], klubovi[1], koloBroj));
			}

		}

		private void Rezultat_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';
			// PROVJERENO -> Vrati dobro kolo -> Kolo 2!
			//MessageBox.Show("Broj kola unutar klase Utakmica zavrsena je : " + koloBroj);
			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali zeljenu utakmicu");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaRezultat(klubovi[0], klubovi[1], koloBroj));
			}
		}

		private void Nazad_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new UtakmicaPage());
		}
	}
}
