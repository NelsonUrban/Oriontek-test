using CustomerApi.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Services.Abstract
{
    public interface ICompanyService
    {
        void Create(CompanyDto companyDto);
        IEnumerable<CompanyDto> GetAll();
        CompanyDto GetCompanyById(int Id);
        void Update(CompanyDto companyDto);
        void Remove(int Id);
    }
}
