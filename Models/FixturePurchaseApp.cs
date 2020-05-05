namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FixturePurchaseApp")]
    public partial class FixturePurchaseApp
    {
        [Required]
        [StringLength(20)]
        public string AppBy { get; set; }

        [Required]
        [StringLength(20)]
        public string AppByName { get; set; }

        public int FamilyID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public int SeqID { get; set; }

        [Key]
        [StringLength(20)]
        public string BillNo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime RegDate { get; set; }

        [StringLength(20)]
        public string Pic { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }

        public virtual FixtureEntity FixtureEntity { get; set; }

        public virtual FixtureFamily FixtureFamily { get; set; }
    }
}
