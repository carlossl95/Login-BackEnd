using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serve.Domain;
using Serve.Domain.IRepository;
using Serve.Infra.Data.Dao;

namespace Serve.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly ClientDao _clientDao;
        public ClientRepository()
        {
            _clientDao= new ClientDao();
        }

        public void AddnewClient(Client newClient)
        {
            _clientDao.AddNewClient(newClient);
        }

        public void DeleteClient(int id)
        {
            _clientDao.DeleteClient(id);
        }

        public List<Client> ListClient()
        {
            return _clientDao.ListClient();
        }

        public object SearchClientId(int id)
        {
            return  _clientDao.SeaecheId(id);
        }

        public Client UpdateClient(Client updateClient)
        {
            return _clientDao.UpdateClient(updateClient);
        }

        public void UpdatePassword(int id, string newPassword)
        {
            _clientDao.UpdatePassword(id, newPassword);
        }
    }
}
