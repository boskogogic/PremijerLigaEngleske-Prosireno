using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat2.Model
{
	public class Dogadjaj
	{
		public int IdVrstaDogadjaja { get; set; }
		public int minutDogadjaja { get; set; }

		public Dogadjaj(int IdVrstaDogadjaja, int minutDogadjaja)
		{
			this.IdVrstaDogadjaja = IdVrstaDogadjaja;
			this.minutDogadjaja = minutDogadjaja;
		}
	}
}
