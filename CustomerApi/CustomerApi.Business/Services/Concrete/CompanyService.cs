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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        private readonly IGlobalizationService globalizationService;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IGlobalizationService globalizationService)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.globalizationService = globalizationService;
        }

        public void Create(CompanyDto companyDto)
        {
            try
            {
                var company = mapper.Map<Company>(companyDto);
                companyRepository.Create(company);
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

        public IEnumerable<CompanyDto> GetAll()
        {
            var companies = companyRepository.GetAll();
            if (companies.Count() == 0)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.GenericNotFound) },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            try
            {
                return mapper.Map<IEnumerable<CompanyDto>>(companies);
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

        public CompanyDto GetCompanyById(int Id)
        {
            var company = companyRepository.GetCompanyById(Id);
            if (company == null)
            {
                throw new HttpResponseException
                {
                    Errors = new Error[] { globalizationService.GetErrorInCurrentLanguage(ErrorCodes.GenericNotFound) },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            try
            {
                return mapper.Map<CompanyDto>(company);
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
                companyRepository.Remove(Id);
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

        public void Update(CompanyDto companyDto)
        {
            try
            {
                var company = mapper.Map<Company>(companyDto);
                companyRepository.Update(company);
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
