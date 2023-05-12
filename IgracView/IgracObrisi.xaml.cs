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

namespace HCIProjekat2.IgracView
{
	/// <summary>
	/// Interaction logic for IgracObrisi.xaml
	/// </summary>
	public partial class IgracObrisi : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";
		static string nazivKluba;

		public IgracObrisi(string klubNaziv)
		{
			nazivKluba = klubNaziv;
			InitializeComponent();
			fillComboBoxKlub(nazivKluba);
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

		private void Potvrdi_Click(object sender, RoutedEventArgs e)
		{

			string prezime = IgraciComboBox.SelectedValue as string;

			if (("").Equals(prezime))
			{
				MessageBox.Show("Niste odabrali igraca!");
			}
			else
			{
				IgracDAO.obrisiIgraca(prezime);
				NavigationService.Navigate(new IgracPrikaz(nazivKluba));
			}

		}
	}
}
