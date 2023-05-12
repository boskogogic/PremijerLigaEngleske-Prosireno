using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Utakmica
	{
		public int IdUtakmice { get; set; }
		public DateTime Termin { get; set; }
		public int IdKlubDomaci { get; set; }
		public int IdKlubGostujuci { get; set; }
		public int BrojGolovaDomaci { get; set; }
		public int BrojGolovaGostujuci { get; set; }
		public bool Zavrsena;

		public Utakmica(int IdUtakmice, DateTime Termin, int IdKlubDomaci, int IdKlubGostujuci, int BrojGolovaDomaci, int BrojGolovaGostujuci, bool Zavrsena)
		{
			this.IdUtakmice = IdUtakmice;
			this.Termin = Termin;
			this.IdKlubDomaci = IdKlubDomaci;
			this.IdKlubGostujuci = IdKlubGostujuci;
			this.BrojGolovaDomaci = BrojGolovaDomaci;
			this.BrojGolovaGostujuci = BrojGolovaGostujuci;
			this.Zavrsena = Zavrsena;
		}
	}
}
