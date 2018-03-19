namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int Type { get; set; }

        public int? PlaceId { get; set; }

        public int? EventId { get; set; }

        public int? ArticleId { get; set; }
    }
}
