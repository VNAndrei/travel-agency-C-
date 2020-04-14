using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
	public interface IResponse { }
	public interface IUpdateResponse : IResponse { }

	[Serializable]
	public class OkResponse : IResponse
	{
	}

	[Serializable]
	public class ErrorResponse : IResponse
	{
		public string Message { get; }
		public ErrorResponse(string message)
		{
			this.Message = message;
		}

	}

	[Serializable]
	public class GetAllExcursiiResponse : IResponse
	{
		public ExcursieDTO[] Excursii { get; }

		public GetAllExcursiiResponse(ExcursieDTO[] excursii)
		{
			Excursii = excursii;
		}
	}

	[Serializable]
	public class GetByDateResponse : IResponse
	{
		public ExcursieDTO[] Excursii { get; }

		public GetByDateResponse(ExcursieDTO[] excursii)
		{
			Excursii = excursii;
		}
	}

	[Serializable]
	public class UpdateLocuriResponse : IUpdateResponse
	{
		public UpdateLocuriResponse(UpdateDTO updateDto)
		{
			UpdateDto = updateDto;
		}

		public UpdateDTO UpdateDto { get; }
	}




}
