namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FixtureScrapRecord")]
    public partial class FixtureScrapRecord
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ScrapBy { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ScrapByName { get; set; }

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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsedCount { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string ScrapReason { get; set; }
    }
}
