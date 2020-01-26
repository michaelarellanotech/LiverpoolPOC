using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class QuestionText
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int LanguageId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
        public int CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("QuestionId")]
        [InverseProperty("QuestionText")]
        public virtual Question Question { get; set; }
    }
}
