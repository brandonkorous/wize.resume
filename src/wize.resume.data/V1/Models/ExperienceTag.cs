using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wize.common.tenancy.Interfaces;

namespace wize.resume.data.V1.Models
{
    public class ExperienceTag : ITenantModel
    {
        [Key]
        public int ExperienceTagId { get; set; }
        public int ExperienceId { get; set; }
        public int TagId { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public Experience Experience { get; set; }
        public Tag Tag { get; set; }
    }
}
