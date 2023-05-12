using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Detalji_Utakmice
	{
		/*create table DETALJI_UTAKMICE
(
	IdUtakmica int not null,
    IdIgrac int not null,
    IgraoOdMinute int,
    IgraoDoMinute int,
    primary key(IdUtakmica,IdIgrac),
    foreign key (IdUtakmica)
    references UTAKMICA(IdUtakmica),
    foreign key (IdIgrac)
    references IGRAC(IdIgrac)
);*/

		public int IdUtakmice { get; set; }
		public int IdIgrac { get; set; }
		public int IgraoOdMinute { get; set; }
		public int IgraoDoMinute { get; set; }

		public Detalji_Utakmice(int IdUtakmice, int IdIgrac, int IgraoOdMinute, int IgraoDoMinute)
		{
			this.IdUtakmice = IdUtakmice;
			this.IdIgrac = IdIgrac;
			this.IgraoOdMinute = IgraoOdMinute;
			this.IgraoDoMinute = IgraoDoMinute;
		}
	}
}
