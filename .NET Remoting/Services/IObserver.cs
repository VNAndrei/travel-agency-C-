using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
	public interface IObserver
	{
		void updateNrLocuri(object updateDTO);
	}
}
