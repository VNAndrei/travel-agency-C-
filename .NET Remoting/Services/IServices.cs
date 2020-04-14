using Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Services
{
	public interface IServices
	{
		bool login(string username, string password, IObserver user);
		void logout(string username, IObserver user);
		IEnumerable<Excursie> findAll();
		IEnumerable<Excursie> findByDate(string destinatie, string begin, string end);
		void addRezervare(Rezervare r);
	}
}

