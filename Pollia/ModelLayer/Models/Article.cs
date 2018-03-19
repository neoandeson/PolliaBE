namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public bool? IsEnable { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Content { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int? PlaceId { get; set; }

        public int? EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Place Place { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
