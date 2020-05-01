using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farm.Models.Db
{
    public class Buyers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
    }
}
