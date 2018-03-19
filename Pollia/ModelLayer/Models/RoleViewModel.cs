namespace ModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
