using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using HCIProjekat2.KlubView;
using HCIProjekat2.IgracView;
using HCIProjekat2.KoloView;
using HCIProjekat2.UtakmicaView;
using HCIProjekat2.TabelaView;

namespace HCIProjekat2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			DashBoardFrame.Content = new HomePage();
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
			DashBoardFrame.Content = new IstorijaPage();
		}

		private void Buton_Click_Klub(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new KlubPage();
		}

		private void Button_Click_Igrac(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new IgracPage();

		}

		private void Button_Click_Kolo(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new KoloPage();
		}

		private void Button_Click_Tabela(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new TabelaPage();
		}

		private void Button_Click_Utakmica(object sender, RoutedEventArgs e)
		{
			DashBoardFrame.Content = new UtakmicaPage();
		}

	

		private void EngleskiButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindowEnglish mwe = new MainWindowEnglish();
			mwe.Show();
			this.Hide();
		}

		private void SrpskiButton_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow();
		}
	}
}



/*	Maybe I would need this part of code later.
 * private void ListViewItem_PreviewMousLeftButtonDown(object sender, MouseButtonEventArgs e)
*{
*	ListViewMenu.SelectedItems.Clear();
*	var item = sender as ListViewItem;

*	if (item != null)
	{
		item.IsSelected = true;
		ListViewMenu.SelectedItem = item;
	}
}
 * 
 * private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{
	var item = sender as ListViewItem;
	if (item == Home && item.IsSelected)
	{
		DashBoardFrame.Content = new HomePage();
	}
	else if (item == Klub && item.IsSelected)
	{
		DashBoardFrame.Content = "NE SERI";//= new KlubPage();
	}
	else if (item == Igrac && item.IsSelected)
	{
	}
	else if (item == Kolo && item.IsSelected)
	{
	}
	else
	{
	}
}*/
