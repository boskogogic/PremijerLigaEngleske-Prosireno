using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIProjekat2.DAO
{
	class UtakmicaDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public static DataTable getPrvaPostava(string NazivKluba)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getPrvuPostavu";
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

		public static int[] getRezultat(string klubDomaci, string klubGostujuci, int brojKola)
		{
			int[] rezultat = new int[2];
			rezultat[0] = 0;
			rezultat[1] = 0;
			int IdKlubDomaci = IgracDAO.findKlubId(klubDomaci);
			int IdKlubGostujuci = IgracDAO.findKlubId(klubGostujuci);
			// Provjera -> ID Su u redu!
			//MessageBox.Show("Provjera ID : " + IdKlubDomaci + " " + IdKlubGostujuci);
			int brojGolovaDomaci = 0;
			int brojGolovaGost = 0;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "vratiRezultat";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKlubDomaci", IdKlubDomaci);
					cmd.Parameters["@IdKlubDomaci"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@IdKlubGostujuci", IdKlubGostujuci);
					cmd.Parameters["@IdKlubGostujuci"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@brojKola", brojKola);
					cmd.Parameters["@brojKola"].Direction = ParameterDirection.Input;
					MySqlDataReader dr = cmd.ExecuteReader();
					
					
					while (dr.Read())
					{
						brojGolovaDomaci = dr.GetInt32(0);
						brojGolovaGost = dr.GetInt32(1);
					}
					dr.Close();
					rezultat[0] = brojGolovaDomaci;
					rezultat[1] = brojGolovaGost;
				}
				conn.Close();
			}
			return rezultat;
		}

		public static int getIdUtakmica(string klubDomaci, string klubGostujuci, int brojKola)
		{
			int IdKlubDomaci = IgracDAO.findKlubId(klubDomaci);
			int IdKlubGostujuci = IgracDAO.findKlubId(klubGostujuci);
			int IdUtakmice;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getUtakmicaIdBrojKola";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKlubDomaci", IdKlubDomaci);
					cmd.Parameters["@IdKlubDomaci"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@IdKlubGostujuci", IdKlubGostujuci);
					cmd.Parameters["@IdKlubGostujuci"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@brojKola", brojKola);
					cmd.Parameters["@brojKola"].Direction = ParameterDirection.Input;
					MySqlDataReader dr = cmd.ExecuteReader();

					dr.Read();
					IdUtakmice = dr.GetInt32(0);
				
					dr.Close();
					
				}
				conn.Close();
			}

			return IdUtakmice;
		}

		public static DataTable getStrijelac(int IdUtakmica, string NazivKluba)
		{
			int IdKluba = IgracDAO.findKlubId(NazivKluba);

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getStrijelac";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@IdUtakmica", IdUtakmica);
					cmd.Parameters["@IdUtakmica"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@IdKluba", IdKluba);
					cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}
		}

		public static int getDatiGoloviKaoDomacin(int IdKlub)
		{
			int brojGolovaDomacin = 0;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getBrojGolovaDomaci";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKluba", IdKlub);
					cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;

					try
					{
						MySqlDataReader dr = cmd.ExecuteReader();
						dr.Read();
						if (!dr.IsDBNull(0))
						{

							brojGolovaDomacin = dr.GetInt32(0);
						}
						else
						{
							brojGolovaDomacin = 0;
						}
					}
					catch (Exception e)
					{
						Console.Write("GRESKAA 4");
					}
				}
				conn.Close();
			}
			return brojGolovaDomacin;
		}

		public static int getDatiGoloviKaoGost(int IdKlub)
		{
			int brojGolovaGost = 0;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getBrojGolovaGostujuci";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKluba", IdKlub);
					cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;

					try
					{
						MySqlDataReader dr = cmd.ExecuteReader();

						dr.Read();
						if (!dr.IsDBNull(0))
						{

							brojGolovaGost = dr.GetInt32(0);
						}
						else
						{
							brojGolovaGost = 0;
						}
					}
					catch (Exception e)
					{
						Console.Write("GRESKA 3");
					}
					

				}
				conn.Close();
			}
			return brojGolovaGost;
		}

		public static int getPrimljeniGoloviKaoDomacin(int IdKlub)
		{
			int brojGolovaDomacinPrimljeno = 0;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getBrojGolovaDomacinPrimljeno";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKluba", IdKlub);
					cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;

					try
					{
						MySqlDataReader dr = cmd.ExecuteReader();
						dr.Read();
						if (!dr.IsDBNull(0))
						{

							brojGolovaDomacinPrimljeno = dr.GetInt32(0);
						}
						else
						{
							brojGolovaDomacinPrimljeno = 0;
						}
					}
					catch (Exception e)
					{
						Console.Write("GRESKA");
					}

				}
				conn.Close();
			}
			return brojGolovaDomacinPrimljeno;
		}

		public static int getPrimljeniGoloviKaoGost(int IdKlub)
		{
			int brojGolovaGostujuciPrimljeno = 0;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getBrojGolovaDomacinGost";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKluba", IdKlub);
					cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;
					try
					{
						MySqlDataReader dr = cmd.ExecuteReader();

						dr.Read();
						if (!dr.IsDBNull(0))
						{

							brojGolovaGostujuciPrimljeno = dr.GetInt32(0);
						}
						else
						{
							brojGolovaGostujuciPrimljeno = 0;
						}
					}   
					catch (Exception e)
				{
					Console.Write("Greska");
				}
			}
				conn.Close();

			}
			return brojGolovaGostujuciPrimljeno;
		}

		public static void dodajGolDomaci(int minutDogadjaja, string NazivKluba, int UtakmicaId, int IgracId)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "dodajGolDomaci";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@minutDogadjaja", minutDogadjaja);
					cmd.Parameters["@minutDogadjaja"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@UtakmicaId", UtakmicaId);
					cmd.Parameters["@UtakmicaId"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@IgracId", IgracId);
					cmd.Parameters["@IgracId"].Direction = ParameterDirection.Input;

					cmd.ExecuteNonQuery();
					
				}
				conn.Close();
			}
		}

		public static void dodajGolGostujuci(int minutDogadjaja, string NazivKluba, int UtakmicaId, int IgracId)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "dodajGolGost";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@minutDogadjaja", minutDogadjaja);
					cmd.Parameters["@minutDogadjaja"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@UtakmicaId", UtakmicaId);
					cmd.Parameters["@UtakmicaId"].Direction = ParameterDirection.Input;
					cmd.Parameters.AddWithValue("@IgracId", IgracId);
					cmd.Parameters["@IgracId"].Direction = ParameterDirection.Input;

					cmd.ExecuteNonQuery();

				}
				conn.Close();
			}
		}


	}
}
