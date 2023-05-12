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

namespace HCIProjekat2.KlubEnglishView
{
	/// <summary>
	/// Interaction logic for KlubDodajEnglish.xaml
	/// </summary>
	public partial class KlubDodajEnglish : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		const int brojStanovnikaEngleska = 5628696;
		const int brojStanovnikaVels = 3153000;


		public KlubDodajEnglish()
		{
			InitializeComponent();
			fillComboBoxDrzava();
		}

		public void fillComboBoxDrzava()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("select * from DRZAVA_UJEDINJENO_KRALJEVSTVO"))
				{
					//cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						string nazivDrzave = dr.GetString(1);
						DrzavaComboBox.Items.Add(nazivDrzave);
					}

				}

			}
		}

		/* Helper method for finding the last ID of table GRAD. */
		private int findLastIdGrad()
		{
			int IdValue;

			int lastId;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("getMaxIdGrad"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}
			int id = IdValue;
			lastId = id + 1;
			return lastId;
		}


		private int findLastIdStadion()
		{

			int IdValue;

			int lastId;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("getMaxIdStadion"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}

			int id = IdValue;
			lastId = id + 1;
			return lastId;
		}

		private int findLastIdKlub()
		{

			int IdValue;

			int lastId;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("getMaxIdStadion"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}

			int id = IdValue;
			lastId = id + 1;
			return lastId;
		}

		/*private int findLastIdGrad()
		{
			int IdValue;

			int lastId;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("getMaxIdGrad"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}
			int id = IdValue;
			lastId = id + 1;
			return lastId;
		}*/


		private void Button_Nazad(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new KlubPageEnglish());
		}

		//public static void dodajKlub(int idKluba, int idStadiona, int idGrada, int idDrzave, 
		//string nazivKluba, string adresaKluba, string nazivStadiona, string nazivGrada, int brojStanovnika, 
		//string nazivDrzave)

		private void Button_Dodaj(object sender, RoutedEventArgs e)
		{
			string drzavaNaziv = DrzavaComboBox.SelectedValue as string;
			int brojStanovnikaGrada = int.Parse(BrojStanovnikaTextBox.Text);
			int IdDrzave;

			if ("Engleska".Equals(drzavaNaziv))
			{
				IdDrzave = 1;

			}
			else
			{
				IdDrzave = 2;
			}

			KlubDAO.dodajKlub(NazivKlubaTextBox.Text, AdresaKlubaTextBox.Text, NazivStadionaTextBox.Text, NazivGradaTextBox.Text, brojStanovnikaGrada, IdDrzave);
			MessageBox.Show("Dodali ste klub!" + " " + NazivKlubaTextBox.Text + " " + drzavaNaziv);
			NavigationService.Navigate(new KlubPageEnglish());
		}


	}
}
