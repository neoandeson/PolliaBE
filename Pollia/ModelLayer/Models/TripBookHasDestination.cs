namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TripBookHasDestination
    {
        public int Id { get; set; }

        public int TripBookId { get; set; }

        public int PlaceId { get; set; }

        public int EventId { get; set; }

        public bool? IsTraveled { get; set; }

        public string Vendor { get; set; }

        public virtual Event Event { get; set; }

        public virtual Place Place { get; set; }

        public virtual TripBook TripBook { get; set; }
    }
}
