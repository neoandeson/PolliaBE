namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            Events = new HashSet<Event>();
            Places1 = new HashSet<Place>();
            Places11 = new HashSet<Place>();
            TripBookHasDestinations = new HashSet<TripBookHasDestination>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double? ZoomSize { get; set; }

        public int? ScopeId { get; set; }

        [Required]
        public string Address { get; set; }

        public int ServeStatus { get; set; }

        public int PlaceKindId { get; set; }

        public int? TimeOpen { get; set; }

        public int? TimeClose { get; set; }

        public int RatingStar { get; set; }

        public int Priority { get; set; }

        public int NofSearch { get; set; }

        public int Popular { get; set; }

        public int PLike { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string PageUrl { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? LastConfirm { get; set; }

        [Required]
        [StringLength(128)]
        public string LastUpdateUserId { get; set; }

        public int? PrevPlaceId { get; set; }

        public int? NextPlaceId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        public virtual PlaceKind PlaceKind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Place> Places1 { get; set; }

        public virtual Place Place1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Place> Places11 { get; set; }

        public virtual Place Place2 { get; set; }

        public virtual Scope Scope { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBookHasDestination> TripBookHasDestinations { get; set; }
    }
}
