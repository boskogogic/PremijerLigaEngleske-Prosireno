using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Igrac : Osoba
	{


		public int IdOsobe { get; set; }
		public int IdKluba { get; set; }
		public string Pozicija { get; set; }
		public int Plata { get; set; }
		public int BrojGolova { get; set; }
		public int UkupanBrojAsistencija { get; set; }
		public int BrojNaDresu { get; set; }
		public string Nacionalnost { get; set; }

		public Igrac() : base() { }


		/* Napomena -> Neka vrsta super metode u C#. */
		public Igrac(int IdOsobe, string Prezime, string Ime, DateTime DatumRodjenja, int IdOsobeIgrac, int IdKluba, string Pozicija, int Plata, int BrojGolova, int UkupanBrojAsistencija, int BrojNaDresu, string Nacionalnost) : base(IdOsobe, Prezime, Ime, DatumRodjenja)
		{
			this.IdOsobe = IdOsobeIgrac;
			this.IdKluba = IdKluba;
			this.Pozicija = Pozicija;
			this.Plata = Plata;
			this.BrojGolova = BrojGolova;
			this.UkupanBrojAsistencija = UkupanBrojAsistencija;
			this.BrojNaDresu = BrojNaDresu;
			this.Nacionalnost = Nacionalnost;
		}


		/*public Igrac(string ime, string prezime, string pozicija, string nacionalnost)
		{
			base.Ime = ime;
			base.Prezime = prezime;
			this.Pozicija = pozicija;
			this.Nacionalnost = nacionalnost;
		}*/


	}
}
