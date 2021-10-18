using AutoMapper;
using CustomerApi.BusinessLogic.Dtos;
using CustomerApi.BusinessLogic.Services.Abstract;
using CustomerApi.Common.Constants;
using CustomerApi.Common.Exceptions;
using CustomerApi.Common.Models;
using CustomerApi.Common.Services.Abstract;
using CustomerApi.DataAccess.Repositories.Abstract;
using CustomerApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CustomerApi.BusinessLogic.Services.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;
        private readonly IGlobalizationService globalizationService;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IGlobalizationService globalizationService)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
            this.globalizationService = globalizationService;
        }

        public void Create(ClientDto clientDto)
        {
            try
            {
                var client = mapper.Map<Client>(clientDto);
                clientRepository.Create(client);
            }
            catch (Exception)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.GenericNotFound) },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public IEnumerable<ClientDto> GetAll()
        {
            var clients = clientRepository.GetAll();
            if (clients.Count() == 0)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.GenericNotFound) },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            try
            {
                return mapper.Map<IEnumerable<ClientDto>>(clients);
            }
            catch (Exception)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.UnknownException) },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public ClientDto GetClientById(int Id)
        {
            var client = clientRepository.GetClientById(Id);
            if (client == null)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.GenericNotFoundById) },
                    StatusCode = HttpStatusCode.BadRequest

                };
            }
            try
            {
                return mapper.Map<ClientDto>(client);
            }
            catch (Exception)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.UnknownException) },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public void Remove(int Id)
        {
            try
            {
                clientRepository.Remove(Id);
            }
            catch (Exception)
            {

                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.UnknownException) },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public void Update(ClientDto clientDto)
        {
            try
            {
                var client = mapper.Map<Client>(clientDto);
                clientRepository.Update(client);
            }
            catch (Exception)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.UnknownException) },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
