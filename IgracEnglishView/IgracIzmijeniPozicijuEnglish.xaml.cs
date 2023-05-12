using HCIProjekat2.DAO;
using HCIProjekat2.Model;
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
	/// Interaction logic for IgracIzmijeniPozicijuEnglish.xaml
	/// </summary>
	public partial class IgracIzmijeniPozicijuEnglish : Page
	{
		static string nazivKluba;
		static string prezimeIgrac;

		public IgracIzmijeniPozicijuEnglish(string klubNaziv, string igracPrezime)
		{
			nazivKluba = klubNaziv;
			prezimeIgrac = igracPrezime;
			InitializeComponent();

			Igrac i = new Igrac();
			var dt = new DataTable();
			dt = IgracDAO.getIgracaPrezime(igracPrezime);

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




		private void Potvrdi_Click(object sender, RoutedEventArgs e)
		{
			if (PozicijaTextBox != null)
			{

				IgracDAO.izmijeniIgraca(prezimeIgrac, PozicijaTextBox.Text);
				NavigationService.Navigate(new IgracPozicijaEnglish(nazivKluba, prezimeIgrac));

			}
			else
			{
				MessageBox.Show("Niste unijeli novu poziciju!");
			}
		}
	}
}
