using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wize.common.tenancy.Interfaces;

namespace wize.resume.data.V1.Models
{
    public class Expertise : ITenantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpertiseId { get; set; }
        public Guid ResumeId { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public Resume Resume { get; set; }
    }
}
