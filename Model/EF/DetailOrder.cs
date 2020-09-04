namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailOrder")]
    public partial class DetailOrder
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDProduct { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDOrder { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
