using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.IRepository
{
    public interface IClientRepository
    {
        void AddnewClient(Client newClient);
        List<Client> ListClient();
        Client UpdateClient(Client updateClient);

        object SearchClientId(int id);
        void UpdatePassword(int id, string newPassword);
        void DeleteClient(int id);
    }
}
