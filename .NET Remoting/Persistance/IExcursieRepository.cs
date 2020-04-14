using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LaboratorC
{
	public interface IExcursieRepository
	{
		IEnumerable<Excursie> findByDestinationAndDate(string destinatie, long begin, long end);
		IEnumerable<Excursie> findAll();
		void updateNrLocuri(int eid, int nrLocuri);
	}
}
