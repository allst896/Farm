using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farm.Models.Db
{
    public class Sellers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
    }
}
