using HCIProjekat2.DAO;
using MySql.Data.MySqlClient;
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

namespace HCIProjekat2.IgracView
{
	/// <summary>
	/// Interaction logic for IgracDodaj.xaml
	/// </summary>
	public partial class IgracDodaj : Page
	{
		static string klubNaziv;
		const string connectionString = "SERVER=localhost;DATABASE=premijer_liga_hci;UID=root;PASSWORD=;";

		public IgracDodaj(string nazivKluba)
		{
			klubNaziv = nazivKluba;
			InitializeComponent();
		}



		private void Button_Dodaj(object sender, RoutedEventArgs e)
		{
			DateTime datumRodjenja = Convert.ToDateTime(DatumRodjenjaTextBox.Text);
			int plata = int.Parse(PlataTextBox.Text);
			int brojNaDresu = int.Parse(BrojNaDresuTextBox.Text);
			IgracDAO.dodajIgraca(PrezimeTextBox.Text, ImeTextBox.Text, datumRodjenja, PozicijaTextBox.Text, plata, 0, 0, brojNaDresu, NacionalnostTextBox.Text, klubNaziv);
		}

		private void Button_Nazad(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new IgracPrikaz(klubNaziv));
		}
	}
}
