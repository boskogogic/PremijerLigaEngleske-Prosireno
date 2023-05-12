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

namespace HCIProjekat2.TabelaView
{
	/// <summary>
	/// Interaction logic for TabelaPage.xaml
	/// </summary>
	public partial class TabelaPage : Page
	{
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public TabelaPage()
		{
			InitializeComponent();
			postaviTabelu();
		}

		private void Button_Nazad(object sender, RoutedEventArgs e)
		{

		}

		public class DataItem
		{
			public DataItem(int ColumnNumber, string Column1, int Column2, int Column3, int Column4)
			{
				this.ColumnNumber = ColumnNumber;
				this.Column1 = Column1;
				this.Column2 = Column2;
				this.Column3 = Column3;
				this.Column4 = Column4;
			}
			public int ColumnNumber { get; set; }
			public string Column1 { get; set; }
			public int Column2 { get; set; }
			public int Column3 { get; set; }
			public int Column4 { get; set; }
		}

		public void postaviTabelu()
		{
			int[] brojGolovaDati = new int[6];
			int[] brojGolovaPrimljeni = new int[6];
			string[] nazivKluba = new string[6];
			int[] IdKluba = new int[6];
			int[] brojBodova = new int[6];

			List<DataItem> listaKlubova = new List<DataItem>();

			int brojac = 0;
			int brojacReader = 0;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				using (var cmd = new MySqlCommand("select Naziv from klub"))
				{
					cmd.Connection = conn;
					MySqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						nazivKluba[brojac] = dr.GetString(0);
						IdKluba[brojac] = IgracDAO.findKlubId(nazivKluba[brojac]);
						brojGolovaDati[brojac] = TabelaDAO.izracunajBrojDatihGolova(IdKluba[brojac]);
						brojGolovaPrimljeni[brojac] = TabelaDAO.izracunajBrojPrimljenihGolova(IdKluba[brojac]);
						brojBodova[brojac] = TabelaDAO.getBrojBodova(IdKluba[brojac]);

						//MessageBox.Show("Ispis je: " + nazivKluba[brojac] + " " + brojGolovaDati[brojac] + " " + brojGolovaPrimljeni[brojac] + " " + brojBodova[brojac] + " " + brojac);
						brojac++;
						brojacReader++;

						
					}

				}

			}
			int brojacForPetlje = 0;
			int brojNaTabeli = 1;
			for (int i = 0; i < brojac; i++)
			{
				for (int j = 0; j < brojac; j++)
				{
					if (brojBodova[i] > brojBodova[j] || (brojBodova[i] == brojBodova[j] && ((brojGolovaDati[i] - brojGolovaPrimljeni[i]) > (brojGolovaDati[j] - brojGolovaPrimljeni[j]))))
					{
						brojacForPetlje++;
					}
					if (brojBodova[i] == brojBodova[j] && ((brojGolovaDati[i] - brojGolovaPrimljeni[i]) == (brojGolovaDati[j] - brojGolovaPrimljeni[j]) && i > j))
					{
						brojacForPetlje++;

					}
				}
				int mjestoNaTabeli = brojNaTabeli - brojacForPetlje + 5; //izracuna mjesto na tabeli
				listaKlubova.Add(new DataItem(mjestoNaTabeli, nazivKluba[i], brojGolovaDati[i], brojGolovaPrimljeni[i], brojBodova[i]));
				brojacForPetlje = 0;
			}

			int brojac2 = 0;
			
			while (brojac2 < 6)
			{
				tabelaInfoDataGrid.Items.Add(listaKlubova[brojac2]);
				brojac2++;
			}

			//this.dataGridView1.Sort(this.dataGridView1.Columns["Name"], ListSortDirection.Ascending);
			
		}
			
		

		private void TabelaInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void TabelaInfoDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
		{

		}
	}
}
