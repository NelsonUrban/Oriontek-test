using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
