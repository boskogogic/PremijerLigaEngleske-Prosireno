using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Kolo
	{
		/*create table KOLO
(
	IdLiga int not null,
    IdUtakmica int not null,
    RedniBroj int,
    Sezona int,
    primary key (IdLiga,IdUtakmica),
    foreign key (IdLiga)
    references LIGA(IdLIga),
    foreign key (IdUtakmica)
    references UTAKMICA(IdUtakmica)
);*/
		public int IdLiga { get; set; }
		public int IdUtakmica { get; set; }
		public int RedniBroj { get; set; }
		public int Sezona { get; set; }

		public Kolo(int IdLiga, int IdUtakmica, int RedniBroj, int Sezona)
		{
			this.IdLiga = IdLiga;
			this.IdUtakmica = IdUtakmica;
			this.RedniBroj = RedniBroj;
			this.Sezona = Sezona;
		}
	}
}
