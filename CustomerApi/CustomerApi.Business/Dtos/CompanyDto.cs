using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
