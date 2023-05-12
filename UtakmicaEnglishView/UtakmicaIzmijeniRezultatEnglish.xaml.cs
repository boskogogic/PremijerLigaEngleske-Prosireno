using HCIProjekat2.DAO;
using System;
using System.Collections.Generic;
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
	/// Interaction logic for UtakmicaIzmijeniRezultatEnglish.xaml
	/// </summary>
	public partial class UtakmicaIzmijeniRezultatEnglish : Page
	{
		static int brojKola;
		static int IdUtakmica;
		static string domaciKlub;
		static string gostujuciKlub;

		public UtakmicaIzmijeniRezultatEnglish(string klubDomaci, string klubGostujuci, int koloBroj)
		{
			brojKola = koloBroj;
			InitializeComponent();
			domaciKlub = klubDomaci;
			gostujuciKlub = klubGostujuci;
			KlubComboBox.Items.Add(klubDomaci);
			KlubComboBox.Items.Add(klubGostujuci);

			try
			{
				IgraciDomaciInfoDataGrid.ItemsSource = UtakmicaDAO.getPrvaPostava(klubDomaci).DefaultView;
				IgraciGostujuciInfoDataGrid.ItemsSource = UtakmicaDAO.getPrvaPostava(klubGostujuci).DefaultView;


			}
			catch (Exception e)
			{
				MessageBox.Show("Gresko prilikom ispisa IGRACADAO" + "\n" + e.Message);
			}

			IdUtakmica = UtakmicaDAO.getIdUtakmica(klubDomaci, klubGostujuci, brojKola);

		}

		private void Button_Dodaj(object sender, RoutedEventArgs e)
		{
			string opadajuciMeni = KlubComboBox.SelectedValue as string;
			Boolean isEmpty = String.IsNullOrEmpty(opadajuciMeni);

			if (isEmpty)
			{
				MessageBox.Show(" You didn't chose a game!");
			}
			else
			{
				string igrac = IgracTextBox.Text as string;
				int minutGola = int.Parse(MinutTextBox.Text);
				string klub = KlubComboBox.SelectedValue as string;
				int IdIgrac = IgracDAO.findOsobaId(igrac);

				if (klub.Equals(domaciKlub))
				{
					UtakmicaDAO.dodajGolDomaci(minutGola, klub, IdUtakmica, IdIgrac);
					MessageBox.Show("Goal has been scored by " + igrac + " !!");
				}
				else
				{
					UtakmicaDAO.dodajGolGostujuci(minutGola, klub, IdUtakmica, IdIgrac);
					MessageBox.Show("Goal has been scored by  " + igrac + " !!");
				}

			}
		}

		private void Button_Nazad(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new UtakmicaIzmijeniEnglish(brojKola));
		}
	}
}

