namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            DetailOrders = new HashSet<DetailOrder>();
        }

        [Key]
        public long IDOrder { get; set; }

        public bool? CheckOut { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateOrder { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateDelivery { get; set; }

        public long? IDUser { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }

        public virtual User User { get; set; }
    }
}
