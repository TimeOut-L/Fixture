namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FixtureFamily")]
    public partial class FixtureFamily
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FixtureFamily()
        {
            FixtureDefinitions = new HashSet<FixtureDefinition>();
            FixturePurchaseApps = new HashSet<FixturePurchaseApp>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FamilyID { get; set; }

        [Required]
        [StringLength(20)]
        public string FamilyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FixtureDefinition> FixtureDefinitions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FixturePurchaseApp> FixturePurchaseApps { get; set; }
    }
}
