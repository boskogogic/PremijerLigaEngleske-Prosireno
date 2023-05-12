using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Klub
	{
		public int IdKlub { get; set; }
		public int IdDrzava_Ujedinjeno_Kraljevstvo { get; set; }
		public int IdLiga { get; set; }
		public int IdStadion { get; set; }
		public string Naziv { get; set; }
		public string Adresa { get; set; }


		public Klub(int IdKlub, int IdDrzava_UjedinjenoKraljevstvo, int IdLiga, int IdStadion, string Naziv, string Adresa)
		{
			this.IdKlub = IdKlub;
			this.IdDrzava_Ujedinjeno_Kraljevstvo = IdDrzava_Ujedinjeno_Kraljevstvo;
			this.IdLiga = IdLiga;
			this.Naziv = Naziv;
			this.Adresa = Adresa;

		}

	}
}
