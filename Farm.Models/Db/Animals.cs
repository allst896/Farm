using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm.Models.Db
{
    public enum AnimalTypes
    {
        Cat = 1,
        Cattle = 2,
        Chicken = 3,
        Dog = 4,
        Goat = 5,
        Horse = 6,
        Pig = 7,
        Sheep = 8,
        Rabbit = 9
    }

    public enum Sex
    {
        Female = 1,
        Male = 2
    }

    public class Animals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int AnimalId { get; set; }
        public string? Badge { get; set; }
        public AnimalTypes AnimalType { get; set; }
        public DateTime? DOB { get; set; }
        public Sex SexType { get; set; }
        public int DamId { get; set; } = -1;
        public int SireId { get; set; } = -2;
        public string? Description { get; set; }
        public string? Alias { get; set; }
        public int? PurchaseId { get; set; }
        public int? SaleId { get; set; }
        public int? LocationId { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("PurchaseId")]
        public Purchases Purchases { get; set; }

        [ForeignKey("SaleId")]
        public Sales Sales { get; set; }

        [ForeignKey("LocationId")]
        public Locations Locations { get; set; }
    }
}
