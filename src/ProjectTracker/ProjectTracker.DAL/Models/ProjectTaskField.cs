using ProjectTracker.Domain;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTracker.DAL.Models
{
    public class ProjectTaskField : IProjectTaskField
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }

        public ProjectTask Task { get; set; }
    }
}
