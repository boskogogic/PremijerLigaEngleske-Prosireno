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

namespace HCIProjekat2.UtakmicaView
{
    /// <summary>
    /// Interaction logic for UtakmicaRezultat.xaml
    /// </summary>
    public partial class UtakmicaRezultat : Page
    {
		static int brojKola;
        public UtakmicaRezultat(string klubDomaci, string klubGostujuci, int koloBroj)
        {
            InitializeComponent();
			Domacin.Content = klubDomaci;
			Gost.Content = klubGostujuci;
			brojKola = koloBroj;
			int IdUtakmice = UtakmicaDAO.getIdUtakmica(klubDomaci, klubGostujuci, brojKola);

			int[] rezultat = new int[2];
		
			try
			{
				RezultatDomaciInfoDataGrid.ItemsSource = UtakmicaDAO.getStrijelac(IdUtakmice, klubDomaci).DefaultView;
				RezultatGostujuciInfoDataGrid.ItemsSource = UtakmicaDAO.getStrijelac(IdUtakmice, klubGostujuci).DefaultView;

				rezultat = UtakmicaDAO.getRezultat(klubDomaci, klubGostujuci, brojKola);
			}
			catch (Exception e)
			{
				MessageBox.Show("Gresko prilikom ispisa UTAKMICADAO rezultat" + "\n" + e.Message);
			}

			GoloviDomacin.Content = rezultat[0];
			GoloviGost.Content = rezultat[1];
		}

		private void Nazad_Click(object sender, RoutedEventArgs e)
		{
			int zadnjeKolo = (int)KoloDAO.getLastKoloBroj();
			if (zadnjeKolo == brojKola)
			{
				NavigationService.Navigate(new UtakmicaIzmijeni(brojKola));
			}
			else
			{
				NavigationService.Navigate(new UtakmicaZavrsena(brojKola));
			}
			
		}
	}
}
