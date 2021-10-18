using CustomerApi.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Services.Abstract
{
    public interface IClientService
    {
        void Create(ClientDto clientDto);
        IEnumerable<ClientDto> GetAll();
        ClientDto GetClientById(int Id);
        void Update(ClientDto clientDto);
        void Remove(int Id);
    }
}
