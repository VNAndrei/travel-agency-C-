using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Model;
using Services;

namespace Networking
{
	public class ServerProxy:IServices
	{

		private string host;
		private int port;

		private IObserver client;
		private NetworkStream stream;
		private IFormatter formatter;
		private TcpClient connection;
		private Queue<IResponse> responses=new Queue<IResponse>();
		private volatile bool finished;
		private EventWaitHandle waitHandle;

		public ServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
		}

		public void addRezervare(Rezervare r)
		{
			RezervareDTO rezervareDto = DTOUtils.getDTO(r);
			AddRezervareRequest addRequest= new AddRezervareRequest(rezervareDto);
			sendRequest(addRequest);
			IResponse response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse resp = (ErrorResponse) response;
				throw  new ServicesException(resp.Message);
			}
		}

		public IEnumerable<Excursie> findAll()
		{
			GetAllExcursiiRequest getRequest= new GetAllExcursiiRequest();
			sendRequest(getRequest);
			IResponse response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse resp = (ErrorResponse)response;
				throw new ServicesException(resp.Message);
			}

			GetAllExcursiiResponse getResponse = (GetAllExcursiiResponse) response;
			IEnumerable<Excursie> excursii = DTOUtils.getFromDTO(getResponse.Excursii).ToList();
			return  excursii;
		}

		public IEnumerable<Excursie> findByDate(string destinatie, string begin, string end)
		{
			FilterDTO fdto= new FilterDTO(begin,end,destinatie);
			GetByDateRequest getRequest = new GetByDateRequest(fdto);
			sendRequest(getRequest);
			IResponse response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse resp = (ErrorResponse)response;
				throw new ServicesException(resp.Message);
			}

			GetByDateResponse getResponse = (GetByDateResponse)response;
			IEnumerable<Excursie> excursii = DTOUtils.getFromDTO(getResponse.Excursii).ToList();
			return excursii;
		}

		public bool login(string username, string password, IObserver user)
		{
			AgentDTO adto= new AgentDTO(username,password);
			LoginRequest loginRequest= new LoginRequest(adto);

			initializeConnection();
			sendRequest(loginRequest);
			IResponse response = readResponse();
			if (response is OkResponse)
			{
				this.client = user;
				return true;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse resp = (ErrorResponse)response;
				closeConnection();
				throw new ServicesException(resp.Message);
			}

			return false;
		}

		public void logout(string username, IObserver user)
		{
			AgentDTO adto = new AgentDTO(username, "");
			LogoutRequest logoutRequest = new LogoutRequest(adto);
			sendRequest(logoutRequest);
			IResponse response = readResponse();
			
			if (response is OkResponse)
			{
				closeConnection();
			}
			if (response is ErrorResponse)
			{
				ErrorResponse resp = (ErrorResponse)response;
				throw new ServicesException(resp.Message);
			}

		}

		private void closeConnection()
		{
			finished = true;
			try
			{
				stream.Close();
				connection.Close();
				waitHandle.Close();
				client = null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				
			}
		}

		private void handleUpdate(UpdateLocuriResponse response)
		{
			try
			{
				client.updateNrLocuri(response.UpdateDto);
			}
			catch (ServicesException e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		private void startReader()
		{
			Thread t= new Thread(run);
			t.Start();
		}

		public virtual void run()
		{
			while (!finished)
			{
				try
				{
					object response = formatter.Deserialize(stream);
					Console.WriteLine("Response Received" + response);
					if (response is UpdateLocuriResponse)
					{
						handleUpdate((UpdateLocuriResponse) response);
					}
					else
					{
						lock (responses)
						{
							responses.Enqueue((IResponse) response);
						}

						waitHandle.Set();
					}

				}
				catch (Exception e)
				{
					Console.WriteLine("Reading error "+e);
				}
				
			}
		}

		private void initializeConnection()
		{
			try
			{
				connection = new TcpClient(host, port);
				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				finished = false;
				waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public void sendRequest(IRequest request)
		{
			try
			{
				formatter.Serialize(stream,request);
				stream.Flush();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
				
			}
		}

		public IResponse readResponse()
		{
			IResponse response = null;
			try
			{
				waitHandle.WaitOne();
				lock (responses)
				{
					response = responses.Dequeue();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
				
			}

			return response;
		}

	}
}
