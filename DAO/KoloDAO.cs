using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.DAO
{
	class KoloDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public static DataTable koloPrikaziInformacije()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("koloPrikaziInformacije"))
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

		public static DataTable getLastKolo()
		{
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getLastKolo";
					cmd.CommandType = CommandType.StoredProcedure;

					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}


		}


		public static int getLastKoloBroj()
		{
			int brojZadnjegKola;
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getLastKolo";
					cmd.CommandType = CommandType.StoredProcedure;

					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					string zadnjeKolo = dr.GetString(0);
					brojZadnjegKola = Int32.Parse(zadnjeKolo);
					
				}
				conn.Close();
			}
			return brojZadnjegKola;
		


		}
	}
}
