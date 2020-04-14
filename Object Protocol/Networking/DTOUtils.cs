using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace Networking
{
	class DTOUtils
	{
        public static Agent getFromDTO(AgentDTO agentDTO)
        {
            string user = agentDTO.User;
            string pass = agentDTO.Password;
            return new Agent(user, pass);

        }
        public static AgentDTO getDTO(Agent user)
        {
            string id = user.username;
            string pass = user.password;
            return new AgentDTO(id, pass);
        }

        public static Rezervare getFromDTO(RezervareDTO rezervareDTO)
        {

            int id = rezervareDTO.Id;
            string numeClient = rezervareDTO.NumeClient;
            string numeTuristi = rezervareDTO.NumeTuristi;
            string telefon = rezervareDTO.Telefon;
            int nrLocuri = rezervareDTO.NrLocuri;
            int eId = rezervareDTO.EId;
            return new Rezervare(id, numeClient, numeTuristi, telefon, nrLocuri, eId);

        }

        public static RezervareDTO getDTO(Rezervare rezervare)
        {
            int id = rezervare.id;
            string numeClient = rezervare.numeClient;
            string numeTuristi = rezervare.getStringTuristi();
            string telefon = rezervare.telefon;
            int nrLocuri = rezervare.nrLocuri;
            int eId = rezervare.eId;
            return new RezervareDTO(id, numeClient, numeTuristi, telefon, nrLocuri, eId);
        }

        public static ExcursieDTO[] getDTO(Excursie[] excursii)
        {
            ExcursieDTO[] frDTO = new ExcursieDTO[excursii.Length];
            for (int i = 0; i < excursii.Length; i++)
                frDTO[i] = getDTO(excursii[i]);
            return frDTO;
        }

        private static ExcursieDTO getDTO(Excursie excursie)
        {
            int id = excursie.id;
            string destinatie = excursie.destinatie;
            string data = excursie.data;
            string aeroport = excursie.aeroport;
            int nrLocuri = excursie.nrLocuri;
            return new ExcursieDTO(id, destinatie, data, aeroport, nrLocuri);

        }

        public static Excursie[] getFromDTO(ExcursieDTO[] excursiiDTO)
        {
            Excursie[] friends = new Excursie[excursiiDTO.Length];
            for (int i = 0; i < excursiiDTO.Length; i++)
            {
                friends[i] = getFromDTO(excursiiDTO[i]);
            }
            return friends;
        }

        private static Excursie getFromDTO(ExcursieDTO excursieDTO)
        {
            int id = excursieDTO.Id;
            string destinatie = excursieDTO.Destinatie;
            string data = excursieDTO.Data;
            string aeroport = excursieDTO.Aeroport;
            int nrLocuri = excursieDTO.NrLocuri;
            return new Excursie(id, destinatie, data, aeroport, nrLocuri);
        }
    }
}
