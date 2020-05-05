namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FixtureRepairRecord")]
    public partial class FixtureRepairRecord
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string RepBy { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string RepByName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeqID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string faultDes { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string faultPic { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string DealBy { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string DealByName { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string DealRes { get; set; }
    }
}
