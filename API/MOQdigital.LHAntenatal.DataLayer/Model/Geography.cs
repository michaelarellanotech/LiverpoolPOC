using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class Geography
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
