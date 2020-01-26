using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class Language
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Column("Language")]
        [StringLength(50)]
        public string Language1 { get; set; }
        public bool RTL { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
        public int CreatedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedById { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
