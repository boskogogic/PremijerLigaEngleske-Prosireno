using HCIProjekat2.DAO;
using HCIProjekat2.IgracView;
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

namespace HCIProjekat2.IgracEnglishView
{
	/// <summary>
	/// Interaction logic for IgraciIzmijeniBrojNaDresuEnglish.xaml
	/// </summary>
	public partial class IgraciIzmijeniBrojNaDresuEnglish : Page
	{
		static string nazivKluba;
		static string prezimeIgrac;

		public IgraciIzmijeniBrojNaDresuEnglish(string klubNaziv, string igracPrezime)
		{
			nazivKluba = klubNaziv;
			prezimeIgrac = igracPrezime;
			InitializeComponent();
			fillComboBox();

			var dt = new DataTable();
			dt = IgracDAO.getIgracaPrezime(prezimeIgrac);

			Object cellValuePrezime = dt.Rows[0][0];
			Object cellValueIme = dt.Rows[0][1];
			Object cellValueNacionalnost = dt.Rows[0][2];
			Object cellValueBrojNaDresu = dt.Rows[0][3];
			Object cellValuePozicija = dt.Rows[0][4];


			Prezime.Text = Convert.ToString(cellValuePrezime);
			Ime.Text = Convert.ToString(cellValueIme);
			Nacionalnost.Text = Convert.ToString(cellValueNacionalnost);
			Pozicija.Text = Convert.ToString(cellValuePozicija);
			BrojNaDresu.Text = Convert.ToString(cellValueBrojNaDresu);
		}

		public void fillComboBox()
		{
			int[] brojDresovaComboBox = new int[100];
			brojDresovaComboBox = getBrojeveNaDresovima(nazivKluba);
			int i = 0;

			while (i < 100)
			{
				if (brojDresovaComboBox[i] == 0)
				{
					i++;
				}
				else
				{
					BrojNaDresuComboBox.Items.Add(brojDresovaComboBox[i]);
					i++;
				}
			}
		}

		public int[] getBrojeveNaDresovima(string nazivKluba)
		{
			int[] dozvoljeniBrojeviNaDresovima = new int[100];
			int[] zabranjeniBrojeviNaDresovima = new int[100];

			Object[] cellValue = new object[100];
			var dt = new DataTable();
			dt = IgracDAO.getIgracBrojeveNaDresovima(nazivKluba);
			int i = 0;

			MessageBox.Show("Kolona sumnjiva je : " + dt.Rows[i][0]);
			int counter = dt.Rows.Count;
			while (i < counter)
			{
				cellValue[i] = dt.Rows[i][0];
				i++;
			}

			for (int k = 0; cellValue[k] != null; k++)
			{
				zabranjeniBrojeviNaDresovima[k] = Convert.ToInt32(cellValue[k]);
			}

			int flag = 0;
			int brojac = 0;

			for (int j = 1; j < 100; j++)
			{
				for (int z = 0; z < 100; z++)
				{
					if (zabranjeniBrojeviNaDresovima[z] == j)
					{
						flag = 1;
					}
				}

				if (flag == 0)
				{
					dozvoljeniBrojeviNaDresovima[brojac++] = j;
				}
				flag = 0;
			}

			return dozvoljeniBrojeviNaDresovima;
		}

		private void Potvrdi_Click(object sender, RoutedEventArgs e)
		{
			int brojNaDresu = 0;
			brojNaDresu = (int)BrojNaDresuComboBox.SelectedValue;
			if (brojNaDresu != 0)
			{
				IgracDAO.izmijeniIgracaBroj(prezimeIgrac, brojNaDresu);
				NavigationService.Navigate(new IgracBrojNaDresu(nazivKluba, prezimeIgrac));
			}
			else
			{
				MessageBox.Show("Niste odabrali novi broj na dresu!");
			}



		}
	}
}
