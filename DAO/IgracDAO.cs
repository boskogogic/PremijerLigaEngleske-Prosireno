using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HCIProjekat2.Model;
using MySql.Data.MySqlClient;

namespace HCIProjekat2.DAO
{
	class IgracDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		/*public static ObservableCollection<Igrac> getIgraceJednogKluba(string NazivKluba)
		{
			var listaIgraca = new ObservableCollection<Igrac>();
			using (var conn = new MySqlConnection())
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getIgrace";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							//public Igrac(int IdOsobe, string Ime, string Prezime, DateTime DatumRodjenja, 
							//int IdKluba, string Pozicija, int Plata, int BrojGolova, int UkupanBrojAsistencija, 
							//int BrojNaDresu, string Nacionalnost) : base(IdOsobe, Prezime,Ime,DatumRodjenja)
							string IdOsobeString = reader[0] as string;
							int IdOsobe = Int32.Parse(IdOsobeString);

							string prezime = reader[1] as string;
							string ime = reader[2] as string;

							string datum = reader[3] as string;
							DateTime datumRodjenja = Convert.ToDateTime(datum);

							string IdOsobeIgracString = reader[4] as string;
							int IdOsobeIgrac = Int32.Parse(IdOsobeIgracString);

							string IdKlubaString = reader[5] as string;
							int IdKluba = Int32.Parse(IdKlubaString);

							string pozicija = reader[6] as string;
							 
							string plataString = reader[7] as string;
							int plata = Int32.Parse(plataString);

							string brojGolovaString = reader[8] as string;
							int brojGolova = Int32.Parse(brojGolovaString);

							string ukupanBrojAsistencijaString = reader[9] as string;
							int ukupanBrojAsistencija = Int32.Parse(ukupanBrojAsistencijaString);

							string brojNaDresuString = reader[10] as string;
							int brojNaDresu = Int32.Parse(brojNaDresuString);

							string nacionalnost = reader[11] as string;

							listaIgraca.Add(new Igrac(IdOsobe, prezime, ime, datumRodjenja, IdOsobeIgrac, IdKluba, pozicija, plata, brojGolova, ukupanBrojAsistencija, brojNaDresu, nacionalnost)); 

							MessageBox.Show("Prikaz informacija : " + reader[0] + " " + reader[1]);
						}
						
					}
				}
			}
			return listaIgraca;

		}*/



		/* Helper method which have name of the klub as parameter and returns his (Klub) ID. */
		public static int findKlubId(string NazivKluba)
		{

			int IdValue;


			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getKlubId";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;

					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}

			return IdValue;
		}

		public static int findOsobaId(string prezime)
		{

			int IdValue;


			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getOsobaId";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Prezime", prezime);
					cmd.Parameters["@Prezime"].Direction = ParameterDirection.Input;

					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}

			return IdValue;
		}

		public static DataTable getIgraceDataTable(string NazivKluba)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getIgrace";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}
		}

		public static DataTable getIgracaPrezime(string prezime)
		{
			int IdOsoba;
			IdOsoba = findOsobaId(prezime);

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getIgracaSaPrezimenom";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@OsobaId", IdOsoba);
					cmd.Parameters["@OsobaId"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}


		}

		public static DataTable getIgracBrojeveNaDresovima(string nazivKluba)
		{

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getBrojeveNaDresovimaJednogKluba";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@nazivKluba", nazivKluba);
					cmd.Parameters["@nazivKluba"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}
		}

		public static void izmijeniIgraca(string prezime, string pozicija)
		{
			int IdOsoba;
			IdOsoba = findOsobaId(prezime);

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "izmijeniIgracaPozicija";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@OsobaId", IdOsoba);
					cmd.Parameters["@OsobaId"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@pozicija", pozicija);
					cmd.Parameters["@pozicija"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					//return dt;
				}
				conn.Close();
			}
		}

		public static void izmijeniIgracaBroj(string prezime, int brojNaDresu)
		{

			int IdOsoba;
			IdOsoba = findOsobaId(prezime);

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "izmijeniIgracaBrojNaDresu";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@OsobaId", IdOsoba);
					cmd.Parameters["@OsobaId"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@brojNaDresu", brojNaDresu);
					cmd.Parameters["@brojNaDresu"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					//return dt;
				}
				conn.Close();
			}

		}

		//public Igrac(int IdOsobe, string Ime, string Prezime, DateTime DatumRodjenja, 
		//int IdKluba, string Pozicija, int Plata, int BrojGolova, int UkupanBrojAsistencija, 
		//int BrojNaDresu, string Nacionalnost) : base(IdOsobe, Prezime,Ime,DatumRodjenja)
		public static void dodajIgraca(string Prezime, string Ime, DateTime DatumRodjenja, string Pozicija, int Plata, int BrojGolova, int UkupanBrojAsistencija, int BrojNaDresu, string Nacionalnost, string NazivKluba)
		{
			int IdKlub;
			IdKlub = findKlubId(NazivKluba);

			MessageBox.Show("Klub Id je " + IdKlub);

			using (var conn = new MySqlConnection(connectionString))
			{

				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					/*create procedure dodajIgraca(in Prezime varchar(20), in Ime varchar(20), 
					in DatumRodjenja date, in IdKlub int, in Pozicija varchar(20), 
					in Plata int, in BrojGolova int, in UkupanBrojAsistencija int,
					in BrojNaDresu int, in Nacionalnost varchar(50))*/

					cmd.Connection = conn;
					cmd.CommandText = "dodajIgraca";
					cmd.CommandType = CommandType.StoredProcedure;

					/*cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;*/

					cmd.Parameters.AddWithValue("@Prezime", Prezime);
					cmd.Parameters["@Prezime"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@Ime", Ime);
					cmd.Parameters["@Ime"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@DatumRodjenja", DatumRodjenja);
					cmd.Parameters["@DatumRodjenja"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@IdKlub", IdKlub);
					cmd.Parameters["@IdKlub"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@Pozicija", Pozicija);
					cmd.Parameters["@Pozicija"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@Plata", Plata);
					cmd.Parameters["@Plata"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@BrojGolova", BrojGolova);
					cmd.Parameters["@BrojGolova"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@UkupanBrojAsistencija", UkupanBrojAsistencija);
					cmd.Parameters["@UkupanBrojAsistencija"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@BrojNaDresu", BrojNaDresu);
					cmd.Parameters["@BrojNaDresu"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@Nacionalnost", Nacionalnost);
					cmd.Parameters["@Nacionalnost"].Direction = ParameterDirection.Input;
					cmd.ExecuteNonQuery();


				}
			}


		}

		public static void obrisiIgraca(string prezime)
		{
			int IdOsoba;
			IdOsoba = findOsobaId(prezime);
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "obrisiIgraca";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@OsobaId", IdOsoba);
					cmd.Parameters["@OsobaId"].Direction = ParameterDirection.Input;


					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					//return dt;
				}
				conn.Close();
			}

		}
	}
}
