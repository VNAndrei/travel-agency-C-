using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	[Serializable]
	public class UpdateDTO
	{
		public UpdateDTO(int eid, int nrLocuri)
		{
			Eid = eid;
			NrLocuri = nrLocuri;
		}

		public int Eid { get; }
		public int NrLocuri { get; }


	}
}
