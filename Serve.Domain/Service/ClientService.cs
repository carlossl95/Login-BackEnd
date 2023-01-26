using Serve.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serve.Domain.Service
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        public int Login(Client loginClient)
        {
            if (loginClient.Email == null)
                throw new Exception("Email is required!!!");

            if (loginClient.Password == null)
                throw new Exception("Password is required!!!");


            var listClient = _clientRepository.ListClient();

            if (listClient == null)
                throw new Exception("No registered user!!!");

            foreach (var client in listClient)
            {
                if (client.Email == loginClient.Email)
                {
                    if (client.Password != loginClient.Password)
                        throw new Exception("Incorrect password");
                    else
                    {
                        int idLogin = client.Id;
                        return idLogin;
                    }
                }
            }
            throw new Exception("Client not registered!!");
        }

        public Client AddNewClient(Client newClient)
        {

            ValidProperties(newClient);
            ValidEmail(newClient.Email);
            ValidPassword(newClient.Password);

            var listClient = _clientRepository.ListClient();

            foreach (var client in listClient)
            {
                if (client.Cpf == newClient.Cpf)
                    throw new Exception($"Cpf {client.Cpf} ALREADY REGISTERED");
                if (client.Email == newClient.Email)
                    throw new Exception($"Email {client.Email} ALREADY REGISTERED");
            }

            _clientRepository.AddnewClient(newClient);

            var listClientValid = _clientRepository.ListClient();

            foreach (var client in listClientValid)
            {
                if (client.Cpf == newClient.Cpf)

                    return newClient;
            }

            throw new Exception("Error");
        }

        public object UpdateDiceClient(Client updateClient)
        {
            ValidProperties(updateClient);

            var listClient = _clientRepository.ListClient();

            foreach (var client in listClient)
            {
                if (client.Cpf == updateClient.Cpf && client.Id != updateClient.Id)
                    throw new Exception($"Cpf {client.Cpf} ALREADY REGISTERED");
            }

            _clientRepository.UpdateClient(updateClient);
            return true;
        }

        public object SearchClient(int id)
        {
            return _clientRepository.SearchClientId(id);
        }

        public object EditPassword(int id, string currentPassword, string newPassword)
        {
            Client clientSearch = new Client();

            ValidPassword(newPassword);

            var listClient = _clientRepository.ListClient();

            foreach (var client in listClient)
            {
                if (client.Id == id)
                {
                    clientSearch = client;
                    break;
                }
            }
            if (currentPassword != clientSearch.Password)
                throw new Exception("Wrong current password");

            _clientRepository.UpdatePassword(id, newPassword);

            return true;
        }

        public object DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);

            try
            {
                _clientRepository.SearchClientId(id);
                throw new Exception("Error deleting user");
            }
            catch (Exception)
            {                
                return true;
            }            
        }



        private void ValidPassword(string password)
        {
            if (password.Length < 8)
                throw new Exception("The password must be at least 8 characters long.");

            if (password.Length > 20)
                throw new Exception("The password must have a maximum of 20 characters.");

            if (!Regex.IsMatch(password, "[0-9]"))
                throw new Exception("The password must contain at least one number.");

            if (!Regex.IsMatch(password, "[a-z]"))
                throw new Exception("The password must contain at least one lowercase letter.");

            if (!Regex.IsMatch(password, "[A-Z]"))
                throw new Exception("The password should contain at least 1 uppercase character.");

            if (!Regex.IsMatch(password, "[!@#\\$%^&*]"))
                throw new Exception("The password must contain at least one special character.");

        }

        internal void ValidEmail(string email)
        {
            if (email == null || email.Length > 50)
                throw new Exception("Null Email or maximum size 50 characters!!!");            
        }

        internal void ValidProperties(Client newClient)
        {
            if (newClient.Name == null || newClient.Name.Length > 120)
                throw new Exception("Null NAME or maximum size 120 characters!!!");            

            if (newClient.Phone == null || newClient.Phone.Length > 15)
                throw new Exception("Null PHONE or maximum size 15 characters!!!");

            if (newClient.Cpf == null || newClient.Cpf.Length > 14)
                throw new Exception("Null CPF or maximum size 14 characters!!!");

            if (newClient.BirthDate == null)
                throw new Exception("Null BIRTH_DATE!!!");

            if (newClient.sex == null || newClient.sex.Length > 25)
                throw new Exception("Null SEX or maximum size 25 characters!!!");

            if (newClient.MaritalStatus == null || newClient.MaritalStatus.Length > 25)
                throw new Exception("Null MARITAL_STATUS or maximum size 25 characters!!!");

            if (newClient.Cep == null || newClient.Cep.Length > 10)
                throw new Exception("Null CEP or maximum size 10 characters!!!");

            if (newClient.City == null || newClient.City.Length > 30)
                throw new Exception("Null CITY or maximum size 30 characters!!!");

            if (newClient.Neighborhood == null || newClient.Neighborhood.Length > 30)
                throw new Exception("Null NEIGHBORHOOD or maximum size 30 characters!!!");

            if (newClient.State == null || newClient.State.Length > 30)
                throw new Exception("Null STATE or maximum size 30 characters!!!");

            if (newClient.Street == null || newClient.Street.Length > 70)
                throw new Exception("Null STREET or maximum size 70 characters!!!");

            if (newClient.Number == null || newClient.Number.Length > 6)
                throw new Exception("Null NUMBER or maximum size 6 characters!!!");            

            if (newClient.Complement == null)
                newClient.Complement = " ";

            if (newClient.Complement.Length > 50)
                throw new Exception("Maximum size 50 characters!!!");
        }

        
    }
}
