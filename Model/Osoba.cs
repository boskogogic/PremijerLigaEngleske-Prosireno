using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Osoba
	{
		public int IdOsoba { get; set; }
		public string Prezime { get; set; }
		public string Ime { get; set; }
		public DateTime DatumRodjenja { get; set; }

		public Osoba() { }

		public Osoba(int IdOsoba, string Prezime, string Ime, DateTime DatumRodjenja)
		{
			this.IdOsoba = IdOsoba;
			this.Prezime = Prezime;
			this.Ime = Ime;
			this.DatumRodjenja = DatumRodjenja;
		}
	}
}
