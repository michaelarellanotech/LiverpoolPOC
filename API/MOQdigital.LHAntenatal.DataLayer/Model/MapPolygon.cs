using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOQdigital.LHAntenatal.DataLayer.Model
{
    public partial class MapPolygon
    {
        public int Id { get; set; }
        public int? LHDGeographyId { get; set; }
        [Required]
        [StringLength(50)]
        public string Longitude { get; set; }
        [Required]
        [StringLength(50)]
        public string Latitude { get; set; }
    }
}
