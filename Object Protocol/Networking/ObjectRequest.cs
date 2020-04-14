using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
	public interface IRequest
	{
	}

	[Serializable]
	public class LoginRequest : IRequest
	{
		public AgentDTO Agent { get; }


		public LoginRequest(AgentDTO agent)
		{
			this.Agent = agent;
		}
		
	}

	[Serializable]
	public class GetAllExcursiiRequest : IRequest { }
	
	[Serializable]
	public class LogoutRequest : IRequest
	{
		public AgentDTO Agent { get; }


		public LogoutRequest(AgentDTO agent)
		{
			this.Agent = agent;
		}

	}

	[Serializable]
	public class AddRezervareRequest : IRequest
	{
		public RezervareDTO Rezervare { get; }

		public AddRezervareRequest(RezervareDTO rezervare)
		{
			this.Rezervare = rezervare;
		}
	}

	[Serializable]
	public class GetByDateRequest : IRequest
	{
		public FilterDTO Filter { get; }

		public GetByDateRequest(FilterDTO filter)
		{
			this.Filter = filter;
		}
	}



}
