using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Farm.Models.Db
{
    public enum EventTypes
    {
        Purchase = 1,
        Relocation = 2,
        Sale = 3,
        Vaccination = 4,
        Death = 5,
        Birth = 6
    }
}
