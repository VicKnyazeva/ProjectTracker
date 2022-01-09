using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain
{
    /// <summary>
    /// Enum for task's statuses
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// ToDo
        /// </summary>
        ToDo,
        /// <summary>
        /// InProgress
        /// </summary>
        InProgress,
        /// <summary>
        /// Done
        /// </summary>
        Done
    }
}
