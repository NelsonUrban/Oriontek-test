using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Dtos
{
    public class ClientAddressDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
