using HCIProjekat2.DAO;
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
	/// Interaction logic for UtakmicaDetaljiEnglish.xaml
	/// </summary>
	public partial class UtakmicaDetaljiEnglish : Page
	{
		public static int koloBroj;

		public UtakmicaDetaljiEnglish(string klubDomaci, string klubGostujuci, int brojKola)
		{
			InitializeComponent();
			koloBroj = brojKola;
			var dt = new DataTable();
			dt = DogadjajDAO.getDogadjaj(klubDomaci, klubGostujuci);
			if (dt != null && dt.Rows.Count > 0)
			{
				Object cellValueMinut1 = dt.Rows[0][0];
				Object cellValuePrezime1 = dt.Rows[0][1];
				Object cellValueOpis1 = dt.Rows[0][2];

				Object cellValueMinut2 = dt.Rows[1][0];
				Object cellValuePrezime2 = dt.Rows[1][1];
				Object cellValueOpis2 = dt.Rows[1][2];

				//izbacuje nekakvu gresku u nekom momentu
				Object cellValueMinut3 = dt.Rows[2][0];
				Object cellValuePrezime3 = dt.Rows[2][1];
				Object cellValueOpis3 = dt.Rows[2][2];

				Minut1.Text = Convert.ToString(cellValueMinut1);
				Prezime1.Text = Convert.ToString(cellValuePrezime1);
				Opis1.Text = Convert.ToString(cellValueOpis1);

				Minut2.Text = Convert.ToString(cellValueMinut2);
				Prezime2.Text = Convert.ToString(cellValuePrezime2);
				Opis2.Text = Convert.ToString(cellValueOpis2);

				Minut3.Text = Convert.ToString(cellValueMinut3);
				Prezime3.Text = Convert.ToString(cellValuePrezime3);
				Opis3.Text = Convert.ToString(cellValueOpis3);
			}
			else
			{
				Minut1.Text = "";
				Prezime1.Text = "";
				Opis1.Text = "";

				Minut2.Text = "";
				Prezime2.Text = "";
				Opis2.Text = "";

				Minut3.Text = "";
				Prezime3.Text = "";
				Opis3.Text = "";
			}
		}

		private void Nazad_Click(object sender, RoutedEventArgs e)
		{
			int zadnjeKolo = (int)KoloDAO.getLastKoloBroj();
			if (zadnjeKolo == koloBroj)
			{
				NavigationService.Navigate(new UtakmicaIzmijeniEnglish(koloBroj));
			}
			else
			{
				NavigationService.Navigate(new UtakmicaZavrsenaEnglish(koloBroj));
			}
		}
	}
}
