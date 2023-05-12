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
	/// Interaction logic for UtakmicaPostaveEnglish.xaml
	/// </summary>
	public partial class UtakmicaPostaveEnglish : Page
	{
		public static int koloBroj;
		public UtakmicaPostaveEnglish(string klubDomaci, string klubGostujuci, int brojKola)
		{
			koloBroj = brojKola;
			InitializeComponent();
			Domacin.Content = klubDomaci;
			Gost.Content = klubGostujuci;
			try
			{
				IgraciDomaciInfoDataGrid.ItemsSource = UtakmicaDAO.getPrvaPostava(klubDomaci).DefaultView;
				IgraciGostujuciInfoDataGrid.ItemsSource = UtakmicaDAO.getPrvaPostava(klubGostujuci).DefaultView;


			}
			catch (Exception e)
			{
				MessageBox.Show("Gresko prilikom ispisa IGRACADAO" + "\n" + e.Message);
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

