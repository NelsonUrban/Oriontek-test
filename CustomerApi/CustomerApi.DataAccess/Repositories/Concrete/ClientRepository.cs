using CustomerApi.DataAccess.Contexts;
using CustomerApi.DataAccess.Repositories.Abstract;
using CustomerApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.DataAccess.Repositories.Concrete
{
    public class ClientRepository : IClientRepository
    {
        private readonly CustomerContext context;

        public ClientRepository(CustomerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return context.Set<Client>().Include("ClientAddress").AsEnumerable();
        }

        public void Create(Client client)
        {
            context.Set<Client>().Add(client);
            context.SaveChanges();
        }

        public Client GetClientById(int Id)
        {
            return context.Set<Client>().Find(Id);
        }

        public void Update(Client client)
        {
            var isNewAddress = client.ClientAddress.Where(x => x.Id == 0).ToList();
            var isAddress = client.ClientAddress.Where(x => x.Id != 0).ToList();
            if (isNewAddress.Count() > 0)
            {
                foreach (var item in isNewAddress)
                {
                    item.ClientId = client.Id;
                    context.Set<ClientAddress>().Add(item);
                    context.SaveChanges();
                }
            }
            if (isAddress.Count() > 0)
            {
                var oldDetails = GetClientAddresses(client.Id);
                foreach (var oldDetail in oldDetails)
                {
                    context.Set<ClientAddress>().Remove(oldDetail);
                }
                foreach (var AddressDetails in client.ClientAddress)
                {
                    AddressDetails.ModificationDate = DateTime.Now;
                    context.Set<ClientAddress>().Attach(AddressDetails);
                    context.Entry<ClientAddress>(AddressDetails).State = EntityState.Modified;
                }
                client.CreationDate = client.CreationDate;
                context.Entry<Client>(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        private IEnumerable<ClientAddress> GetClientAddresses(int clientId)
        {
            return context.Set<ClientAddress>().Where(x => x.ClientId == clientId).ToList();
        }
        public void Remove(int Id)
        {
            if (Id == 0) throw new ArgumentNullException();
            Client client = context.Set<Client>().Find(Id);

            context.Entry<Client>(client).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
