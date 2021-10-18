using CustomerApi.DataAccess.Contexts;
using CustomerApi.DataAccess.Repositories.Abstract;
using CustomerApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.DataAccess.Repositories.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CustomerContext context;

        public CompanyRepository(CustomerContext context)
        {
            this.context = context;
        }

        public void Create(Company company)
        {
            context.Set<Company>().Add(company);
            context.SaveChanges();
        }

        public IEnumerable<Company> GetAll()
        {
            return context.Set<Company>().AsEnumerable();
        }

        public Company GetCompanyById(int Id)
        {
            return context.Set<Company>().Find(Id);
        }

        public void Update(Company company)
        {
            if (company == null) throw new ArgumentNullException();
            context.Set<Company>().Attach(company);

            context.Entry<Company>(company).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public void Remove(int Id)
        {
            if (Id == 0) throw new ArgumentNullException();
            Company company = context.Set<Company>().Find(Id);

            context.Entry<Company>(company).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
