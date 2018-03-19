namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Content { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int? PlaceId { get; set; }

        public int? EventId { get; set; }

        public bool IsEnable { get; set; }

        public int? ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Event Event { get; set; }

        public virtual Place Place { get; set; }
    }
}
