using CustomerApi.Domain.Entities;
using System.Collections.Generic;

namespace CustomerApi.DataAccess.Repositories.Abstract
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        IEnumerable<Company> GetAll();
        Company GetCompanyById(int Id);
        void Update(Company client);
        void Remove(int Id);
    }
}
