using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	[Serializable]
	public class Agent
	{
	
		public string username { get; set; }
		public string password { get; set; }

		public Agent( string username, string password)
		{
			
			this.username = username;
			this.password = password;
		}
	}
}
