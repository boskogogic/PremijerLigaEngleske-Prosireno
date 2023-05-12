using HCIProjekat2.DAO;
using HCIProjekat2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HCIProjekat2.IgracView
{
	/// <summary>
	/// Interaction logic for IgracPrikaz.xaml
	/// </summary>
	public partial class IgracPrikaz : Page
	{
		static string nazivKluba;
		public IgracPrikaz(string klubNaziv)
		{
			InitializeComponent();
			nazivKluba = klubNaziv;
			try
			{
				IgracInfoDataGrid.ItemsSource = IgracDAO.getIgraceDataTable(klubNaziv).DefaultView;

			}
			catch (Exception e)
			{
				MessageBox.Show("Gresko prilikom ispisa IGRACA DAO" + "\n" + e.Message);
			}
		}

		private void Button_Dodaj(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new IgracDodaj(nazivKluba));
		}

		private void Button_Izmjeni(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new IgracIzmijeniHome(nazivKluba));
		}

		private void Button_Obrisi(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new IgracObrisi(nazivKluba));
		}

		private void Button_Nazad(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new IgracPage());
		}
	}
}
