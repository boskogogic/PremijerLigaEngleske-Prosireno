using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCIProjekat2.DAO
{
	public class KlubDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		const int brojStanovnikaEngleska = 5628696;
		const int brojStanovnikaVels = 3153000;

		public static DataTable getKluboviDataTable()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("prikaziKlubove"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}
		}

		public static DataTable getKlubPrikaziDodatneInformacije()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("klubPrikaziDodatneInformacije"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = conn;
					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();

			}
		}

		public static void dodajKlub(string NazivKluba, string Adresa, string nazivStadiona, string nazivGrada, int brojStanovnikaGrada, int IdDrzave)
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "dodajKlub";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@NazivKluba", NazivKluba);
					cmd.Parameters["@NazivKluba"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@Adresa", Adresa);
					cmd.Parameters["@Adresa"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@nazivStadiona", nazivStadiona);
					cmd.Parameters["@nazivStadiona"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@nazivGrada", nazivGrada);
					cmd.Parameters["@nazivGrada"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@brojStanovnikaGrada", brojStanovnikaGrada);
					cmd.Parameters["@brojStanovnikaGrada"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@IdDrzave", IdDrzave);
					cmd.Parameters["@IdDrzave"].Direction = ParameterDirection.Input;
					cmd.ExecuteNonQuery();

				}

			}
		}



	}
}
