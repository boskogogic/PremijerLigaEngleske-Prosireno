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

namespace HCIProjekat2.IgracView
{
	/// <summary>
	/// Interaction logic for IgracIzmjeniHome.xaml
	/// </summary>
	public partial class IgracIzmijeniHome : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";
		static string klubNaziv;

		public IgracIzmijeniHome(string nazivKluba)
		{
			klubNaziv = nazivKluba;
			InitializeComponent();
			fillComboBoxKlub(klubNaziv);
		}


		public void fillComboBoxKlub(string klubNaziv)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.CommandText = "getPrezimeIgracaJednogKluba";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					cmd.Parameters.AddWithValue("@NazivKluba", klubNaziv);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;

					MySqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						string prezimeIgraca = dr.GetString(0);
						IgraciComboBox.Items.Add(prezimeIgraca);
					}

				}

			}
		}

		private void Pozicija_Click(object sender, RoutedEventArgs e)
		{
			string igracPrezime = IgraciComboBox.SelectedValue as string;
			Boolean isEmpty = String.IsNullOrEmpty(igracPrezime);
			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali igraca");
			}
			else
			{

				NavigationService.Navigate(new IgracIzmijeniPoziciju(klubNaziv, igracPrezime));
			}

		}

		private void BrojNaDresu_Click(object sender, RoutedEventArgs e)
		{
			string igracPrezime = IgraciComboBox.SelectedValue as string;
			Boolean isEmpty = String.IsNullOrEmpty(igracPrezime);
			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali igraca!");
			}
			else
			{
				NavigationService.Navigate(new IgracIzmijeniBrojNaDresu(klubNaziv, igracPrezime));
			}
		}


	}
}
