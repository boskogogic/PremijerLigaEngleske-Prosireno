using HCIProjekat2.DAO;
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

namespace HCIProjekat2.UtakmicaEnglishView
{
	/// <summary>
	/// Interaction logic for UtakmicaPageEnglish.xaml
	/// </summary>
	public partial class UtakmicaPageEnglish : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public UtakmicaPageEnglish()
		{
			InitializeComponent();
			fillComboBoxKolo();
		}
		public void fillComboBoxKolo()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				//NAPOMENA -> distinct ide NAKON select naredbe.
				using (var cmd = new MySqlCommand("select distinct RedniBroj from KOLO "))
				{
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						string brojKola = dr.GetString(0);
						KoloComboBox.Items.Add(brojKola);
					}

				}

			}
		}

		private void Potvrdi_Click(object sender, RoutedEventArgs e)
		{
			int zadnjeKolo = KoloDAO.getLastKoloBroj();


			string koloComboBox = KoloComboBox.SelectedValue as string;

			Boolean isEmpty = String.IsNullOrEmpty(koloComboBox);
			if (isEmpty)
			{
				MessageBox.Show("Niste odabrali zeljeni klub");
			}
			else
			{
				int brojKola = Int32.Parse(koloComboBox);
				//MessageBox.Show("Broj kola je : " + brojKola);
				if (zadnjeKolo == brojKola)
				{
					NavigationService.Navigate(new UtakmicaIzmijeniEnglish(brojKola));
				}
				else
				{
					NavigationService.Navigate(new UtakmicaZavrsenaEnglish(brojKola));
				}
			}

		}
	}
}

