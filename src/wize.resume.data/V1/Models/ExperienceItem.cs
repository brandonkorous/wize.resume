using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wize.common.tenancy.Interfaces;

namespace wize.resume.data.V1.Models
{
    public class ExperienceItem : ITenantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceItemId { get; set; }
        public int ExperienceId { get; set; }
        public int? ParentExperienceItemId { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public Experience Experience { get; set; }
        [ForeignKey(nameof(ParentExperienceItemId))]
        public ExperienceItem Parent { get; set; }
        public virtual ICollection<ExperienceItem> Children { get; set; }
    }
}
