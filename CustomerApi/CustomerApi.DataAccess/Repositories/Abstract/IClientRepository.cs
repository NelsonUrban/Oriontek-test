using CustomerApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.DataAccess.Repositories.Abstract
{
    public interface IClientRepository
    {
        void Create(Client client);
        IEnumerable<Client> GetAll();
        Client GetClientById(int Id);
        void Update(Client client);
        void Remove(int Id);

    }
}
