namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Description { get; set; }

        public int ImageKindId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? OwnId { get; set; }

        public virtual ImageKind ImageKind { get; set; }
    }
}
