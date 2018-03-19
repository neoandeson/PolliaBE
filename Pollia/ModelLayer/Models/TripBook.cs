namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TripBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TripBook()
        {
            TripBookHasDestinations = new HashSet<TripBookHasDestination>();
            TripBooks1 = new HashSet<TripBook>();
        }

        public int Id { get; set; }

        public int TB { get; set; }

        public DateTime? DateCreate { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public bool IsTraveled { get; set; }

        public bool IsPublic { get; set; }

        public bool IsRemoved { get; set; }

        public string FeedBack { get; set; }

        public int PLike { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBookHasDestination> TripBookHasDestinations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBook> TripBooks1 { get; set; }

        public virtual TripBook TripBook1 { get; set; }
    }
}
