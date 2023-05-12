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
using HCIProjekat2.DAO;


namespace HCIProjekat2.KlubView
{
	/// <summary>
	/// Interaction logic for Klub.xaml
	/// </summary>
	public partial class KlubPage : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public KlubPage()
		{
			InitializeComponent();

			try
			{
				klubInfoDataGrid.ItemsSource = KlubDAO.getKluboviDataTable().DefaultView;
			}
			catch (Exception e)
			{
				MessageBox.Show("Greska prilikom pokusaja prikaza klubova! \n" + e.Message);
			}



		}


		/* Maybe i will need this part of code for some other implementations.
		 * 
		 * private DataTable GetKlubInfo()
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			MySqlCommand cmd = new MySqlCommand("select Naziv,Adresa from KLUB", connection);
			connection.Open();
			DataTable dt = new DataTable();
			dt.Load(cmd.ExecuteReader());
			connection.Close();
			return dt;
		}
		*/



		private void Button_DodatneInformacije(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new KlubDodatneInformacijePage());

		}

		private void Dodaj_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new KlubDodaj());
		}
	}
}
