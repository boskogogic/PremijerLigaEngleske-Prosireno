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

namespace HCIProjekat2.KoloView
{
	/// <summary>
	/// Interaction logic for KoloPage.xaml
	/// </summary>
	public partial class KoloPage : Page
	{
		public KoloPage()
		{
			InitializeComponent();
			try
			{
				KoloInfoDataGrid.ItemsSource = KoloDAO.koloPrikaziInformacije().DefaultView;
			}
			catch (Exception e)
			{
				MessageBox.Show("Greska prilikom pokusaja prikaza klubova! \n" + e.Message);
			}
		}

	}
}
