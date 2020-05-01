using Farm.Models.Db;
using Farm.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Tracker.Models
{
    public class Vaccinations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int VaccinationId { get; set; }
        public DateTime VaccinationDateTime { get; set; }
        public int LocationId { get; set; }
        public string? Symptoms { get; set; }
        public string? Vaccine { get; set; }
        public decimal? Amount { get; set; }
        public Units? Unit { get; set; }

        public ICollection<Animals> Animal { get; set; }

        [ForeignKey("LocationId")]
        public Locations Locations { get; set; }
    }
}
