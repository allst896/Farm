using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farm.Models.Db
{
    public class Locations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? LegalDescription { get; set; }
        public decimal? Acreage { get; set; }

        public ICollection<Animals> Animals { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
