using CustomerApi.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public virtual IEnumerable<ClientAddress> ClientAddress { get; set; }
    }
}
