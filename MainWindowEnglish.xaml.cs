using HCIProjekat2.IgracEnglishView;
using HCIProjekat2.KlubEnglishView;
using HCIProjekat2.KoloEnglishView;
using HCIProjekat2.TabelaEnglishView;
using HCIProjekat2.UtakmicaEnglishView;
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
using System.Windows.Shapes;

namespace HCIProjekat2
{
	/// <summary>
	/// Interaction logic for MainWindowEnglish.xaml
	/// </summary>
	public partial class MainWindowEnglish : Window
	{
		public MainWindowEnglish()
		{
			InitializeComponent();
			DashBoardFrame.Content = new HomePageEnglish();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed) DragMove();
		}

		public void Minimise_Button_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}


		private void Button_Click_Home(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new IstorijaPageEnglish();
		}

		private void Buton_Click_Klub(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new KlubPageEnglish();
		}

		private void Button_Click_Igrac(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new IgracPageEnglish();

		}

		private void Button_Click_Kolo(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new KoloPageEnglish();
		}

		private void Button_Click_Tabela(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new TabelaPageEnglish();
		}

		private void Button_Click_Utakmica(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new UtakmicaPageEnglish();
		}



		private void EngleskiButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindowEnglish mwe = new MainWindowEnglish();
			mwe.Show();
			this.Close();
		}

		private void SrpskiButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}

