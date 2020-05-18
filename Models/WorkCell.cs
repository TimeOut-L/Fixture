namespace FixtureManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class WorkCell
    {
        [Key]
        public int WorkCellID { get; set; }
        public string WorkCellName { get; set; }

    }
}
