﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using wize.common.tenancy.Interfaces;
using wize.resume.data.V1.Enums;

namespace wize.resume.data.V1.Models
{
    public class Resume : ITenantModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResumeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string SafeName { get; set; }
        public ResumeTemplate Template { get; set; }
        [RegularExpression("^#?(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$")]
        public string AccentColor { get; set; }
        [RegularExpression("^#?(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$")]
        public string AccentTextColor { get; set; }
        public string ImageUrl { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }
        public string SummaryTitle { get; set; }
        public string AwardsTitle { get; set; }
        public string ExpertiseTitle { get; set; }
        public string ExperienceTitle { get; set; }
        public string EducationTitle { get; set; }
        public string Footnote { get; set; }
        public string FootnoteTitle { get; set; }
        public string DateFormat { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }
}
