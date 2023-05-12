using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCIProjekat2.DAO;
using MySql.Data.MySqlClient;

namespace HCIProjekat2.DAO
{
	class TabelaDAO
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public static int izracunajBrojDatihGolova(int IdKluba)
		{
			int brojGolovaKaoDomacin = 0;
			int brojGolovaKaoGost = 0;
			int brojGolovaUkupno = 0;

			brojGolovaKaoDomacin = UtakmicaDAO.getDatiGoloviKaoDomacin(IdKluba);
			brojGolovaKaoGost = UtakmicaDAO.getDatiGoloviKaoGost(IdKluba);

			brojGolovaUkupno = brojGolovaKaoDomacin + brojGolovaKaoGost;
			return brojGolovaUkupno;
		}

		public static int izracunajBrojPrimljenihGolova(int IdKluba)
		{
			int brojGolovaPrimljenihKaoDomacin = 0;
			int brojGolovaPrimljenihKaoGost = 0;
			int brojGolovaPrimljenihUkupno = 0;

			brojGolovaPrimljenihKaoDomacin = UtakmicaDAO.getPrimljeniGoloviKaoDomacin(IdKluba);
			brojGolovaPrimljenihKaoGost = UtakmicaDAO.getPrimljeniGoloviKaoGost(IdKluba);

			brojGolovaPrimljenihUkupno = brojGolovaPrimljenihKaoDomacin + brojGolovaPrimljenihKaoGost;
			return brojGolovaPrimljenihUkupno;
		}

		public static int getBrojBodova(int IdKluba)
		{
			int brojBodova = 0;
	
				using (var conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					using (var cmd = new MySqlCommand())
					{
						cmd.Connection = conn;
						cmd.CommandText = "getBrojBodova";
						cmd.CommandType = CommandType.StoredProcedure;

						cmd.Parameters.AddWithValue("@IdKluba", IdKluba);
						cmd.Parameters["@IdKluba"].Direction = ParameterDirection.Input;

						MySqlDataReader dr = cmd.ExecuteReader();
						dr.Read();
						brojBodova = dr.GetInt32(0);

					}

				}

			return brojBodova;
		}
	}
}
