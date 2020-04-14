using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Model;
using Services;
namespace Networking
{
	public class ClientWorker : IObserver
	{
		private IServices server;
		private TcpClient connection;
		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;

		public ClientWorker(IServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				connected = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while (connected)
			{
				try
				{
					object request = formatter.Deserialize(stream);
					object response = handleRequest((IRequest) request);
					if (response != null)
					{
						sendResponse((IResponse) response);
					}
				}
				catch (Exception e)
				{
					connected = false;
					Console.WriteLine(e.StackTrace);
				}

				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
					connected = false;
					Console.WriteLine(e.StackTrace);
				}
			}

			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private IResponse handleRequest(IRequest request)
		{
			
			if (request is LoginRequest)
			{	
				Console.WriteLine("login request;");
				LoginRequest loginRequest = (LoginRequest) request;
				AgentDTO adto = loginRequest.Agent;
				try
				{
					bool check;
					lock (server)
					{
						check=server.login(adto.User, adto.Password, this);
					}
					if(check==true)
						return new OkResponse();
					else
					{
						return new ErrorResponse("USER SAUY PAROLA GRESITE");
					}
					
				}
				catch (ServicesException e)
				{
					connected = false;
					return new ErrorResponse(e.Message);
				}
			}

			if (request is GetAllExcursiiRequest)
			{
				Console.WriteLine("getAllExcursii request;");
				try
				{
					Excursie[] excursii = null;
					lock (server)
					{
						excursii = server.findAll().ToArray();

					}

					ExcursieDTO[] excursiiDTO = DTOUtils.getDTO(excursii);
					return new GetAllExcursiiResponse(excursiiDTO);
				}
				catch (ServicesException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is GetByDateRequest)
			{
				Console.WriteLine("getByDate request;");
				GetByDateRequest getRequest = (GetByDateRequest)request;
				FilterDTO fdto = getRequest.Filter;
				try
				{
					Excursie[] excursii = null;
					lock (server)
					{
						excursii = server.findByDate(fdto.Destination,fdto.Begin,fdto.End).ToArray();

					}

					ExcursieDTO[] excursiiDTO = DTOUtils.getDTO(excursii);
					return new GetByDateResponse(excursiiDTO);
				}
				catch (ServicesException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is AddRezervareRequest)
			{
				Console.WriteLine("addRezervare request;");
				AddRezervareRequest addRequest = (AddRezervareRequest)request;
				RezervareDTO rdto = addRequest.Rezervare;
				Rezervare rezervare = DTOUtils.getFromDTO(rdto);
				try
				{ 
					lock (server)
					{
						server.addRezervare(rezervare);

					}
					return new OkResponse();
					
				}
				catch (ServicesException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("logout request;");
				LogoutRequest logoutRequest = (LogoutRequest)request;
				AgentDTO adto = logoutRequest.Agent;
				try
				{
					lock (server)
					{
						server.logout(adto.User,this);
						

					}

					connected = false;
					return new OkResponse();
				}
				catch (ServicesException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			return null;
		}



		public void updateNrLocuri(object updateDTO)
		{
			UpdateLocuriResponse updateResponse= new UpdateLocuriResponse((UpdateDTO) updateDTO);
			Console.WriteLine("update...");
			try
			{
				sendResponse(updateResponse);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		private void sendResponse(IResponse response)
		{
			Console.WriteLine("sending response"+response);
			formatter.Serialize(stream,response);
			stream.Flush();
		}
	}
}
