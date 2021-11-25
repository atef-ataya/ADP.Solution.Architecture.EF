using ADP.Solution.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<AdaaTask> Tasks { get; set; }
    }
}
