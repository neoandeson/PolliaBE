namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            TripBookHasDestinations = new HashSet<TripBookHasDestination>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Page { get; set; }

        public string PageUrl { get; set; }

        public string ImgUrl { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }

        public int EventKindId { get; set; }

        public int PlaceId { get; set; }

        public int? ScopeId { get; set; }

        public int ServeStatus { get; set; }

        public int RatingStar { get; set; }

        public int Priority { get; set; }

        public int NofSearch { get; set; }

        public int Poppular { get; set; }

        public int PLike { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public int? TimeOpen { get; set; }

        public int? TimeClose { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public DateTime? LastConfirm { get; set; }

        [Required]
        [StringLength(128)]
        public string LastUpdateUserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual EventKind EventKind { get; set; }

        public virtual Place Place { get; set; }

        public virtual Scope Scope { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBookHasDestination> TripBookHasDestinations { get; set; }
    }
}
