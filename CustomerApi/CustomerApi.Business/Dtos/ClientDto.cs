using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public int CompanyName{ get; set; }
        public bool IsActive { get; set; }
        public  IEnumerable<ClientAddressDto> ClientAddress { get; set; }
    }
}
