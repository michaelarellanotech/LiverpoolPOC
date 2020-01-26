using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class Question
    {
        public Question()
        {
            QuestionText = new HashSet<QuestionText>();
        }

        public int Id { get; set; }
        public int? QuestionGroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [MaxLength(1000)]
        public byte[] Description { get; set; }
        [StringLength(50)]
        public string SortOrder { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
        public int CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("QuestionGroupId")]
        [InverseProperty("Question")]
        public virtual QuestionGroup QuestionGroup { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<QuestionText> QuestionText { get; set; }
    }
}
