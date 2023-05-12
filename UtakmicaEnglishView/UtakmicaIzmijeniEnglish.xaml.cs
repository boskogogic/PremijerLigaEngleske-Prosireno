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

namespace HCIProjekat2.UtakmicaEnglishView
{
	/// <summary>
	/// Interaction logic for UtakmicaIzmijeniEnglish.xaml
	/// </summary>
	public partial class UtakmicaIzmijeniEnglish : Page
	{
		static string[] domacinKlub = new string[10];
		static string[] gostKlub = new string[10];
		static int koloBroj;
		static int daLiJeKraj = 0;
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";


		public UtakmicaIzmijeniEnglish(int brojKola)
		{
			koloBroj = brojKola;
			InitializeComponent();
			fillComboBox(koloBroj);
			BrojKola.Content = fillBrojKolaLabel();
		}

		public void fillComboBox(int koloBroj)
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

		public string fillBrojKolaLabel()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.CommandText = "getLastKolo";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					int brojac = 0;
					dr.Read();
					string brojKola = dr.GetString(0);
					return brojKola;
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
				MessageBox.Show("You didn't chose a game");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaPostaveEnglish(klubovi[0], klubovi[1], koloBroj));
			}

		}

		private void Rezultat_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';

			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show("You didn't chose a game");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaRezultatEnglish(klubovi[0], klubovi[1], koloBroj));
			}

		}

		private void Detalji_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';

			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);


			if (isEmpty)
			{
				MessageBox.Show("You didn't chose a game");
			}
			else
			{
				string[] klubovi = opadajuciMeni.Split(character);
				NavigationService.Navigate(new UtakmicaDetaljiEnglish(klubovi[0], klubovi[1], koloBroj));
			}
		}

		private void PromjeniRezultat_Click(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = UtakmicaComboBox.SelectedValue as string;
			char character = '-';

			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show("You didn't chose a game");
			}
			else
			{
				if (daLiJeKraj == 0)
				{
					string[] klubovi = opadajuciMeni.Split(character);
					NavigationService.Navigate(new UtakmicaIzmijeniRezultatEnglish(klubovi[0], klubovi[1], koloBroj));

				}
				else
				{
					MessageBox.Show("Games are finished !");
				}
			}

		}

		private void Kraj_Click(object sender, RoutedEventArgs e)
		{

			daLiJeKraj = 1;
			MessageBox.Show("Games are finished!");
			PromjeniRezultat.IsEnabled = false;
			int IdKlubDomaci = 0;
			int IdKlubGostujuci = 0;
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

						IdKlubDomaci = IgracDAO.findKlubId(klubDomacin);
						IdKlubGostujuci = IgracDAO.findKlubId(klubGost);

						domacinKlub[brojac] = klubDomacin;
						gostKlub[brojac] = klubGost;
						var conn2 = new MySqlConnection(connectionString);
						conn2.Open();
						using (var cmd2 = new MySqlCommand())
						{

							cmd2.CommandText = "getUtakmicaIdBrojKola";
							cmd2.CommandType = CommandType.StoredProcedure;
							cmd2.Parameters.AddWithValue("@IdKlubDomaci", IdKlubDomaci);
							cmd2.Parameters["@IdKlubDomaci"].Direction = ParameterDirection.Input;
							cmd2.Parameters.AddWithValue("@IdKlubGostujuci", IdKlubGostujuci);
							cmd2.Parameters["@IdKlubGostujuci"].Direction = ParameterDirection.Input;
							cmd2.Parameters.AddWithValue("@brojKola", koloBroj);
							cmd2.Parameters["@brojKola"].Direction = ParameterDirection.Input;
							cmd2.Connection = conn2;
							MySqlDataReader dr2 = cmd2.ExecuteReader();
							dr2.Read();
							int IdUtakmice = dr2.GetInt32(0);
							//MessageBox.Show("Id Utakmice je : " + IdUtakmice);
							// PROVJERENO -> Daje dobar ID Utakmice
							var conn6 = new MySqlConnection(connectionString);
							conn6.Open();
							var cmd7 = new MySqlCommand();
							cmd7.CommandText = "zavrsiUtakmicu";
							cmd7.CommandType = CommandType.StoredProcedure;
							cmd7.Parameters.AddWithValue("@IdUtakmica", IdUtakmice);
							cmd7.Parameters["@IdUtakmica"].Direction = ParameterDirection.Input;
							cmd7.Connection = conn6;
							cmd7.ExecuteNonQuery();

							var conn3 = new MySqlConnection(connectionString);
							conn3.Open();
							using (var cmd3 = new MySqlCommand())
							{


								cmd3.CommandText = "getGoloviUtakmica";
								cmd3.CommandType = CommandType.StoredProcedure;
								cmd3.Parameters.AddWithValue("@IdUtakmica", IdUtakmice);
								cmd3.Parameters["@IdUtakmica"].Direction = ParameterDirection.Input;
								cmd3.Connection = conn3;
								MySqlDataReader dr3 = cmd3.ExecuteReader();
								dr3.Read();

								int goloviDomaci = dr3.GetInt32(0);
								int goloviGostujuci = dr3.GetInt32(1);

								//MessageBox.Show("Broj Golova domaci: " + goloviDomaci + " Gostujuci : " + goloviGostujuci);
								//PROVJERENO -> RADI DOBRO !
								//MessageBox.Show("Id Kluba domaceg je : " + IdKlubDomaci + " Gostujuceg : " + IdKlubGostujuci);
								var conn4 = new MySqlConnection(connectionString);
								conn4.Open();
								var cmd4 = new MySqlCommand();
								var cmd5 = new MySqlCommand();
								var cmd6 = new MySqlCommand();

								if (goloviDomaci > goloviGostujuci)
								{
									//MessageBox.Show("Usao u PRVI IF");
									cmd4.CommandText = "dodajTriBoda";
									cmd4.CommandType = CommandType.StoredProcedure;
									cmd4.Parameters.AddWithValue("@IdKluba", IdKlubDomaci);
									cmd4.Parameters["@IdKluba"].Direction = ParameterDirection.Input;
									cmd4.Connection = conn4;
									cmd4.ExecuteNonQuery();

								}
								else if (goloviDomaci < goloviGostujuci)
								{
									//MessageBox.Show("Usao u DRUGI IF");
									cmd5.CommandText = "dodajTriBoda";
									cmd5.CommandType = CommandType.StoredProcedure;
									cmd5.Parameters.AddWithValue("@IdKluba", IdKlubGostujuci);
									cmd5.Parameters["@IdKluba"].Direction = ParameterDirection.Input;
									cmd5.Connection = conn4;
									cmd5.ExecuteNonQuery();

								}
								else
								{
									//MessageBox.Show("Usao u ELSE");
									//goloviDomaci == goloviGostujuci
									cmd6.CommandText = "dodajBod";
									cmd6.CommandType = CommandType.StoredProcedure;
									cmd6.Parameters.AddWithValue("@IdKlubDomaci", IdKlubDomaci);
									cmd6.Parameters["@IdKlubDomaci"].Direction = ParameterDirection.Input;
									cmd6.Parameters.AddWithValue("@IdKlubGostujuci", IdKlubGostujuci);
									cmd6.Parameters["@IdKlubGostujuci"].Direction = ParameterDirection.Input;
									cmd6.Connection = conn4;
									cmd6.ExecuteNonQuery();


								}
							}
						}

						brojac++;
					}

				}

			}

			NavigationService.Navigate(new UtakmicaZavrsenaEnglish(koloBroj));
		}

		private void Nazad_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new UtakmicaIzmijeniEnglish(koloBroj));
		}
	}
}
