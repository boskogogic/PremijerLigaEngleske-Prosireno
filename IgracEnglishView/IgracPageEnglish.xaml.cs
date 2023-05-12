using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCIProjekat2.IgracEnglishView
{
	/// <summary>
	/// Interaction logic for IgracPageEnglish.xaml
	/// </summary>
	public partial class IgracPageEnglish : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public IgracPageEnglish()
		{
			InitializeComponent();
			fillComboBoxKlub();

			//string nazivKluba = KlubComboBox.SelectedValue as string;
		}

		public void fillComboBoxKlub()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("select * from KLUB"))
				{
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						string nazivKluba = dr.GetString(4);
						KlubComboBox.Items.Add(nazivKluba);
					}

				}

			}
		}

		private void Potvrdi_Click(object sender, RoutedEventArgs e)
		{
			string klubNaziv = KlubComboBox.SelectedValue as string;
			Boolean isEmpty = String.IsNullOrEmpty(klubNaziv);
			if (isEmpty)
			{
				MessageBox.Show("You didn't choose a club");
			}
			else
			{
				NavigationService.Navigate(new IgracPrikazEnglish(klubNaziv));
			}

		}


	}
}
