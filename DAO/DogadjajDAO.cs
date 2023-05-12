using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.DAO
{
	class DogadjajDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

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

		public static int findUtakmicaId(int IdKlubDomaci, int IdKlubGostujuci)
		{
			int IdValue;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getUtakmicaId";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdKlubDomaci", IdKlubDomaci);
					cmd.Parameters["@IdKlubDomaci"].Direction = ParameterDirection.Input;

					cmd.Parameters.AddWithValue("@IdKlubGostujuci", IdKlubGostujuci);
					cmd.Parameters["@IdKlubGostujuci"].Direction = ParameterDirection.Input;

					MySqlDataReader dr = cmd.ExecuteReader();
					dr.Read();
					IdValue = dr.GetInt32(0);

				}

			}

			return IdValue;
		}


		public static DataTable getDogadjaj(string klubDomaci, string klubGostujuci)
		{
			int IdKlubDomaci = findKlubId(klubDomaci);
			int IdKlubGostujuci = findKlubId(klubGostujuci);

			int IdUtakmica = findUtakmicaId(IdKlubDomaci, IdKlubGostujuci);


			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = "getDogadjaj";
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@IdUtakmica", IdUtakmica);
					cmd.Parameters["@IdUtakmica"].Direction = ParameterDirection.Input;
					MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				conn.Close();
			}

		}
	}
}
