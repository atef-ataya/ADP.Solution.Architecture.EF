using ADP.Solution.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Domain.Entities
{
    public class AdaaTask : AuditableEntity
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
