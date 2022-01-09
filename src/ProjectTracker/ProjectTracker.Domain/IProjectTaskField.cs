using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain
{
    public interface IProjectTaskField : IEntity
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
