using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wize.common.tenancy.Interfaces;

namespace wize.resume.data.V1.Models
{
    public class Award : ITenantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)][Description("testing")]
        public int AwardId { get; set; }
        public Guid ResumeId { get; set; }
        public string Title { get; set; }
        public string NominatedBy { get; set; }
        [MaxLength(250)]
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime? Nominated { get; set; }
        public DateTime? Awarded { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
