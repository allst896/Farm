using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Farm.Models.Db
{
    public class Machinery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int MachineryId { get; set; }
        public string Identification { get; set; }
        public string? Alias { get; set; }
    }
}
