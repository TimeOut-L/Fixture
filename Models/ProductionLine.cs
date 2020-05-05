namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductionLine")]
    public partial class ProductionLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionLine()
        {
            FixtureInRecords = new HashSet<FixtureInRecord>();
            FixtureOutRecords = new HashSet<FixtureOutRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdLineID { get; set; }

        [Required]
        [StringLength(20)]
        public string ProdLineName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FixtureInRecord> FixtureInRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FixtureOutRecord> FixtureOutRecords { get; set; }
    }
}
