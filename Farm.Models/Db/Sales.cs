﻿using Farm.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farm.Models.Db
{
    public class Sales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int SaleId { get; set; }
        public int LocationId { get; set; }
        public decimal? Price { get; set; }
        public Units? Unit { get; set; }
        public int? BuyerId { get; set; }
        public PossessionTypes PossessionType { get; set; }

        public ICollection<Animals> AnimalId { get; set; }
        public ICollection<Machinery> MachineryId { get; set; }

        [ForeignKey("LocationId")]
        public Locations Locations { get; set; }

        [ForeignKey("BuyerId")]
        public Buyers Buyers { get; set; }
    }
}
